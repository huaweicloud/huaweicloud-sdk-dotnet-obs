using System;
using OBS.Model;
using OBS;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace ObsDemo
{
    /// <summary>
    /// This sample demonstrates how to do common operations in temporary signature
    /// way on OBS using the OBS SDK for .NET.
    /// </summary>
    class TemporarySignatureSample
    {

        private static string endpoint = "https://your-endpoint";
        private static string AK = "*** Provide your Access Key ***";
        private static string SK = "*** Provide your Secret Key ***";

        private static ObsClient client;

        private static string bucketName = "my-obs-bucket-demo";
        private static string objectKey = "my-obs-object-key-demo";


        public static void Main(string[] args)
        {
            // Constructs a obs client instance with your account for accessing OBS
            ObsConfig config = new ObsConfig();
            config.Endpoint = endpoint;
            client = new ObsClient(AK, SK, config);

            // Create bucket
            DoCreateBucket();

            // Set/Get/Delete bucket cors
            DoBucketCorsOperations();

            // Create object
            DoCreateObject();

            // Get object
            DoGetObject();

            // Set/Get object acl
            DoObjectAclOperations();

            // Delete object
            DoDeleteObject();

            // Delete bucket
            //DoDeleteBucket();


            Console.ReadKey();
        }


        private static MethodInfo GetAddHeaderInternal()
        {
            return typeof(WebHeaderCollection).GetMethod("AddInternal", BindingFlags.NonPublic | BindingFlags.Instance,
                            null, new Type[] { typeof(string), typeof(string) }, null);
        }

        private static void GetResponse(HttpVerb method, CreateTemporarySignatureResponse response, String content)
        {

            HttpWebRequest webRequest = WebRequest.Create(response.SignUrl) as HttpWebRequest;
            webRequest.Method = method.ToString().ToUpper();


            foreach (KeyValuePair<string, string> header in response.ActualSignedRequestHeaders)
            {
                GetAddHeaderInternal().Invoke(webRequest.Headers, new object[] { header.Key, header.Value });
                //Console.WriteLine("{0}={1}", header.Key, header.Value);
            }

            if (!string.IsNullOrEmpty(content))
            {
                webRequest.SendChunked = true;
                webRequest.AllowWriteStreamBuffering = false;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(content);
                    requestStream.Write(buffer, 0, buffer.Length);
                }
            }


            HttpWebResponse webResponse = null;
            try
            {
                webResponse = webRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                webResponse = ex.Response as HttpWebResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            if(webResponse != null)
            {
                
                if (Convert.ToInt32(webResponse.StatusCode) < 300)
                {
                    Console.WriteLine("Do action successfully with Response Code:" + Convert.ToInt32(webResponse.StatusCode));
                }
                using (MemoryStream dest = new MemoryStream())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            dest.Write(buffer, 0, bytesRead);
                        }

                    }
                    Console.WriteLine("Response Content:");
                    Console.WriteLine(Encoding.UTF8.GetString(dest.ToArray()));
                }
            }

        }

        private static void GetResponse(HttpVerb method, CreateTemporarySignatureResponse response)
        {
            GetResponse(method, response, null);
        }

        private static void DoDeleteBucket()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.Method = HttpVerb.DELETE;
            request.Expires = 3600;
            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Deleting bucket using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response);
        }

        private static void DoDeleteObject()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            request.Method = HttpVerb.DELETE;
            request.Expires = 3600;
            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Deleting object using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response);
        }

        private static void DoObjectAclOperations()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            request.Method = HttpVerb.PUT;
            request.Expires = 3600;
            request.SubResource = SubResourceEnum.Acl;
            request.Headers.Add("x-obs-acl", "public-read");
            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Setting object ACL to public-read using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response);



            request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            request.Method = HttpVerb.GET;
            request.Expires = 3600;
            request.SubResource = SubResourceEnum.Acl;
            response = client.CreateTemporarySignature(request);
            Console.WriteLine("Getting object ACL using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response);


        }

        private static void DoGetObject()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            request.Method = HttpVerb.GET;
            request.Expires = 3600;
            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Getting object using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response);
        }

        private static void DoCreateObject()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.ObjectKey = objectKey;
            request.Method = HttpVerb.PUT;
            request.Expires = 3600;
            request.Headers.Add("Content-Type", "text/plain");
            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Createing object using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response, "Hello OBS");
        }

        private static void DoBucketCorsOperations()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.Method = HttpVerb.PUT;
            request.Expires = 3600;
            request.SubResource = SubResourceEnum.Cors;
            request.Headers.Add("Content-Type", "application/xml");
            String requestXml = "<CORSConfiguration><CORSRule><AllowedMethod>GET</AllowedMethod><AllowedOrigin>*</AllowedOrigin><AllowedHeader>*</AllowedHeader></CORSRule></CORSConfiguration>";

            request.Headers.Add("Content-MD5", Convert.ToBase64String(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(requestXml))));

            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Setting bucket CORS using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response, requestXml);

            request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.Method = HttpVerb.GET;
            request.Expires = 3600;
            request.SubResource = SubResourceEnum.Cors;
            response = client.CreateTemporarySignature(request);
            Console.WriteLine("Getting bucket CORS using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            GetResponse(request.Method, response);
        }

        private static void DoCreateBucket()
        {
            CreateTemporarySignatureRequest request = new CreateTemporarySignatureRequest();
            request.BucketName = bucketName;
            request.Method = HttpVerb.PUT;
            request.Expires = 3600;
            CreateTemporarySignatureResponse response = client.CreateTemporarySignature(request);
            Console.WriteLine("Creating bucket using temporary signature url:");
            Console.WriteLine("\t" + response.SignUrl);
            string location = "your location";
            String requestXml = "<CreateBucketConfiguration><Location>" + location + "</Location></CreateBucketConfiguration>";
            GetResponse(request.Method, response);
        }
    }

}
