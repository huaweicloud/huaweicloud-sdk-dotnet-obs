Version 3.19.7.1
新特性：


资料&demo:


修复问题：
1. 修复ObsClient.CreateTemporarySignature生成操作对象的链接对于含特殊字符对象名时会报错签名不匹配的问题；

-----------------------------------------------------------------------------------

Version 3.19.7
新特性：


资料&demo:


修复问题：
1. 修改异步下载对象接口（ObsClient.EndGetObject）的空指针问题；

-----------------------------------------------------------------------------------

Version 3.1.3
新特性：


资料&demo:


修复问题：
1. 修改上传对象接口（ObsClient.PutObject），在上传本地文件时不使用chunk模式上传，避免服务端不支持chunk模式时出现问题；

-----------------------------------------------------------------------------------

Version 3.1.2

新特性：
1. 桶事件通知接口（ObsClient.SetBucketNotification/ObsClient.GetBucketNotification）新增对函数工作流服务配置和查询的支持；

资料&demo：
1. 开发指南事件通知章节，新增对函数工作流服务配置的介绍；
	

修复问题：
1. 修复创建桶接口（ObsClient.CreateBucket）由于协议协商导致报错信息不准确的问题；
2. 修复示例代码BucketOperationsSample.cs中的错误；

