using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private string _userName;
        private string _password;
        private string _customUserAgent;
        private string _uri;

        public Client(string userName, string password, string customUserAgent = "Base")
        {
            _userName = userName;
            _password = password;
            _customUserAgent = customUserAgent;
            _uri = BASE_URI;
        }

        public void TestMode(bool mode)
        {
            if (mode)
            {
                _uri = BASE_TEST_URI;
            }else
            {
                _uri = BASE_URI;
            }
        }

        internal T Get<T>(string method, string paramName, object paramValue, ParameterType paramType) where T : new()
        {
            var request = new RestRequest();
            request.AddParameter(paramName, paramValue, paramType);
            request.Resource = method;
            request.Method = Method.GET;

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
            request.Method = Method.GET;

            return Execute<T>(request);
        }

        internal T PostBody<T>(string method, object param) where T : Base, new()
        {
            var request = PreparePost(method);
            request.JsonSerializer = new PropertySerializer();
            request.AddBody(param);

            return Execute<T>(request);
        }

      
        internal T PostSingle<T>(string method, string paramName, object paramValue) where T : Base, new()
        {
            var request = PreparePost(method);
            request.AddParameter(paramName, paramValue);

            return Execute<T>(request);
        }



        internal T PostFile<T>(string method, Requests.UploadDocument document) where T : Base, new()
        {
            var request = PreparePost(method);
            request.Files.Add(FileParameter.Create("document", document.Document, document.Name, "application/pdf"));
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

        private RestClient PrepareClient(string userName, string password, string uri, int version)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(string.Format(uri, version));
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            client.UserAgent = "Xolphin .NET lib v1.8.4" + "/" + _customUserAgent;
           
            return client;
        }

        private RestRequest PreparePost(string method)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            request.Resource = method;
           
            return request;
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = PrepareClient(_userName, _password, _uri, VERSION);
            var response = client.Execute<T>(request);            

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
            var client = PrepareClient(_userName, _password, _uri, VERSION);
            var response = client.Execute(request);

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
