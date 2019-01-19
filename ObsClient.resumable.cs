using OBS.Internal;
using OBS.Internal.Log;
using OBS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Net;

namespace OBS
{
    public partial class ObsClient
    {

        #region UploadFile
        /// <summary>
        /// 断点续传上传文件。
        /// </summary>
        /// <param name="request">上传文件的请求参数。</param>
        /// <returns>合并段的响应结果。</returns>
        public CompleteMultipartUploadResponse UploadFile(UploadFileRequest request)
        {
            ParameterJudgment(request);
            if (request.EnableCheckpoint)
            {
                if (string.IsNullOrEmpty(request.CheckpointFile))
                {
                    request.CheckpointFile = request.UploadFile + ".uploadFile_record";
                }
            }
            if (string.IsNullOrEmpty(request.UploadFile) || !File.Exists(request.UploadFile))
            {
                if (File.Exists(request.CheckpointFile)){
                    File.Delete(request.CheckpointFile);
                }
                throw new ObsException("The UploadFile is not exist.", ErrorType.Sender, "NoSuchUploadFile", "");
            }
            
            return ResumableUploadExcute(request);
        }

        /// <summary>
        /// 断点续传上传数据流。
        /// </summary>
        /// <param name="request">上传数据流的请求参数。</param>
        /// <returns>合并段的响应结果。</returns>
        public CompleteMultipartUploadResponse UploadStream(UploadStreamRequest request)
        {
            ParameterJudgment(request);
            if (request.UploadStream == null)
            {
                throw new ObsException("The UploadStream is null.", ErrorType.Sender, "NullUploadStream", "");
            }

            if (!request.UploadStream.CanSeek)
            {
                throw new ObsException("The UploadStream is not seekable.", ErrorType.Sender, "NotSeekableUploadStream", "");
            }

            if (request.EnableCheckpoint)
            {
                if (string.IsNullOrEmpty(request.CheckpointFile))
                {
                    request.CheckpointFile = Environment.CurrentDirectory + "/" + request.ObjectKey + ".uploadFile_record";
                }
            }

            return ResumableUploadExcute(request);
        }

        /// <summary>
        /// 参数校验
        /// </summary>
        /// <param name="request"></param>
        private void ParameterJudgment(ResumableUploadRequest request)
        {
            if (request == null)
            {
                throw new ObsException(Constants.NullRequestMessage, ErrorType.Sender, Constants.NullRequest, "");
            }
            if (string.IsNullOrEmpty(request.BucketName))
            {
                throw new ObsException(Constants.InvalidBucketNameMessage, ErrorType.Sender, Constants.InvalidBucketName, "");
            }
            if (string.IsNullOrEmpty(request.ObjectKey))
            {
                throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
            }
        }


        /// <summary>
        /// 断点续传上传执行方法
        /// </summary>
        /// <param name="resumableUploadRequest"></param>
        /// <returns></returns>
        private CompleteMultipartUploadResponse ResumableUploadExcute(ResumableUploadRequest resumableUploadRequest)
        {
            UploadCheckPoint uploadCheckPoint = new UploadCheckPoint();

            ResumableUploadTypeEnum uploadType;
            if (resumableUploadRequest is UploadFileRequest)
            {
                uploadType = ResumableUploadTypeEnum.UploadFile;
            }
            else
            {
                uploadType = ResumableUploadTypeEnum.UploadStream;
                uploadCheckPoint.UploadStream = (resumableUploadRequest as UploadStreamRequest).UploadStream;
            }

            //开启断点续传
            if (resumableUploadRequest.EnableCheckpoint)
            {
                bool loadFileFlag = true;//序列化文件加载成功标志位
                bool paraVerifyFlag = true;//参数信息一致性校验标志位
                bool fileVerifyFlag = true;//序列化文件一致性校验标志位

                if (!File.Exists(resumableUploadRequest.CheckpointFile))
                {
                    loadFileFlag = false;
                }
                else
                {
                    try
                    {
                        //加载序列化文件CheckpointFile
                        uploadCheckPoint.Load(resumableUploadRequest.CheckpointFile);
                    }
                    //首次上传时会出现加载失败
                    catch (Exception ex)
                    {
                        LoggerMgr.Warn(string.Format("Load checkpoint file with path {0} error", resumableUploadRequest.CheckpointFile), ex);
                        loadFileFlag = false;
                    }
                }

                //序列化文件加载成功时才进行后续校验
                if (loadFileFlag)
                {
                    //UploadFile方式
                    if (uploadType == ResumableUploadTypeEnum.UploadFile)
                    {
                        UploadFileRequest uploadFileRequest = resumableUploadRequest as UploadFileRequest;
                        //参数信息一致性校验：UploadFileRequest参数（桶名、对象名、上传文件路径）与CheckpointFile记录数据的一致性验证
                        if (!(uploadFileRequest.BucketName.Equals(uploadCheckPoint.BucketName)
                            && uploadFileRequest.ObjectKey.Equals(uploadCheckPoint.ObjectKey)
                            && uploadFileRequest.UploadFile.Equals(uploadCheckPoint.UploadFile)))
                        {
                            paraVerifyFlag = false;
                        }
                        //参数信息一致性校验成功时
                        else
                        {
                            //序列化文件一致性校验：Md5值；文件的名字、大小、最后修改时间；CheckSum值
                            fileVerifyFlag = uploadCheckPoint.IsValid(uploadFileRequest.UploadFile, null, uploadFileRequest.EnableCheckSum, uploadType);
                        }
                    }
                    //UploadStream方式
                    else
                    {
                        UploadStreamRequest uploadStreamRequest = resumableUploadRequest as UploadStreamRequest;
                        //参数信息一致性校验：UploadStreamRequest参数（桶名、对象名）与CheckpointFile记录数据的一致性验证
                        if (!(uploadStreamRequest.BucketName.Equals(uploadCheckPoint.BucketName)
                            && uploadStreamRequest.ObjectKey.Equals(uploadCheckPoint.ObjectKey)))
                        {
                            paraVerifyFlag = false;
                        }
                        //参数信息一致性校验成功时
                        else
                        {
                            //序列化文件一致性校验：Md5值；CheckSum值：必选true--校验UploadStream流的一致性
                            fileVerifyFlag = uploadCheckPoint.IsValid(null, uploadStreamRequest.UploadStream, uploadStreamRequest.EnableCheckSum, uploadType);
                        }
                    }
                }

                //任一阶段校验失败时
                if (!loadFileFlag || !paraVerifyFlag || !fileVerifyFlag)
                {
                    //若序列化文件加载成功，且当参数校验失败或序列化文件校验失败，才取消多段上传任务
                    if (loadFileFlag && !string.IsNullOrEmpty(uploadCheckPoint.BucketName) && !string.IsNullOrEmpty(uploadCheckPoint.ObjectKey) &&
                        !string.IsNullOrEmpty(uploadCheckPoint.UploadId))
                    {
                        //取消多段上传任务
                        AbortMultipartUpload(uploadCheckPoint);
                    }

                    //删除原有的CheckpointFile文件
                    if (File.Exists(resumableUploadRequest.CheckpointFile))
                    {
                        File.Delete(resumableUploadRequest.CheckpointFile);
                    }

                    //准备工作
                    ResumableUploadPrepare(resumableUploadRequest, uploadCheckPoint);
                }
            }
            //未开启断点续传
            else
            {
                //准备工作
                ResumableUploadPrepare(resumableUploadRequest, uploadCheckPoint);
            }

            TransferStreamManager mgr = null;
            try
            {
                //开始并发上传段
                IList<PartResultUpload> partResultsUpload = ResumableUploadBegin(resumableUploadRequest, uploadCheckPoint, out mgr, uploadType);


                //上传结果校验
                foreach (PartResultUpload result in partResultsUpload)
                {
                    //上传失败
                    if (result.IsFailed && result.Exception != null)
                    {
                        //若没有开启断点续传，则直接取消多段上传任务
                        if (!resumableUploadRequest.EnableCheckpoint)
                        {
                            AbortMultipartUpload(uploadCheckPoint);
                        }
                        //若开启断点续传
                        else if(uploadCheckPoint.IsUploadAbort)
                        {
                            AbortMultipartUpload(uploadCheckPoint);

                            //删除原有的CheckpointFile文件
                            if (File.Exists(resumableUploadRequest.CheckpointFile))
                            {
                                File.Delete(resumableUploadRequest.CheckpointFile);
                            }
                        }
                        //抛出异常
                        throw result.Exception;
                    }
                }
            }
            finally
            {
                if (mgr is ThreadSafeTransferStreamByBytes)
                {
                    mgr.TransferEnd();
                }
            }
           

            //合并多段
            CompleteMultipartUploadRequest completeMultipartUploadRequest = new CompleteMultipartUploadRequest
            {
                BucketName = resumableUploadRequest.BucketName,
                ObjectKey = resumableUploadRequest.ObjectKey,
                UploadId = uploadCheckPoint.UploadId,
                PartETags = uploadCheckPoint.PartEtags
            };
            try
            {
                CompleteMultipartUploadResponse completeMultipartUploadResponse = CompleteMultipartUpload(completeMultipartUploadRequest);
                if (resumableUploadRequest.UploadEventHandler != null)
                {
                    ResumableUploadEvent e = new ResumableUploadEvent();
                    e.EventType = ResumableUploadEventTypeEnum.CompleteMultipartUploadSucceed;
                    e.UploadId = uploadCheckPoint.UploadId;
                    e.ETag = completeMultipartUploadResponse.ETag;
                    resumableUploadRequest.UploadEventHandler(this, e);
                }
                if (resumableUploadRequest.EnableCheckpoint)
                {
                    //合并段成功，删除序列化文件
                    if (File.Exists(resumableUploadRequest.CheckpointFile))
                    {
                        File.Delete(resumableUploadRequest.CheckpointFile);
                    }
                }
                return completeMultipartUploadResponse;
            }
            //合并段操作失败
            catch (ObsException ex)
            {
                //若没有开启断点续传，则直接取消多段上传任务
                if (!resumableUploadRequest.EnableCheckpoint)
                {
                    AbortMultipartUpload(uploadCheckPoint);
                }
                //若开启断点续传
                else
                {
                    //若返回4xx状态码，则取消多段上传任务
                    if (ex.StatusCode >= HttpStatusCode.BadRequest && ex.StatusCode < HttpStatusCode.InternalServerError)
                    {
                        AbortMultipartUpload(uploadCheckPoint);

                        //删除原有的CheckpointFile文件
                        if (File.Exists(resumableUploadRequest.CheckpointFile))
                        {
                            File.Delete(resumableUploadRequest.CheckpointFile);
                        }
                    }
                }

                if (resumableUploadRequest.UploadEventHandler != null)
                {
                    ResumableUploadEvent e = new ResumableUploadEvent();
                    e.EventType = ResumableUploadEventTypeEnum.CompleteMultipartUploadFailed;
                    e.UploadId = uploadCheckPoint.UploadId;
                    resumableUploadRequest.UploadEventHandler(this, e);
                }

                //抛出异常
                throw ex;
            }
        }

        /// <summary>
        /// 上传文件准备工作
        /// </summary>
        /// <param name="resumableUploadRequest"></param>
        /// <param name="uploadCheckPoint"></param>
        private void ResumableUploadPrepare(ResumableUploadRequest resumableUploadRequest, UploadCheckPoint uploadCheckPoint)
        {
            //根据ResumableUploadRequest中用户设置的参数来更新UploadCheckPoint中字段信息
            uploadCheckPoint.BucketName = resumableUploadRequest.BucketName;
            uploadCheckPoint.ObjectKey = resumableUploadRequest.ObjectKey;
            long originPosition = 0;
            if (resumableUploadRequest is UploadFileRequest)
            {
                UploadFileRequest uploadFileRequest = resumableUploadRequest as UploadFileRequest;
                uploadCheckPoint.UploadFile = uploadFileRequest.UploadFile;
                uploadCheckPoint.FileStatus = FileStatus.getFileStatus(uploadFileRequest.UploadFile, null, uploadFileRequest.EnableCheckSum, ResumableUploadTypeEnum.UploadFile);
            }
            else
            {
                UploadStreamRequest uploadStreamRequest = resumableUploadRequest as UploadStreamRequest;
                uploadCheckPoint.UploadStream = uploadStreamRequest.UploadStream;
                uploadCheckPoint.FileStatus = FileStatus.getFileStatus(null, uploadStreamRequest.UploadStream, uploadStreamRequest.EnableCheckSum, ResumableUploadTypeEnum.UploadStream);
                originPosition = uploadCheckPoint.UploadStream.Position;
            }
            
            uploadCheckPoint.UploadParts = SplitUploadFile(uploadCheckPoint.FileStatus.Size, resumableUploadRequest.UploadPartSize, originPosition);
            uploadCheckPoint.PartEtags = new List<PartETag>();

            //初始化多段上传任务
            InitiateMultipartUploadRequest initiateRequest = new InitiateMultipartUploadRequest()
            {
                BucketName = resumableUploadRequest.BucketName,
                ObjectKey = resumableUploadRequest.ObjectKey,
                Metadata = resumableUploadRequest.Metadata,
                CannedAcl = resumableUploadRequest.CannedAcl,
                StorageClass = resumableUploadRequest.StorageClass,
                WebsiteRedirectLocation = resumableUploadRequest.WebsiteRedirectLocation,
                Expires = resumableUploadRequest.Expires,
                ContentType = resumableUploadRequest.ContentType,
                SuccessRedirectLocation = resumableUploadRequest.SuccessRedirectLocation,
                SseHeader = resumableUploadRequest.SseHeader
            };

            foreach (var entry in resumableUploadRequest.ExtensionPermissionMap)
            {
                initiateRequest.ExtensionPermissionMap.Add(entry.Key, entry.Value);
            }
            InitiateMultipartUploadResponse initiateResponse;
            try
            {
                initiateResponse = InitiateMultipartUpload(initiateRequest);
            }
            catch (ObsException ex)
            {
                if (resumableUploadRequest.UploadEventHandler != null)
                {
                    ResumableUploadEvent e = new ResumableUploadEvent();
                    e.EventType = ResumableUploadEventTypeEnum.InitiateMultipartUploadFailed;
                    resumableUploadRequest.UploadEventHandler(this, e);
                }
                throw ex;
            }

            //获取分段上传任务号
            uploadCheckPoint.UploadId = initiateResponse.UploadId;

            //若开启断点续传，需记录UploadCheckPoint的数据到序列化文件
            if (resumableUploadRequest.EnableCheckpoint)
            {
                try
                {
                    uploadCheckPoint.Record(resumableUploadRequest.CheckpointFile);
                }
                //若记录文件操作失败
                catch (Exception ex)
                {
                    //取消多段上传任务
                    AbortMultipartUpload(uploadCheckPoint);

                    //抛出线程异常（将Exception异常转换为ObsException类型，最外层的catch才可捕获）
                    ObsException exception = new ObsException(ex.Message, ex);
                    exception.ErrorType = ErrorType.Sender;
                    throw exception;
                }
            }
            if (resumableUploadRequest.UploadEventHandler != null)
            {
                ResumableUploadEvent e = new ResumableUploadEvent();
                e.UploadId = uploadCheckPoint.UploadId;
                e.EventType = ResumableUploadEventTypeEnum.InitiateMultipartUploadSucceed;
                resumableUploadRequest.UploadEventHandler(this, e);
            }
        }

        /// <summary>
        /// 根据上传文件的文件大小和分段大小，计算出段列表
        /// </summary>
        /// <param name="fileLength"></param>
        /// <param name="partSize"></param>
        /// <returns></returns>
        private List<UploadPart> SplitUploadFile(long fileLength, long partSize, long originPosition)
        {
            List<UploadPart> parts = new List<UploadPart>();

            int partNumber = Convert.ToInt32(fileLength / partSize);

            if (partNumber >= 10000)
            {
                partSize = fileLength %10000==0? fileLength / 10000 : fileLength/10000+1;
                partNumber = Convert.ToInt32(fileLength / partSize);
            }

            if (fileLength % partSize > 0)
                partNumber++;

            if(partNumber == 0)
            {
                parts.Add(new UploadPart()
                {
                    PartNumber = 1,
                    Offset = 0,
                    Size = 0,
                    IsCompleted = false
                });
            }
            else
            {
                for (int i = 0; i < partNumber; i++)
                {
                    parts.Add(new UploadPart()
                    {
                        PartNumber = i + 1,
                        Offset = i * partSize + originPosition,
                        Size = partSize,
                        IsCompleted = false
                    });
                }
                if (fileLength % partSize > 0)
                    parts[parts.Count - 1].Size = fileLength % partSize;
            }

            return parts;
        }

        /// <summary>
        /// 上传段的结果
        /// </summary>
        internal class PartResultUpload
        {
            public bool IsFailed { get; set; }

            public ObsException Exception { get; set; }
        }

        internal class UploadPartExcuteParam
        {
            internal ResumableUploadTypeEnum uploadType;
            internal UploadPart uploadPart;
            internal UploadCheckPoint uploadCheckPoint;
            internal PartResultUpload partResultUpload;
            internal ManualResetEvent executeEvent;
            internal string checkpointFile;
            internal bool enableCheckpoint;
            internal TransferStreamManager mgr;
            internal EventHandler<ResumableUploadEvent> eventHandler;
        }

        private void UploadPartExcute(object state)
        {
            UploadPartExcuteParam param = state as UploadPartExcuteParam;

            UploadPart uploadPart = param.uploadPart;

            PartResultUpload partResultUpload = new PartResultUpload();

            UploadCheckPoint uploadCheckPoint = param.uploadCheckPoint;

            try
            {
                if (!uploadCheckPoint.IsUploadAbort)
                {
                    UploadPartRequest uploadPartRequest = new UploadPartRequest()
                    {
                        BucketName = uploadCheckPoint.BucketName,
                        ObjectKey = uploadCheckPoint.ObjectKey,
                        UploadId = uploadCheckPoint.UploadId,
                        PartNumber = uploadPart.PartNumber,
                        PartSize = uploadPart.Size,
                        AutoClose = false
                    };

                    //调用上传段接口
                    UploadPartResponse uploadPartResponse = null;
                    //文件方式
                    if (param.uploadType == ResumableUploadTypeEnum.UploadFile)
                    {
                        if (param.mgr != null)
                        {
                            using (TransferStream stream = new TransferStream(new FileStream(uploadCheckPoint.UploadFile, FileMode.Open, FileAccess.Read)))
                            {
                                stream.Seek(uploadPart.Offset, SeekOrigin.Begin);
                                stream.BytesReaded += param.mgr.BytesTransfered;
                                stream.StartRead += param.mgr.TransferStart;
                                stream.BytesReset += param.mgr.TransferReset;
                                uploadPartRequest.InputStream = stream;
                                uploadPartResponse = UploadPart(uploadPartRequest);
                            }
                        }
                        else
                        {
                            uploadPartRequest.Offset = uploadPart.Offset;
                            uploadPartRequest.FilePath = uploadCheckPoint.UploadFile;
                            uploadPartResponse = UploadPart(uploadPartRequest);
                        }
                    }
                    //数据流方式
                    else
                    {
                        if (param.mgr != null)
                        {
                            TransferStream stream = new TransferStream(uploadCheckPoint.UploadStream);
                            stream.Seek(uploadPart.Offset, SeekOrigin.Begin);
                            stream.BytesReaded += param.mgr.BytesTransfered;
                            stream.StartRead += param.mgr.TransferStart;
                            uploadPartRequest.InputStream = stream;
                            uploadPartResponse = UploadPart(uploadPartRequest);
                        }
                        else
                        {
                            uploadCheckPoint.UploadStream.Seek(uploadPart.Offset, SeekOrigin.Begin);
                            uploadPartRequest.Offset = uploadPart.Offset;
                            uploadPartRequest.InputStream = uploadCheckPoint.UploadStream;
                            uploadPartResponse = UploadPart(uploadPartRequest);
                        }
                    }

                    PartETag partEtag = new PartETag(uploadPartResponse.PartNumber, uploadPartResponse.ETag);
                    //更新异步返回结果PartResult的IsFailed字段
                    partResultUpload.IsFailed = false;
                    uploadPart.IsCompleted = true;
                    lock (param.uploadCheckPoint.uploadlock)
                    {
                        uploadCheckPoint.PartEtags.Add(partEtag);
                        if (param.enableCheckpoint)
                        {
                            uploadCheckPoint.Record(param.checkpointFile);
                        }
                    }

                    if (param.eventHandler != null)
                    {
                        ResumableUploadEvent e = new ResumableUploadEvent();
                        e.EventType = ResumableUploadEventTypeEnum.UploadPartSucceed;
                        e.UploadId = uploadCheckPoint.UploadId;
                        e.PartNumber = uploadPart.PartNumber;
                        e.ETag = partEtag.ETag;
                        param.eventHandler(this, e);
                    }

                    if (LoggerMgr.IsDebugEnabled)
                    {
                        LoggerMgr.Debug(string.Format("PartNumber {0} is done, PartSize {1}, Offset {2}", uploadPart.PartNumber,
                            uploadPart.Size, uploadPart.Offset));
                    }

                }
                else
                {
                    partResultUpload.IsFailed = true;
                }
            } //上传段失败
            catch (ObsException ex)
            {
                //若返回4xx状态码，则剩余段也就无需再继续上传了
                if (ex.StatusCode >= HttpStatusCode.BadRequest && ex.StatusCode < HttpStatusCode.InternalServerError)
                {
                    uploadCheckPoint.IsUploadAbort = true;
                }
                partResultUpload.IsFailed = true;
                partResultUpload.Exception = ex;

                if (param.eventHandler != null)
                {
                    ResumableUploadEvent e = new ResumableUploadEvent();
                    e.EventType = ResumableUploadEventTypeEnum.UploadPartFailed;
                    e.UploadId = uploadCheckPoint.UploadId;
                    e.PartNumber = uploadPart.PartNumber;
                    param.eventHandler(this, e);
                }

            }
            catch (Exception ex)
            {
                partResultUpload.IsFailed = true;
                ObsException exception = new ObsException(ex.Message, ex);
                exception.ErrorType = ErrorType.Sender;
                partResultUpload.Exception = exception;
                if (param.eventHandler != null)
                {
                    ResumableUploadEvent e = new ResumableUploadEvent();
                    e.EventType = ResumableUploadEventTypeEnum.UploadPartFailed;
                    e.UploadId = uploadCheckPoint.UploadId;
                    e.PartNumber = uploadPart.PartNumber;
                    param.eventHandler(this, e);
                }
            }
            finally
            {
                param.partResultUpload = partResultUpload;
                param.executeEvent.Set();
            }

        }

        /// <summary>
        /// 多线程并发上传段
        /// </summary>
        private IList<PartResultUpload> ResumableUploadBegin(ResumableUploadRequest resumableUploadRequest, UploadCheckPoint uploadCheckPoint, out TransferStreamManager mgr, ResumableUploadTypeEnum uploadType)
        {
            //分段的上传结果列表
            IList<PartResultUpload> partResultsUpload = new List<PartResultUpload>();
            IList<UploadPart> uploadParts = new List<UploadPart>();
            long transferredBytes = 0;
            foreach (var uploadPart in uploadCheckPoint.UploadParts)
            {
                if (uploadPart.IsCompleted)
                {
                    transferredBytes += uploadPart.Size;
                    PartResultUpload result = new PartResultUpload();
                    result.IsFailed = false;
                    partResultsUpload.Add(result);
                }
                else
                {
                    uploadParts.Add(uploadPart);
                }
            }

            if (uploadParts.Count < 1)
            {
                mgr = null;
                return partResultsUpload;
            }

            if (resumableUploadRequest.UploadProgress != null)
            {
                //UploadFile方式：支持多线程并发上传，需采用线程安全方式
                if (uploadType == ResumableUploadTypeEnum.UploadFile)
                {
                    if (resumableUploadRequest.ProgressType == ProgressTypeEnum.ByBytes)
                    {
                        mgr = new ThreadSafeTransferStreamByBytes(this, resumableUploadRequest.UploadProgress,
                        uploadCheckPoint.FileStatus.Size, transferredBytes, resumableUploadRequest.ProgressInterval);
                    }
                    else
                    {
                        mgr = new ThreadSafeTransferStreamBySeconds(this, resumableUploadRequest.UploadProgress,
                        uploadCheckPoint.FileStatus.Size, transferredBytes, resumableUploadRequest.ProgressInterval);
                    }
                }
                
                else
                {
                    if (resumableUploadRequest.ProgressType == ProgressTypeEnum.ByBytes)
                    {
                        //UploadStream：仅支持单线程上传，采用普通方式，提升性能
                        mgr = new TransferStreamByBytes(resumableUploadRequest.Sender, resumableUploadRequest.UploadProgress,
                        uploadCheckPoint.FileStatus.Size, transferredBytes, resumableUploadRequest.ProgressInterval);
                    }
                    else
                    {
                        mgr = new ThreadSafeTransferStreamBySeconds(resumableUploadRequest.Sender, resumableUploadRequest.UploadProgress,
                        uploadCheckPoint.FileStatus.Size, transferredBytes, resumableUploadRequest.ProgressInterval);
                    }
                }
            }
            else
            {
                mgr = null;
            }

            int taskNum = 1;
            if (uploadType == ResumableUploadTypeEnum.UploadFile)
            {
                taskNum = Math.Min((resumableUploadRequest as UploadFileRequest).TaskNum, uploadParts.Count);
            }
            
            ManualResetEvent[] events = new ManualResetEvent[taskNum];
            UploadPartExcuteParam[] executeParams = new UploadPartExcuteParam[taskNum];
            for (int i = 0; i < taskNum; i++)
            {
                UploadPartExcuteParam param = new UploadPartExcuteParam();
                param.uploadType = uploadType;
                param.uploadPart = uploadParts[i];
                param.uploadCheckPoint = uploadCheckPoint;
                param.executeEvent = new ManualResetEvent(false);
                param.enableCheckpoint = resumableUploadRequest.EnableCheckpoint;
                param.checkpointFile = resumableUploadRequest.CheckpointFile;
                param.eventHandler = resumableUploadRequest.UploadEventHandler;
                param.mgr = mgr;
                events[i] = param.executeEvent;
                executeParams[i] = param;
                ThreadPool.QueueUserWorkItem(UploadPartExcute, param);
            }

            try
            {
                //继续执行剩下的任务
                while (taskNum < uploadParts.Count)
                {
                    if (uploadCheckPoint.IsUploadAbort)
                    {
                        break;
                    }
                    int finished = WaitHandle.WaitAny(events);
                    UploadPartExcuteParam finishedParam = executeParams[finished];
                    partResultsUpload.Add(finishedParam.partResultUpload);
                    finishedParam.partResultUpload = null;
                    finishedParam.uploadPart = uploadParts[taskNum++];
                    finishedParam.executeEvent.Reset();
                    ThreadPool.QueueUserWorkItem(UploadPartExcute, finishedParam);
                }
            }
            finally
            {
                WaitHandle.WaitAll(events);
                for (int i = 0; i < events.Length; i++)
                {
                    UploadPartExcuteParam finishedParam = executeParams[i];
                    partResultsUpload.Add(finishedParam.partResultUpload);
                    events[i].Close();
                }

            }
            return partResultsUpload;
        }

        /// <summary>
        /// 取消多段上传任务
        /// </summary>
        private void AbortMultipartUpload(UploadCheckPoint uploadCheckPoint)
        {
            try
            {
                AbortMultipartUploadRequest abortRequest = new AbortMultipartUploadRequest
                {
                    BucketName = uploadCheckPoint.BucketName,
                    ObjectKey = uploadCheckPoint.ObjectKey,
                    UploadId = uploadCheckPoint.UploadId,
                };
                this.AbortMultipartUpload(abortRequest);
            }
            catch (ObsException ex)
            {
                LoggerMgr.Warn("Abort multipart upload failed", ex);
            }
        }
        #endregion


        #region DownloadFile
        /// <summary>
        /// 断点续传下载文件。
        /// </summary>
        /// <param name="request">下载文件的请求参数。</param>
        /// <returns>获取对象元数据响应结果。</returns>
        public GetObjectMetadataResponse DownloadFile(DownloadFileRequest request)
        {
            ParameterJudgement(request);
            return DownloadFileExcute(request);
        }

        /// <summary>
        /// 下载文件参数校验
        /// </summary>
        /// <param name="request"></param>
        private void ParameterJudgement(DownloadFileRequest request)
        {
            if (request == null)
            {
                throw new ObsException(Constants.NullRequestMessage, ErrorType.Sender, Constants.NullRequest, "");
            }
            if (string.IsNullOrEmpty(request.BucketName))
            {
                throw new ObsException(Constants.InvalidBucketNameMessage, ErrorType.Sender, Constants.InvalidBucketName, "");
            }
            if (string.IsNullOrEmpty(request.ObjectKey))
            {
                throw new ObsException(Constants.InvalidObjectKeyMessage, ErrorType.Sender, Constants.InvalidObjectKey, "");
            }
            if (string.IsNullOrEmpty(request.DownloadFile))
            {
                request.DownloadFile = Environment.CurrentDirectory + "/" + request.ObjectKey;
            }
            if (request.EnableCheckpoint)
            {
                if (string.IsNullOrEmpty(request.CheckpointFile))
                {
                    request.CheckpointFile = request.DownloadFile + "downloadFile_record";
                }
            }
        }

        /// <summary>
        /// 断点续传下载文件--执行方法
        /// </summary>
        private GetObjectMetadataResponse DownloadFileExcute(DownloadFileRequest downloadFileRequest)
        {
            DownloadCheckPoint downloadCheckPoint = new DownloadCheckPoint();

            GetObjectMetadataResponse response = null;

            //若开启断点续传
            if (downloadFileRequest.EnableCheckpoint)
            {
                bool loadFileFlag = true;//序列化文件加载成功标志位
                bool paraVerifyFlag = true;//参数信息一致性校验标志位
                bool fileVerifyFlag = true;//序列化文件一致性校验标志位
                ObsException obsException = null;
                try
                {
                    //加载序列化记录文件
                    downloadCheckPoint.Load(downloadFileRequest.CheckpointFile);
                }
                //首次下载时序列化文件加载失败
                catch (Exception)
                {
                    loadFileFlag = false;
                }

                //序列化文件加载成功时才进行后续校验
                if (loadFileFlag)
                {
                    //参数信息一致性校验：DownloadFileRequest参数（桶名、对象名、下载文件路径、版本号）与CheckpointFile记录数据的一致性验证
                    if (!(downloadFileRequest.BucketName.Equals(downloadCheckPoint.BucketName)
                    && downloadFileRequest.ObjectKey.Equals(downloadCheckPoint.ObjectKey)
                    && downloadFileRequest.DownloadFile.Equals(downloadCheckPoint.DownloadFile)))
                    {
                        paraVerifyFlag = false;
                    }
                    //若存在版本号，则需进一步验证
                    if (string.IsNullOrEmpty(downloadFileRequest.VersionId))
                    {
                        if (!string.IsNullOrEmpty(downloadCheckPoint.VersionId))
                        {
                            paraVerifyFlag = false;
                        }
                    }
                    else if (!downloadFileRequest.VersionId.Equals(downloadCheckPoint.VersionId))
                    {
                        paraVerifyFlag = false;
                    }

                    //参数信息一致性校验成功时
                    if (paraVerifyFlag)
                    {
                        try
                        {
                            //序列化文件一致性校验：Md5值；临时文件的名字、大小；对象的大小、最后修改时间、Etag值
                            fileVerifyFlag = downloadCheckPoint.IsValid(downloadFileRequest.TempDownloadFile, this);
                        }
                        catch (ObsException ex)
                        {
                            int statusCode = Convert.ToInt32(ex.StatusCode);
                            if(statusCode >= 400 && statusCode < 500)
                            {
                                fileVerifyFlag = false;
                                obsException = ex;
                            }
                            else
                            {
                                throw ex;
                            }
                        }
                    }
                }

                //任一阶段校验失败时
                if (!loadFileFlag || !paraVerifyFlag || !fileVerifyFlag)
                {
                    //删除临时文件
                    if (downloadCheckPoint.TmpFileStatus != null)
                    {
                        if (File.Exists(downloadCheckPoint.TmpFileStatus.TmpFilePath))
                        {
                            File.Delete(downloadCheckPoint.TmpFileStatus.TmpFilePath);
                        }
                    }

                    //删除序列化记录文件
                    if (File.Exists(downloadFileRequest.CheckpointFile))
                    {
                        File.Delete(downloadFileRequest.CheckpointFile);
                    }

                    if(obsException != null)
                    {
                        throw obsException;
                    }

                    //下载文件准备工作
                    response = DownloadFilePrepare(downloadFileRequest, downloadCheckPoint);
                }
            }
            else
            {
                //下载文件准备工作
                response = DownloadFilePrepare(downloadFileRequest, downloadCheckPoint);
            }

            TransferStreamManager mgr = null;
            try
            {
                //开始并发下载分段
                IList<PartResultDown> partResultsDowns = DownloadFileBegin(downloadFileRequest, downloadCheckPoint, out mgr);

                //下载结果校验
                foreach (PartResultDown result in partResultsDowns)
                {
                    //下载失败
                    if (result.IsFailed && result.Exception != null)
                    {
                        //若没有开启断点续传，则删除临时下载文件
                        if (!downloadFileRequest.EnableCheckpoint)
                        {
                            if (File.Exists(downloadCheckPoint.TmpFileStatus.TmpFilePath))
                            {
                                File.Delete(downloadCheckPoint.TmpFileStatus.TmpFilePath);
                            }
                        }
                        //若开启断点续传
                        else if(downloadCheckPoint.IsDownloadAbort)
                        {
                            if (File.Exists(downloadCheckPoint.TmpFileStatus.TmpFilePath))
                            {
                                File.Delete(downloadCheckPoint.TmpFileStatus.TmpFilePath);
                            }
                            if (File.Exists(downloadFileRequest.CheckpointFile))
                            {
                                File.Delete(downloadFileRequest.CheckpointFile);
                            }
                        }
                        //抛出异常
                        throw result.Exception;
                    }
                }
            }
            finally
            {
                mgr?.TransferEnd();
            }


            try
            {
                //重命名临时文件
                Rename(downloadFileRequest.TempDownloadFile, downloadFileRequest.DownloadFile);
            }
            catch (Exception ex)
            {
                //重命名操作失败，删除序列化记录文件
                if (File.Exists(downloadFileRequest.CheckpointFile))
                {
                    File.Delete(downloadFileRequest.CheckpointFile);
                }
                ObsException exception = new ObsException(ex.Message, ex);
                exception.ErrorType = ErrorType.Sender;
                throw exception;
            }

            //若开启断点续传，下载成功后删除序列化记录文件
            if (downloadFileRequest.EnableCheckpoint)
            {
                if (File.Exists(downloadFileRequest.CheckpointFile))
                {
                    File.Delete(downloadFileRequest.CheckpointFile);
                }
            }

            //返回文件下载结果（下载对象的元数据）
            return response == null ? this.GetObjectMetadata(downloadFileRequest, downloadCheckPoint) : response;
        }

        private GetObjectMetadataResponse GetObjectMetadata(DownloadFileRequest downloadFileRequest, DownloadCheckPoint downloadCheckPoint)
        {
            GetObjectMetadataRequest request = new GetObjectMetadataRequest();
            request.BucketName = downloadCheckPoint.BucketName;
            request.ObjectKey = downloadCheckPoint.ObjectKey;
            request.VersionId = downloadCheckPoint.VersionId;
            request.SseCHeader = downloadFileRequest.SseCHeader;
            return this.GetObjectMetadata(request);
        }

        /// <summary>
        /// 下载文件准备工作
        /// </summary>
        /// <param name="downloadFileRequest"></param>
        /// <param name="downloadCheckPoint"></param>
        private GetObjectMetadataResponse DownloadFilePrepare(DownloadFileRequest downloadFileRequest, DownloadCheckPoint downloadCheckPoint)
        {
            downloadCheckPoint.BucketName = downloadFileRequest.BucketName;
            downloadCheckPoint.ObjectKey = downloadFileRequest.ObjectKey;
            downloadCheckPoint.VersionId = downloadFileRequest.VersionId;
            downloadCheckPoint.DownloadFile = downloadFileRequest.DownloadFile;
            GetObjectMetadataResponse response = this.GetObjectMetadata(downloadFileRequest, downloadCheckPoint);
            downloadCheckPoint.ObjectStatus = new ObjectStatus()
            {
                Size = response.ContentLength,
                LastModified = response.LastModified,
                Etag = response.ETag
            };
            downloadCheckPoint.DownloadParts = SplitObject(downloadCheckPoint.ObjectStatus.Size, downloadFileRequest.DownloadPartSize);

            try
            {
                //创建临时文件流，并设置文件大小
                using (FileStream fs = new FileStream(downloadFileRequest.TempDownloadFile, FileMode.Create))
                {
                    fs.SetLength(downloadCheckPoint.ObjectStatus.Size);
                }
            }
            catch (Exception ex)
            {
                ObsException exception = new ObsException(ex.Message, ex);
                exception.ErrorType = ErrorType.Sender;
                throw exception;
            }

            //设置临时文件状态
            downloadCheckPoint.TmpFileStatus = new TmpFileStatus()
            {
                TmpFilePath = downloadFileRequest.TempDownloadFile,
                Size = downloadCheckPoint.ObjectStatus.Size,
                LastModified = File.GetLastWriteTime(downloadFileRequest.TempDownloadFile),
            };

            //若开启断点续传
            if (downloadFileRequest.EnableCheckpoint)
            {
                try
                {
                    downloadCheckPoint.Record(downloadFileRequest.CheckpointFile);
                }
                //若记录序列化文件操作失败
                catch (Exception ex)
                {
                    //删除临时文件
                    if (downloadCheckPoint.TmpFileStatus != null)
                    {
                        if (File.Exists(downloadCheckPoint.TmpFileStatus.TmpFilePath))
                        {
                            File.Delete(downloadCheckPoint.TmpFileStatus.TmpFilePath);
                        }
                    }
                  
                    ObsException exception = new ObsException(ex.Message, ex);
                    exception.ErrorType = ErrorType.Sender;
                    throw exception;
                }
            }
            return response;
        }

        /// <summary>
        /// 根据下载对象的大小和分段大小，计算出分段列表
        /// </summary>
        private List<DownloadPart> SplitObject(long objectSize, long partSize)
        {
            List<DownloadPart> parts = new List<DownloadPart>();

            int partNumber = Convert.ToInt32(objectSize / partSize);

            if (partNumber >= 10000)
            {
                partSize = objectSize %10000 == 0? objectSize /10000 : objectSize/10000 + 1;
                partNumber = Convert.ToInt32(objectSize / partSize);
            }

            if (objectSize % partSize > 0)
                partNumber++;

            for (int i = 0; i < partNumber; i++)
            {
                parts.Add(new DownloadPart()
                {
                    PartNumber = (i + 1),
                    Start = i * partSize,
                    End = (i + 1) * partSize - 1,
                    IsCompleted = false
                });
            }
            if (objectSize % partSize > 0)
                parts[parts.Count - 1].End = objectSize - 1;

            return parts;
        }

        /// <summary>
        /// 下载段的结果
        /// </summary>
        internal class PartResultDown
        {
            /// <summary>
            /// 分段下载是否失败
            /// </summary>
            public bool IsFailed { get; set; }

            /// <summary>
            /// 分段下载异常
            /// </summary>
            public ObsException Exception { get; set; }

        }

        internal class DownloadPartExcuteParam
        {
            internal DownloadPart downloadPart;
            internal DownloadCheckPoint downloadCheckPoint;
            internal PartResultDown partResultDown;
            internal ManualResetEvent executeEvent;
            internal DownloadFileRequest downloadFileRequest;
            internal EventHandler<ResumableDownloadEvent> eventHandler;
            internal TransferStreamManager mgr;
        }

        /// <summary>
        /// 执行范围下载
        /// </summary>
        private void DownloadPartExcute(object state)
        {
            DownloadPartExcuteParam param = state as DownloadPartExcuteParam;
            DownloadCheckPoint downloadCheckPoint = param.downloadCheckPoint;
            DownloadPart downloadPart = param.downloadPart;
            DownloadFileRequest downloadFileRequest = param.downloadFileRequest;

            PartResultDown partResultDown = new PartResultDown();

            try
            {
                if (!downloadCheckPoint.IsDownloadAbort)
                {

                    GetObjectRequest getObjectRequest = new GetObjectRequest()
                    {
                        BucketName = downloadCheckPoint.BucketName,
                        ObjectKey = downloadCheckPoint.ObjectKey,
                        ByteRange = new ByteRange(downloadPart.Start, downloadPart.End),
                        SseCHeader = downloadFileRequest.SseCHeader,
                        VersionId = downloadCheckPoint.VersionId
                    };
                    getObjectRequest.IfMatch = downloadFileRequest.IfMatch;
                    getObjectRequest.IfNoneMatch = downloadFileRequest.IfNoneMatch;
                    getObjectRequest.IfModifiedSince = downloadFileRequest.IfModifiedSince;
                    getObjectRequest.IfUnmodifiedSince = downloadFileRequest.IfUnmodifiedSince;

                    //调用下载对象接口
                    GetObjectResponse getObjectResponse = this.GetObject(getObjectRequest);


                    if(getObjectResponse.OutputStream != null && getObjectResponse.ContentLength > 0)
                    {
                        Stream content = null;
                        try
                        {
                            if (param.mgr != null )
                            {
                                TransferStream stream = new TransferStream(getObjectResponse.OutputStream);
                                stream.BytesReaded += param.mgr.BytesTransfered;
                                stream.StartRead += param.mgr.TransferStart;
                                stream.BytesReset += param.mgr.TransferReset;
                                content = stream;
                            }
                            else
                            {
                                content = getObjectResponse.OutputStream;
                            }

                            //创建用于保存到本地的临时下载文件流
                            using (FileStream output = new FileStream(downloadFileRequest.TempDownloadFile, FileMode.Open, FileAccess.Write, FileShare.ReadWrite,
                                Constants.DefaultBufferSize))
                            {
                                output.Seek(downloadPart.Start, SeekOrigin.Begin);
                                //保存返回流的二进制流
                                byte[] buffer = new byte[Constants.DefaultBufferSize];
                                //将下载的流写到临时下载文件中
                                int bytesRead = 0;

                                while ((bytesRead = content.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    output.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                        finally
                        {
                            if(content != null)
                            {
                                content.Close();
                            }
                        }
                    }

                    //更新异步返回结果PartResultDown的IsFailed字段
                    partResultDown.IsFailed = false;
                    downloadPart.IsCompleted = true;

                    if (downloadFileRequest.EnableCheckpoint)
                    {
                        lock (downloadCheckPoint.downloadlock)
                        {
                            //更新临时下载文件的修改时间
                            downloadCheckPoint.UpdateTmpFile(downloadFileRequest.TempDownloadFile);
                            //将DownloadCheckPoint对象中的数据写到CheckpointFile文件中
                            downloadCheckPoint.Record(downloadFileRequest.CheckpointFile);
                        }
                    }

                    if (param.eventHandler != null)
                    {
                        ResumableDownloadEvent e = new ResumableDownloadEvent();
                        e.EventType = ResumableDownloadEventTypeEnum.DownloadPartSucceed;
                        e.PartNumber = downloadPart.PartNumber;
                        param.eventHandler(this, e);
                    }

                    if (LoggerMgr.IsDebugEnabled)
                    {
                        LoggerMgr.Debug(string.Format("PartNumber {0} is done, Start {1}, End {2}", downloadPart.PartNumber,
                            downloadPart.Start, downloadPart.End));
                    }
                }
                else
                {
                    partResultDown.IsFailed = false;
                }
            }
            //下载段失败
            catch (ObsException ex)
            {
                //若返回4xx状态码，则剩余段也就无需再继续下载了
                if (ex.StatusCode >= HttpStatusCode.BadRequest && ex.StatusCode < HttpStatusCode.InternalServerError)
                {
                    downloadCheckPoint.IsDownloadAbort = true;
                }
                partResultDown.IsFailed = true;
                partResultDown.Exception = ex;
                if (param.eventHandler != null)
                {
                    ResumableDownloadEvent e = new ResumableDownloadEvent();
                    e.EventType = ResumableDownloadEventTypeEnum.DownloadPartFailed;
                    e.PartNumber = downloadPart.PartNumber;
                    param.eventHandler(this, e);
                }
            }
            catch (Exception ex)
            {
                partResultDown.IsFailed = true;
                ObsException exception = new ObsException(ex.Message, ex);
                exception.ErrorType = ErrorType.Sender;
                partResultDown.Exception = exception;
                if (param.eventHandler != null)
                {
                    ResumableDownloadEvent e = new ResumableDownloadEvent();
                    e.EventType = ResumableDownloadEventTypeEnum.DownloadPartFailed;
                    e.PartNumber = downloadPart.PartNumber;
                    param.eventHandler(this, e);
                }
            }
            finally
            {
                param.partResultDown = partResultDown;
                param.executeEvent.Set();
            }

        }


        /// <summary>
        /// 多线程并发下载段
        /// </summary>
        private IList<PartResultDown> DownloadFileBegin(DownloadFileRequest downloadFileRequest, DownloadCheckPoint downloadCheckPoint,
            out TransferStreamManager mgr)
        {
            //文件下载结果（包括下载段的结果列表PartResultsDown和下载对象的元数据ObjectMetadata
            IList<PartResultDown> partResultsDowns = new List<PartResultDown>();
            IList<DownloadPart> downloadParts = new List<DownloadPart>();
            long transferredBytes = 0;
            foreach (var partResultDown in downloadCheckPoint.DownloadParts)
            {
                if (partResultDown.IsCompleted)
                {
                    PartResultDown result = new PartResultDown();
                    result.IsFailed = false;
                    partResultsDowns.Add(result);
                    transferredBytes += (partResultDown.End - partResultDown.Start) + 1;
                }
                else
                {
                    downloadParts.Add(partResultDown);
                }
            }

            if (downloadParts.Count < 1)
            {
                mgr = null;
                return partResultsDowns;
            }

            if (downloadFileRequest.DownloadProgress != null)
            {
                if (downloadFileRequest.ProgressType == ProgressTypeEnum.ByBytes)
                {
                    mgr = new ThreadSafeTransferStreamByBytes(this, downloadFileRequest.DownloadProgress,
                   downloadCheckPoint.ObjectStatus.Size, transferredBytes, downloadFileRequest.ProgressInterval);
                }
                else
                {
                    mgr = new ThreadSafeTransferStreamBySeconds(this, downloadFileRequest.DownloadProgress,
                    downloadCheckPoint.ObjectStatus.Size, transferredBytes, downloadFileRequest.ProgressInterval);
                }
            }
            else
            {
                mgr = null;
            }

            int taskNum = Math.Min(downloadFileRequest.TaskNum, downloadParts.Count);
            ManualResetEvent[] events = new ManualResetEvent[taskNum];
            DownloadPartExcuteParam[] executeParams = new DownloadPartExcuteParam[taskNum];
            for (int i = 0; i < taskNum; i++)
            {
                DownloadPartExcuteParam param = new DownloadPartExcuteParam();
                param.downloadPart = downloadParts[i];
                param.downloadCheckPoint = downloadCheckPoint;
                param.executeEvent = new ManualResetEvent(false);
                param.downloadFileRequest = downloadFileRequest;
                param.eventHandler = downloadFileRequest.DownloadEventHandler;
                param.mgr = mgr;
                events[i] = param.executeEvent;
                executeParams[i] = param;
                ThreadPool.QueueUserWorkItem(DownloadPartExcute, param);
            }

            try
            {
                //继续执行剩下的任务
                while (taskNum < downloadParts.Count)
                {
                    if (downloadCheckPoint.IsDownloadAbort)
                    {
                        break;
                    }
                    int finished = WaitHandle.WaitAny(events);
                    DownloadPartExcuteParam finishedParam = executeParams[finished];
                    partResultsDowns.Add(finishedParam.partResultDown);
                    finishedParam.partResultDown = null;
                    finishedParam.downloadPart = downloadParts[taskNum++];
                    finishedParam.executeEvent.Reset();
                    ThreadPool.QueueUserWorkItem(DownloadPartExcute, finishedParam);
                }
            }
            finally
            {
                WaitHandle.WaitAll(events);
                for (int i = 0; i < events.Length; i++)
                {
                    DownloadPartExcuteParam finishedParam = executeParams[i];
                    partResultsDowns.Add(finishedParam.partResultDown);
                    events[i].Close();
                }

            }

            return partResultsDowns;
        }


        /// <summary>
        /// 重命名临时文件
        /// </summary>
        /// <param name="tempDownloadFilePath"></param>
        /// <param name="downloadFilePath"></param>
        private void Rename(string tempDownloadFilePath, string downloadFilePath)
        {
            if (File.Exists(downloadFilePath))
            {
                File.Delete(downloadFilePath);
            }
            if (!File.Exists(tempDownloadFilePath))
            {
                throw new FileNotFoundException("tempDownloadFile '" + tempDownloadFilePath + "' does not exist");
            }
            try
            {
                File.Move(tempDownloadFilePath, downloadFilePath);
            }
            //如果重命名失败，则把临时下载文件的内容，写到下载文件中
            catch (Exception)
            {
                byte[] buffer = new byte[Constants.DefaultBufferSize];
                int bytesRead = 0;

                try
                {
                    using (FileStream tempDownloadStream = new FileStream(tempDownloadFilePath, FileMode.Open))
                    {
                        while ((bytesRead = tempDownloadStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            using (FileStream downloadStream = new FileStream(downloadFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, Constants.DefaultBufferSize))
                            {
                                downloadStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ObsException exception = new ObsException(ex.Message, ex);
                    exception.ErrorType = ErrorType.Sender;
                    throw exception;
                }
                finally
                {
                    //删除临时下载文件
                    File.Delete(tempDownloadFilePath);
                }
            }
        }
        #endregion

    }
}
