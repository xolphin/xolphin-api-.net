using RestSharp;
using System;
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

        public List<Responses.Certificate> All(int batchSize=20)
        {
            IEnumerable<Responses.Certificate> certificates = new List<Responses.Certificate>();

            var param = new Dictionary<string, object>();
            param.Add("page", 1);
            param.Add("limit", batchSize);


            var result = client.Get<Responses.AllCertificates>("certificates", param, ParameterType.QueryString);
            

            if (!result.isError())
            {
                certificates = result.Certificates;
                while (result.Page < result.Pages)
                {
                    param["page"] = result.Page + 1;
                    result = client.Get<Responses.AllCertificates>("certificates", param, ParameterType.QueryString);
                    if (result.isError()) break;
                    certificates = certificates.Union(result.Certificates);
                }
            }

            return certificates.ToList();
        }

        public List<Responses.Certificate> GetRecent(TimeSpan maxAge, int batchSize=20)
        {
            var cutOffTime = DateTime.Now - maxAge;
            IEnumerable<Responses.Certificate> certificates = new List<Responses.Certificate>();

            var param = new Dictionary<string, object>();
            param.Add("page", 1);
            param.Add("limit", batchSize);


            var result = client.Get<Responses.AllCertificates>("certificates", param, ParameterType.QueryString);
            

            if (!result.isError())
            {
                certificates = result.Certificates;
                while (result.Page < result.Pages)
                {
                    param["page"] = result.Page + 1;
                    result = client.Get<Responses.AllCertificates>("certificates", param, ParameterType.QueryString);
                    if (result.isError()) break;
                    certificates = certificates.Union(result.Certificates.Where( x => x.DateIssued >= cutOffTime ) );

                    if (result.Certificates.Last().DateIssued < cutOffTime)
                        break;
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