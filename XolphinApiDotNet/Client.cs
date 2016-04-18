using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using System.Text;
using XolphinApiDotNet.Models;
using XolphinApiDotNet.Responses;

namespace XolphinApiDotNet
{
    public class Client
    {
        const string BASE_URI = @"https://api.xolphin.com/v{0}/";
        const int VERSION = 1;

        private string _userName;
        private string _password;

        public Client(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        internal T Get<T>(string method, string paramName, object paramValue, ParameterType paramType) where T : new()
        {
            var request = new RestRequest();
            request.AddParameter(paramName, paramValue, paramType);
            request.Resource = method;
            request.Method = Method.GET;

            return Execute<T>(request);
        }

        internal T PostBody<T>(string method, object param) where T : Base, new()
        {
            var request = PreparePost(method);
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
            request.Files.Add(FileParameter.Create("document", document.document, "document.pdf", "application/pdf"));

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
            var client = PrepareClient(_userName, _password, BASE_URI, VERSION);
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

                    message.AppendLine(responseBase.message);
                    if (responseBase.errors != null)
                    {
                        foreach (var error in responseBase.errors)
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

        private class DownloadResult
        {
            public byte[] Data { get; set; }

            public string Message { get; set; }
        }

        private byte[] ExecuteDownload(RestRequest request)
        {
            var client = PrepareClient(_userName, _password, BASE_URI, VERSION);
            var response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<DownloadResult>(response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return result.Data;
            }
            else
            {
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