using System;
using System.Collections.Generic;
using OBS;
using OBS.Model;

namespace ObsDemo
{
    /// <summary>
    /// This sample demonstrates how to do bucket-related operations
    /// (such as do bucket ACL/CORS/Lifecycle/Logging/Website/Location/Tagging)
    /// on OBS using the OBS SDK for .NET
    /// </summary>
    class BucketOperationsSample
    {

        private static string endpoint = "https://your-endpoint";
        private static string AK = "*** Provide your Access Key ***";
        private static string SK = "*** Provide your Secret Key ***";

        private static ObsClient client;


        private static string bucketName = "my-obs-bucket-demo";
        private static string objectName = "my-obs-object-key-demo";

        public static void Main(string[] args)
        {

            client = new ObsClient(AK, SK, endpoint);

            //create bucket
            CreateBucket();

            Console.ReadKey();

            //head bucket
            HeadBucket();

            //list buckets
            ListBuckets();

            //list objects
            ListObjects();

            //list objects（multi-version）
            ListVersions();

            //get bucket metadata
            GetBucketMetadata();

            //get bucket location
            GetBucketLocation();

            //get bucket  storageinfo
            GetBucketStorageInfo();

            //set bucket quota
            SetBucketQuota();

            //get bucket quota
            GetBucketQuota();

            //set bucket acl
            SetBucketACL();

            //get buclet acl
            GetBucketACL();

            //set bucket lifecycle
            SetBucketLifecycle();

            //get bucket lifecycle
            GetBucketLifecycle();

            //delete bucket lifecycle
            DeleteBucketLifecycle();

            //set bucket website
            SetBucketWebsite();

            //get bucket website
            GetBucketWebsite();

            //delete bucket website
            DeleteBucketWebsite();

            //set bucket version status
            SetBucketVersioning();

            //get bucket version status
            GetBucketVersioning();

            //set bucket cors
            SetBucketCors();

            //get bucket cors
            GetBucketCors();

            //delete bucket cors
            DeleteBucketCors();

            //set bucket logging
            SetBucketLogging();

            //get bucket logging
            GetBucketLogging();

            //delete bucket logging
            DeleteBucketLogging();

            //set bucket tagging
            SetBucketTagging();

            //get bucket tagging
            GetBucketTagging();

            //delete bucket tagging
            DeleteBucketTagging();

            //set bucket nontification
            SetBucketNotification();

            //get bucket nontification
            GetBucketNotification();

            //delete bucket nontification
            DeleteBucketNotification();

            //list multipart uploads
            ListMultipartUploads();

            //set bucket storage policy
            SetBucketStoragePolicy();

            //get bucket storage policy
            GetBucketStoragePolicy();

            //set bucket policy
            SetBucketPolicy();

            //get bucket policy
            GetBucketPolicy();

            //delete bucket policy
            DeleteBucketPolicy();


            //delete bucket
            DeleteBucket();

            Console.WriteLine("bucket operation end...\n\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }


        #region CreateBucket
        static void CreateBucket()
        {
            try
            {
                CreateBucketRequest request = new CreateBucketRequest()
                {
                    BucketName = bucketName
                };
                CreateBucketResponse response = client.CreateBucket(request);

                Console.WriteLine("Create bucket response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when create a bucket.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region HeadBucket
        static void HeadBucket()
        {
            try
            {
                HeadBucketRequest request = new HeadBucketRequest()
                {
                    BucketName = bucketName
                };
                bool response = client.HeadBucket(request);

                Console.WriteLine("Head bucket response: {0}", response);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when head bucket.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region ListBuckets
        static void ListBuckets()
        {
            try
            {
                ListBucketsRequest request = new ListBucketsRequest();

                ListBucketsResponse response = client.ListBuckets(request);
                foreach (ObsBucket bucket in response.Buckets)
                {
                    Console.WriteLine("Bucket name is : {0}", bucket.BucketName);
                    Console.WriteLine("Bucket creationDate is: {0}", bucket.CreationDate.ToString());
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when list buckets.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucket
        private static void DeleteBucket()
        {
            try
            {
                DeleteBucketRequest request = new DeleteBucketRequest()
                {
                    BucketName = bucketName
                };
                DeleteBucketResponse response = client.DeleteBucket(request);
                Console.WriteLine("Delete bucket response: {0}" + response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete a bucket.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region ListObjects
        static void ListObjects()
        {
            try
            {
                ListObjectsRequest request = new ListObjectsRequest()
                {
                    BucketName = bucketName
                };
                ListObjectsResponse response = client.ListObjects(request);
                Console.WriteLine("Listing Objects response: {0}" + response.StatusCode);
                foreach (ObsObject entry in response.ObsObjects)
                {
                    Console.WriteLine("key = {0} size = {1}", entry.ObjectKey, entry.Size);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when list objects.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region ListVersions
        private static void ListVersions()
        {
            try
            {
                ListVersionsRequest request = new ListVersionsRequest()
                {
                    BucketName = bucketName,
                    MaxKeys = 10,
                    Delimiter = "delimiter",
                    Prefix = "prefix",
                    KeyMarker = "keyMarker"
                };
                ListVersionsResponse response = client.ListVersions(request);
                Console.WriteLine("ListVersions response: {0}", response.StatusCode);

                foreach (ObsObjectVersion objectVersion in response.Versions)
                {
                    Console.WriteLine("ListVersions response Versions Key: {0}", objectVersion.ObjectKey);
                    Console.WriteLine("ListVersions response Versions VersionId: {0}", objectVersion.VersionId);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when list versions.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketMetadata
        private static void GetBucketMetadata()
        {
            try
            {
                List<string> headers = new List<string>();
                headers.Add("x-obs-header");

                GetBucketMetadataRequest request = new GetBucketMetadataRequest()
                {
                    BucketName = bucketName,
                    Origin = "http://www.a.com",
                    AccessControlRequestHeaders = headers,
                };
                GetBucketMetadataResponse response = client.GetBucketMetadata(request);
                Console.WriteLine("GetBucketMetadata response: {0}", response.StatusCode);
                foreach (var header in response.Headers)
                {
                    Console.WriteLine("the header {0}: {1}", header.Key, header.Value);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket metadata.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketLocation
        static void GetBucketLocation()
        {
            try
            {
                GetBucketLocationRequest request = new GetBucketLocationRequest()
                {
                    BucketName = bucketName
                };
                GetBucketLocationResponse response = client.GetBucketLocation(request);

                Console.WriteLine("Get bucket location response: {0}", response.StatusCode);
                Console.WriteLine("Bucket Location: {0}", response.Location);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket location.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketStorageInfo
        private static void GetBucketStorageInfo()
        {
            try
            {
                GetBucketStorageInfoRequest request = new GetBucketStorageInfoRequest()
                {
                    BucketName = bucketName
                };
                GetBucketStorageInfoResponse response = client.GetBucketStorageInfo(request);
                Console.WriteLine("GetBucketStorageInfo response response: " + response.StatusCode);
                Console.WriteLine("Object Number={0}", response.ObjectNumber);
                Console.WriteLine("Size={0}", response.Size);
            }
            catch (ObsException ex)
            {
                Console.WriteLine(string.Format("Exception errorcode: {0}, when get bucket storage info.", ex.ErrorCode));
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketQuota
        private static void SetBucketQuota()
        {
            try
            {
                SetBucketQuotaRequest request = new SetBucketQuotaRequest()
                {
                    BucketName = bucketName,
                    StorageQuota = 0
                };
                SetBucketQuotaResponse response = client.SetBucketQuota(request);
                Console.WriteLine("Set bucket Quota response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket quota.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketQuota
        private static void GetBucketQuota()
        {
            try
            {
                GetBucketQuotaRequest request = new GetBucketQuotaRequest()
                {
                    BucketName = bucketName
                };
                GetBucketQuotaResponse response = client.GetBucketQuota(request);
                Console.WriteLine("Get bucket Quota response: {0}" + response.StatusCode);
                Console.WriteLine("Bucket StorageQuota: {0}", response.StorageQuota);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket quota.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketACL
        static void SetBucketACL()
        {
            try
            {

                Owner owner = new Owner
                {
                    DisplayName = "ownername",
                    Id = "ownerid",
                };


                Grant grant = new Grant
                {

                    Grantee = new CanonicalGrantee()
                    {
                        DisplayName = "granteename",
                        Id = "granteeid",
                    },

                    Permission = PermissionEnum.FullControl,
                };

                List<Grant> Grants = new List<Grant>();
                Grants.Add(grant);
                AccessControlList accessControlList = new AccessControlList
                {
                    Owner = owner,
                    Grants = Grants,
                };

                SetBucketAclRequest request = new SetBucketAclRequest()
                {
                    BucketName = bucketName,
                    AccessControlList = accessControlList
                };

                SetBucketAclResponse response = client.SetBucketAcl(request);

                Console.WriteLine("SetBucketACL response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket acl.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketACL
        static void GetBucketACL()
        {
            try
            {
                GetBucketAclRequest request = new GetBucketAclRequest()
                {
                    BucketName = bucketName
                };
                GetBucketAclResponse response = client.GetBucketAcl(request);
                Console.WriteLine("Get bucket acl response: {0}", response.StatusCode);
                foreach (Grant grant in response.AccessControlList.Grants)
                {
                    Console.WriteLine("Grant permission: {0}", grant.Permission);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine(string.Format("Exception errorcode: {0}, when get bucket acl.", ex.ErrorCode));
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketLifecycle
        private static void SetBucketLifecycle()
        {
            try
            {
                SetBucketLifecycleRequest request = new SetBucketLifecycleRequest()
                {
                    BucketName = bucketName,
                    Configuration = new LifecycleConfiguration(),
                };

                LifecycleRule rule1 = new LifecycleRule();
                rule1.Id = "rule1";
                rule1.Prefix = "prefix";
                rule1.Status = RuleStatusEnum.Enabled;

                rule1.Expiration.Days = 30;

                Transition transition = new Transition()
                {
                    Date = new DateTime(2018, 12, 30, 0, 0, 0),
                    StorageClass = StorageClassEnum.Warm
                };
                rule1.Transitions.Add(transition);

                NoncurrentVersionTransition noncurrentVersionTransition = new NoncurrentVersionTransition()
                {
                    NoncurrentDays = 30,
                    StorageClass = StorageClassEnum.Cold,
                };
                rule1.NoncurrentVersionTransitions.Add(noncurrentVersionTransition);

                rule1.NoncurrentVersionExpiration.NoncurrentDays = 30;

                request.Configuration.Rules.Add(rule1);

                SetBucketLifecycleResponse response = client.SetBucketLifecycle(request);

                Console.WriteLine("Set bucket lifecycle response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket lifecycle.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketLifecycle
        private static void GetBucketLifecycle()
        {
            try
            {
                GetBucketLifecycleRequest request = new GetBucketLifecycleRequest()
                {
                    BucketName = bucketName,
                };
                GetBucketLifecycleResponse response = client.GetBucketLifecycle(request);
                Console.WriteLine("Get bucket lifecycle response: {0}", response.StatusCode);

                foreach (LifecycleRule lifecycleRule in response.Configuration.Rules)
                {
                    Console.WriteLine("Lifecycle rule id: {0}", lifecycleRule.Id);
                    Console.WriteLine("Lifecycle rule prefix: {0}", lifecycleRule.Prefix);
                    Console.WriteLine("Lifecycle rule status: {0}", lifecycleRule.Status);
                    if (null != lifecycleRule.Expiration)
                    {
                        Console.WriteLine("expiration days: {0}", lifecycleRule.Expiration.Days);
                    }
                    if (null != lifecycleRule.NoncurrentVersionExpiration)
                    {
                        Console.WriteLine("NoncurrentVersionExpiration NoncurrentDays: {0}", lifecycleRule.NoncurrentVersionExpiration.NoncurrentDays);
                    }
                    if (null != lifecycleRule.Transitions)
                    {
                        foreach (Transition transition in lifecycleRule.Transitions)
                        {
                            Console.WriteLine("Transition Days: {0}", transition.Days.ToString());
                            Console.WriteLine("Transition StorageClass: {0}", transition.StorageClass);
                        }
                    }
                    if (null != lifecycleRule.NoncurrentVersionTransitions)
                    {
                        foreach (NoncurrentVersionTransition nontransition in lifecycleRule.NoncurrentVersionTransitions)
                        {
                            Console.WriteLine("NoncurrentVersionTransition NoncurrentDays: {0}", nontransition.NoncurrentDays.ToString());
                            Console.WriteLine("NoncurrentVersionTransition StorageClass: {0}", nontransition.StorageClass);
                        }
                    }
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket lifecycle.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketLifecycle
        private static void DeleteBucketLifecycle()
        {
            try
            {
                DeleteBucketLifecycleRequest request = new DeleteBucketLifecycleRequest()
                {
                    BucketName = bucketName,
                };
                DeleteBucketLifecycleResponse response = client.DeleteBucketLifecycle(request);
                Console.WriteLine("Delete bucket lifecycle response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket lifecycle.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketWebsite
        private static void SetBucketWebsite()
        {
            try
            {
                SetBucketWebsiteRequest request = new SetBucketWebsiteRequest();
                request.BucketName = bucketName;
                request.Configuration = new WebsiteConfiguration();

                request.Configuration.IndexDocument = "index.html";

                request.Configuration.ErrorDocument = "error.html";

                RoutingRule routingRule = new RoutingRule();
                routingRule.Redirect = new Redirect();
                routingRule.Redirect.HostName = "www.example.com";
                routingRule.Redirect.HttpRedirectCode = "305";
                routingRule.Redirect.Protocol = ProtocolEnum.Http;
                routingRule.Redirect.ReplaceKeyPrefixWith = "replacekeyprefix";
                routingRule.Condition = new Condition();
                routingRule.Condition.HttpErrorCodeReturnedEquals = "404";
                routingRule.Condition.KeyPrefixEquals = "keyprefix";
                request.Configuration.RoutingRules = new List<RoutingRule>();
                request.Configuration.RoutingRules.Add(routingRule);

                SetBucketWebsiteResponse response = client.SetBucketWebsiteConfiguration(request);
                Console.WriteLine("Set bucket website response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket website.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region  GetBucketWebsite
        private static void GetBucketWebsite()
        {
            try
            {
                GetBucketWebsiteRequest request = new GetBucketWebsiteRequest()
                {
                    BucketName = bucketName
                };
                GetBucketWebsiteResponse response = client.GetBucketWebsite(request);

                Console.WriteLine("GetBucketWebsite response: {0}", response.StatusCode);
                Console.WriteLine("GetBucketWebsite website configuration error document: {0}", response.Configuration.ErrorDocument);
                Console.WriteLine("GetBucketWebsite website configuration index document: {0}", response.Configuration.ErrorDocument);

            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket website.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketWebsite
        private static void DeleteBucketWebsite()
        {
            try
            {
                DeleteBucketWebsiteRequest request = new DeleteBucketWebsiteRequest()
                {
                    BucketName = bucketName
                };
                DeleteBucketWebsiteResponse response = client.DeleteBucketWebsite(request);
                Console.WriteLine("DeleteBucketWebsite response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket website.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketVersioning
        private static void SetBucketVersioning()
        {
            try
            {
                VersioningConfiguration versionConfig = new VersioningConfiguration()
                {
                    Status = VersionStatusEnum.Enabled
                };
                SetBucketVersioningRequest request = new SetBucketVersioningRequest()
                {
                    BucketName = bucketName,
                    Configuration = versionConfig
                };
                SetBucketVersioningResponse response = client.SetBucketVersioning(request);

                Console.WriteLine("PutBucketVersioning response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine(string.Format("Exception errorcode: {0}, when set bucket versioning.", ex.ErrorCode));
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketVersioning
        private static void GetBucketVersioning()
        {
            try
            {
                GetBucketVersioningRequest request = new GetBucketVersioningRequest()
                {
                    BucketName = bucketName
                };
                GetBucketVersioningResponse response = client.GetBucketVersioning(request);

                Console.WriteLine("GetBucketVersioning response: {0}", response.StatusCode);
                Console.WriteLine("GetBucketVersioning version status: {0}", response.Configuration.Status);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket versioning", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketCors
        private static void SetBucketCors()
        {
            try
            {
                CorsConfiguration corsConfig = new CorsConfiguration();

                CorsRule rule = new CorsRule();
                rule.Id = "20180520";
                rule.AllowedOrigins.Add("http://www.a.com");
                rule.AllowedOrigins.Add("http://www.b.com");
                rule.AllowedHeaders.Add("Authorization");
                rule.AllowedMethods.Add(HttpVerb.GET);
                rule.AllowedMethods.Add(HttpVerb.PUT);
                rule.AllowedMethods.Add(HttpVerb.POST);
                rule.AllowedMethods.Add(HttpVerb.DELETE);
                rule.AllowedMethods.Add(HttpVerb.HEAD);
                rule.ExposeHeaders.Add("x-obs-test1");
                rule.ExposeHeaders.Add("x-obs-test2");
                rule.MaxAgeSeconds = 100;

                corsConfig.Rules.Add(rule);

                SetBucketCorsRequest request = new SetBucketCorsRequest()
                {
                    BucketName = bucketName,
                    Configuration = corsConfig,
                };

                SetBucketCorsResponse response = client.SetBucketCors(request);
                Console.WriteLine("SetBucketCors response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine(string.Format("Exception errorcode: {0}, when set bucket cors.", ex.ErrorCode));
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketCors
        private static void GetBucketCors()
        {
            try
            {
                GetBucketCorsRequest request = new GetBucketCorsRequest()
                {
                    BucketName = bucketName
                };
                GetBucketCorsResponse response = client.GetBucketCors(request);

                Console.WriteLine("GetBucketCors response: {0}", response.StatusCode);

                foreach (var rule in response.Configuration.Rules)
                {
                    Console.WriteLine("rule id is: {0}\n", rule.Id);
                    foreach (var alowOrigin in rule.AllowedOrigins)
                    {
                        Console.WriteLine("alowOrigin is: {0}\n", alowOrigin);
                    }
                    foreach (var alowHeader in rule.AllowedHeaders)
                    {
                        Console.WriteLine("alowHeader is: {0}\n", alowHeader);
                    }
                    foreach (var alowMethod in rule.AllowedMethods)
                    {
                        Console.WriteLine("alowMethod is: {0}\n", alowMethod);
                    }
                    foreach (var exposeHeader in rule.ExposeHeaders)
                    {
                        Console.WriteLine("exposeHeader is: {0}\n", exposeHeader);
                    }
                    Console.WriteLine("rule maxAgeSeconds is: {0}\n", rule.MaxAgeSeconds);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine(string.Format("Exception errorcode: {0}, when get bucket cors.", ex.ErrorCode));
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketCors
        private static void DeleteBucketCors()
        {
            try
            {
                DeleteBucketCorsRequest request = new DeleteBucketCorsRequest()
                {
                    BucketName = bucketName
                };
                DeleteBucketCorsResponse response = client.DeleteBucketCors(request);
                Console.WriteLine("Delete bucket cors response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket cors.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketTagging
        private static void SetBucketTagging()
        {
            try
            {
                List<Tag> TagList = new List<Tag>();
                Tag tag1 = new Tag();
                tag1.Key = "tag1";
                tag1.Value = "value1";

                Tag tag2 = new Tag();
                tag2.Key = "tag2";
                tag2.Value = "value2";

                TagList.Add(tag1);
                TagList.Add(tag2);

                SetBucketTaggingRequest request = new SetBucketTaggingRequest()
                {
                    BucketName = bucketName,
                    Tags = TagList
                };

                SetBucketTaggingResponse response = client.SetBucketTagging(request);

                Console.WriteLine("SetBucketTagging response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errocode: {0}, when set bucket tagging.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketTagging
        private static void GetBucketTagging()
        {
            try
            {
                GetBucketTaggingRequest request = new GetBucketTaggingRequest()
                {
                    BucketName = bucketName
                };
                GetBucketTaggingResponse response = client.GetBucketTagging(request);

                Console.WriteLine("Get bucket Tagging response: {0}", response.StatusCode);
                foreach (var tag in response.Tags)
                {
                    Console.WriteLine("Get bucket Tagging response Key: {0}" + tag.Key);
                    Console.WriteLine("Get bucket Tagging response Value:{0} " + tag.Value);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket tagging.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketTagging
        private static void DeleteBucketTagging()
        {
            try
            {
                DeleteBucketTaggingRequest request = new DeleteBucketTaggingRequest()
                {
                    BucketName = bucketName
                };
                DeleteBucketTaggingResponse response = client.DeleteBucketTagging(request);

                Console.WriteLine("DeleteBucketTagging response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket tagging.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketLogging
        static void SetBucketLogging()
        {
            try
            {

                AccessControlList acl = new AccessControlList();
                acl.Owner = new Owner();
                acl.Owner.Id = "domainId";
                Grant item = new Grant();
                item.Permission = PermissionEnum.FullControl;
                GroupGrantee group = new GroupGrantee();
                group.GroupGranteeType = GroupGranteeEnum.LogDelivery;
                item.Grantee = group;
                acl.Grants.Add(item);

                SetBucketAclRequest setAclRequest = new SetBucketAclRequest
                {
                    BucketName = "targetbucketname",
                    AccessControlList = acl,
                };


                SetBucketAclResponse setAclResponse = client.SetBucketAcl(setAclRequest);
                Console.WriteLine("Set bucket target acl response: {0}", setAclResponse.StatusCode);

                LoggingConfiguration loggingConfig = new LoggingConfiguration();
                loggingConfig.TargetBucketName = "targetbucketname";
                loggingConfig.TargetPrefix = "targetPrefix";

                SetBucketLoggingRequest request = new SetBucketLoggingRequest()
                {
                    BucketName = bucketName,
                    Configuration = loggingConfig
                };

                SetBucketLoggingResponse response = client.SetBucketLogging(request);

                Console.WriteLine("Set bucket logging status: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket logging.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketLogging
        static void GetBucketLogging()
        {
            try
            {
                GetBucketLoggingRequest request = new GetBucketLoggingRequest
                {
                    BucketName = bucketName
                };
                GetBucketLoggingResponse response = client.GetBucketLogging(request);

                Console.WriteLine("TargetBucketName is : " + response.Configuration.TargetBucketName);
                Console.WriteLine("TargetPrefix is : " + response.Configuration.TargetPrefix);
                Console.WriteLine("Get bucket logging response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket logging.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketLogging
        static void DeleteBucketLogging()
        {
            try
            {
                SetBucketLoggingRequest request = new SetBucketLoggingRequest();
                request.BucketName = bucketName;
                request.Configuration = new LoggingConfiguration();
                SetBucketLoggingResponse response = client.SetBucketLogging(request);
                Console.WriteLine("Delete bucket logging response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket logging.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion      

        #region SetBucketNotification
        static void SetBucketNotification()
        {
            try
            {
                FilterRule filterRule1 = new FilterRule();
                filterRule1.Name = FilterNameEnum.Prefix;
                filterRule1.Value = "smn";
                TopicConfiguration topicConfiguration1 = new TopicConfiguration();
                topicConfiguration1.Id = "Id001";
                topicConfiguration1.Topic = "urn:smn:globrg:35667523534:topic1";
                topicConfiguration1.Events.Add(EventTypeEnum.ObjectCreatedAll);
                topicConfiguration1.filterRules = new List<FilterRule>();
                topicConfiguration1.filterRules.Add(filterRule1);

                FilterRule filterRule2 = new FilterRule();
                filterRule2.Name = FilterNameEnum.Suffix;
                filterRule2.Value = ".jpg";
                TopicConfiguration topicConfiguration2 = new TopicConfiguration();
                topicConfiguration2.Id = "Id002";
                topicConfiguration2.Topic = "urn:smn:globrg:35667523535:topic2";
                topicConfiguration2.Events.Add(EventTypeEnum.ObjectRemovedAll);
                topicConfiguration2.filterRules = new List<FilterRule>();
                topicConfiguration2.filterRules.Add(filterRule2);

                NotificationConfiguration notificationConfiguration = new NotificationConfiguration();
                notificationConfiguration.TopicConfigurations = new List<TopicConfiguration>();
                notificationConfiguration.TopicConfigurations.Add(topicConfiguration1);
                notificationConfiguration.TopicConfigurations.Add(topicConfiguration2);

                SetBucketNotificationRequest request = new SetBucketNotificationRequest
                {
                    BucketName = bucketName,
                    Configuration = notificationConfiguration,
                };
                SetBucketNotificationResponse response = client.SetBucketNotification(request);
                Console.WriteLine("Set bucket notification response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket notification.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketNotification
        static void GetBucketNotification()
        {
            try
            {
                GetBucketNotificationRequest request = new GetBucketNotificationRequest
                {
                    BucketName = bucketName
                };
                GetBucketNotificationReponse response = client.GetBucketNotification(request);
                if (response.Configuration.TopicConfigurations.Count > 0)
                {
                    foreach (var topicConfig in response.Configuration.TopicConfigurations)
                    {
                        Console.WriteLine("ID is : {0}", topicConfig.Id);
                        Console.WriteLine("Topic is : {0}", topicConfig.Topic);
                        foreach (var Event in topicConfig.Events)
                        {
                            Console.WriteLine("Event is : {0}", Event);
                        }
                        foreach (var filterRule in topicConfig.filterRules)
                        {
                            Console.WriteLine("Name is : {0}", filterRule.Name);
                            Console.WriteLine("Value is : {0}", filterRule.Value);
                        }
                    }
                }
                Console.WriteLine("Get bucket notification  response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket notification.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketNotification
        static void DeleteBucketNotification()
        {
            try
            {
                NotificationConfiguration notificationConfig = new NotificationConfiguration();
                SetBucketNotificationRequest request = new SetBucketNotificationRequest
                {
                    BucketName = bucketName,
                    Configuration = notificationConfig
                };
                SetBucketNotificationResponse response = client.SetBucketNotification(request);
                Console.WriteLine("Delete bucket notification  response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket notification.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region ListMultipartUploads
        static void ListMultipartUploads()
        {
            try
            {
                ListMultipartUploadsRequest request = new ListMultipartUploadsRequest()
                {
                    BucketName = bucketName,
                    Delimiter = "delimiter",
                    Prefix = "prefix",
                    KeyMarker = "keymarker",
                    MaxUploads = 10,
                    UploadIdMarker = "uploadidmarker"
                };
                ListMultipartUploadsResponse response = client.ListMultipartUploads(request);
                Console.WriteLine("List multipart uploads response: {0}", response.StatusCode);

                foreach (MultipartUpload multipart in response.MultipartUploads)
                {
                    Console.WriteLine("MultipartUpload object key: {0}", multipart.ObjectKey);
                    Console.WriteLine("MultipartUpload upload id: {0}", multipart.UploadId);
                }
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when list multipart uploads.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketStoragePolicy
        static void SetBucketStoragePolicy()
        {
            try
            {
                SetBucketStoragePolicyRequest request = new SetBucketStoragePolicyRequest()
                {
                    BucketName = bucketName,
                    StorageClass = StorageClassEnum.Standard
                };
                SetBucketStoragePolicyResponse response = client.SetBucketStoragePolicy(request);

                Console.WriteLine("Set bucket storage policy response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket storage policy.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketStoragePolicy
        static void GetBucketStoragePolicy()
        {
            try
            {
                GetBucketStoragePolicyRequest request = new GetBucketStoragePolicyRequest()
                {
                    BucketName = bucketName,
                };
                GetBucketStoragePolicyResponse response = client.GetBucketStoragePolicy(request);

                Console.WriteLine("Get bucket storage policy response: {0}", response.StatusCode);
                Console.WriteLine("Bucket DefaultStorageClass: {0}", response.StorageClass.ToString());
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when get bucket storage policy.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region SetBucketPolicy
        static void SetBucketPolicy()
        {
            try
            {
                SetBucketPolicyRequest request = new SetBucketPolicyRequest()
                {
                    BucketName = bucketName,
                    ContentMD5 = "md5",
                    Policy = "policy"
                };
                SetBucketPolicyResponse response = client.SetBucketPolicy(request);

                Console.WriteLine("Set bucket policy response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket policy.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region GetBucketPolicy
        static void GetBucketPolicy()
        {
            try
            {
                GetBucketPolicyRequest request = new GetBucketPolicyRequest()
                {
                    BucketName = bucketName,
                };
                GetBucketPolicyResponse response = client.GetBucketPolicy(request);

                Console.WriteLine("Get bucket policy response: {0}", response.StatusCode);
                Console.WriteLine("Bucket policy: {0}", response.Policy);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when set bucket policy.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion

        #region DeleteBucketPolicy
        static void DeleteBucketPolicy()
        {
            try
            {
                DeleteBucketPolicyRequest request = new DeleteBucketPolicyRequest()
                {
                    BucketName = bucketName,
                };
                DeleteBucketPolicyResponse response = client.DeleteBucketPolicy(request);

                Console.WriteLine("Delete bucket policy response: {0}", response.StatusCode);
            }
            catch (ObsException ex)
            {
                Console.WriteLine("Exception errorcode: {0}, when delete bucket policy.", ex.ErrorCode);
                Console.WriteLine("Exception errormessage: {0}", ex.ErrorMessage);
            }
        }
        #endregion



    }

}