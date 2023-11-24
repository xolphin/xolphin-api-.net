﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using XolphinApiDotNet.Requests;
using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Endpoint
{
    public class Request
    {
        private Client client;

        public Request(Client client) 
        {
            this.client = client;
        }

        public List<Responses.Request> All(int batchSize=20)
        {
            IEnumerable<Responses.Request> requests = new List<Responses.Request>();

            var param = new Dictionary<string, object>();
            param.Add("page", 1);
            param.Add("limit", batchSize);

            var result = client.Get<Responses.AllRequests>("requests", param, ParameterType.QueryString);

            if (!result.isError())
            {
                requests = result.Requests;
                while (result.Page < result.Pages)
                {
                    param["page"] = result.Page + 1;
                    result = client.Get<Responses.AllRequests>("requests", param, ParameterType.QueryString);
                    if (result.isError()) break;
                    requests = requests.Union(result.Requests);
                }
            }

            return requests.ToList();
        }

        public Responses.Request Get(int id)
        {
            return client.Get<Responses.Request>("requests/{id}", "id", id, ParameterType.UrlSegment);
        }

        public Responses.Request Send(Requests.Request request)
        {
            return client.PostBody<Responses.Request>("requests", request);
        }

        public Responses.Base Upload(int id, Requests.UploadDocument uploadDocument)
        {
            return client.PostFile<Responses.Base>("requests/" + id + "/upload-document", uploadDocument);
        }

        public Responses.Base RetryDCV(int id, Requests.DCV dcv)
        {
            return client.PostBody<Responses.Base>("requests/" + id + "/retry-dcv", dcv);
        }

        [Obsolete("use SubscribeComodoSA instead")]
        public Responses.Base Subscribe(int id, Requests.ComodoSA comodoSA)
        {
            return client.PostBody<Responses.Base>("requests/" + id + "/sa ", comodoSA);
        }

        public Responses.Base ScheduleValidationCall(int id, DateTime dateTime,ValidationCall validationCall = null)
        {
            var formattedDateTime = new Models.Request.FormattedDateTime(dateTime);
            if (validationCall == null) 
            {
                validationCall = new XolphinApiDotNet.Requests.ValidationCall();
            }
            validationCall.SetId(id);
            validationCall.SetDate(formattedDateTime.Date);
            validationCall.SetTime(formattedDateTime.Time);
            return client.PostBody<Responses.Base>("requests/" + id + "/schedule-validation-call", validationCall);
        }

        public Responses.AllNotes GetNotes(int id)
        {
            return client.Get<Responses.AllNotes>("requests/{id}/notes", "id", id, ParameterType.UrlSegment);
        }

        public Responses.Base SendNote(int id, Requests.NoteSend note)
        {
            return client.PostBody<Responses.Base>("requests/" + id + "/notes", note);
        }

        public Responses.Base SubscribeComodoSA(int id, Requests.ComodoSA comodoSA)
        {
            return client.PostBody<Responses.Base>("requests/" + id + "/sa", comodoSA);
        }
    }
}