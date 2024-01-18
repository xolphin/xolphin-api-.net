using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using XolphinApiDotNet.Models;
using XolphinApiDotNet.Responses;
using XolphinApiDotNet.Serializers;

namespace XolphinApiDotNet
{
    public class Client
    {
        const string BASE_URI = @"https://api.xolphin.com/v{0}/";
        const string BASE_TEST_URI = @"https://test-api.xolphin.com/v{0}/";
        const int VERSION = 1;

        private readonly RestClient _client;

        public Client(string userName, string password, string customUserAgent = "Base", bool testMode=false, HttpClient httpClient=null)
        {
            string uri;
            if (testMode)
                uri = BASE_TEST_URI;
            else
                uri = BASE_URI;

            var options = new RestClientOptions()
            {
                BaseUrl = new Uri(string.Format(uri, VERSION)),
                UserAgent = "Xolphin .NET lib v1.8.9" + "/" + customUserAgent,
            };

            if (httpClient == null)
            {
                _client = new RestClient(options);
            }
            else
            {
                _client = new RestClient(httpClient, options);
            }

            _client.Authenticator = new HttpBasicAuthenticator(userName, password);


        }


        internal T Get<T>(string method, string paramName, object paramValue, ParameterType paramType) where T : new()
        {
            var request = new RestRequest();
            request.AddParameter(paramName, paramValue, paramType);
            request.Resource = method;
            request.Method = Method.Get;

            return Execute<T>(request);
        }

        internal T Get<T>(string method, Dictionary<string,object> parameters, ParameterType paramType) where T : new()
        {
            var request = new RestRequest();
            foreach ( var p in parameters)
            {
                request.AddParameter(p.Key, p.Value, paramType);
            }
            
            request.Resource = method;
            request.Method = Method.Get;

            return Execute<T>(request);
        }

        internal T PostBody<T>(string method, object param) where T : Base, new()
        {
            var request = PreparePost(method);

            request.AddBody(param);

            return Execute<T>(request);
        }

      
        internal T PostSingle<T>(string method, string paramName, string paramValue) where T : Base, new()
        {
            var request = PreparePost(method);
            request.AddParameter(paramName, paramValue);            

            return Execute<T>(request);
        }



        internal T PostFile<T>(string method, Requests.UploadDocument document) where T : Base, new()
        {
            
            var request = PreparePost(method);
            request.AddFile("document", document.Document, document.Name, "application/pdf");
            request.AddParameter("description", document.Description);

            return Execute<T>(request);
        }

        internal byte[] Download(string method, Format format)
        {
            var request = new RestRequest();
            request.AddParameter("format", format);
            request.Resource = method;

            return ExecuteDownload(request);
        }


        private RestRequest PreparePost(string method)
        {
            var request = new RestRequest();
            request.Method = Method.Post;
            request.RequestFormat = DataFormat.Json;
            request.Resource = method;
           
            return request;
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);            

            if (response.ErrorException != null || response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                if (response.Data == null)
                {
                    throw new ApplicationException(response.Content, response.ErrorException);
                }

                Base responseBase = response.Data as Base;
                if (responseBase != null)
                {
                    StringBuilder message = new StringBuilder();

                    message.AppendLine(responseBase.Message);
                    if (responseBase.Errors != null)
                    {
                        foreach (var error in responseBase.Errors)
                        {
                            message.AppendLine(error.Key);
                            foreach (var errorInternal in error.Value)
                            {
                                message.AppendLine(errorInternal);
                            }
                        }
                    }
                    throw new ApplicationException(message.ToString());
                }
            }

            return response.Data;
        }

        private byte[] ExecuteDownload(RestRequest request)
        {
            var response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.RawBytes;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<Base>(response.Content);
                throw new ApplicationException(result.Message);
            }
        }

        public Endpoint.Request Request
        {
            get
            {
                return new Endpoint.Request(this);
            }
        }

        public Endpoint.Certificate Certificate
        {
            get
            {
                return new Endpoint.Certificate(this);
            }
        }

        public Endpoint.Support Support
        {
            get
            {
                return new Endpoint.Support(this);
            }
        }
    }
}
