using RestSharp;
using System.Collections.Generic;
using System.Linq;
using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Endpoint
{
    public class Certificate
    {
        private Client client;

        public Certificate(Client client)
        {
            this.client = client;
        }

        public List<Responses.Certificate> All()
        {
            IEnumerable<Responses.Certificate> certificates = new List<Responses.Certificate>();

            var result = client.Get<Responses.Certificates>("certificates", "page", 1, ParameterType.QueryString);

            if (!result.isError())
            {
                certificates = result.certificates;
                while (result.page < result.pages)
                {
                    result = client.Get<Responses.Certificates>("certificates", "page", result.page + 1, ParameterType.QueryString);
                    if (result.isError()) break;
                    certificates = certificates.Union(result.certificates);
                }
            }

            return certificates.ToList();
        }

        public Responses.Certificate Get(int id)
        {
            return client.Get<Responses.Certificate>("certificates/{id}", "id", id, ParameterType.UrlSegment);
        }

        public byte[] Download(int id, Format format = Format.CRT)
        {
            return client.Download("certificates/" + id + "/download", format);
        }

        public Responses.Request Reissue(int id, Requests.Reissue request)
        {
            return client.PostBody<Responses.Request>("certificates/" + id + "/reissue", request);
        }

        public Responses.Request Renew(int id, Requests.Renew request)
        {
            return client.PostBody<Responses.Request>("certificates/" + id + "/renew", request);
        }

        public Responses.Base Cancel(int id, Requests.CancelSettings cancelSettings)
        {
            return client.PostBody<Responses.Base>("certificates/" + id + "/cancel", cancelSettings);
        }
    }
}