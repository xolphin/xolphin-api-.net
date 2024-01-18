using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Certificate : Base
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public List<string> SubjectAlternativeNames { get; set; }
        private dynamic dateIssued;
        public dynamic DateIssued   // property
        {
            get
            {
                var obj = JsonConvert.SerializeObject(dateIssued);
                var result = JsonConvert.DeserializeObject(obj);
                var parseDate = result;
                return dateIssued;
            }   // get method
            set
            {
                var obj = JsonConvert.SerializeObject(value.ToString());
                var result = JsonConvert.DeserializeObject(obj);
                var parseDate = result;
                dateIssued = parseDate;
            }  // set method
        }
        private dynamic dateExpired;
        public dynamic DateExpired   // property
        {
            get
            {
                var obj = JsonConvert.SerializeObject(dateExpired);
                var result = JsonConvert.DeserializeObject(obj);
                var parseDate = result;
                return dateExpired;
            }   // get method
            set
            {
                var obj = JsonConvert.SerializeObject((value ?? "").ToString());
                var result = JsonConvert.DeserializeObject(obj);
                var parseDate = result;
                dateExpired = parseDate;
            }  // set method
        }
        private dynamic dateSubscriptionExpired;
        public dynamic DateSubscriptionExpired   // property
        {
            get
            {
                var obj = JsonConvert.SerializeObject(dateSubscriptionExpired);
                var result = JsonConvert.DeserializeObject(obj);
                var parseDate = result;
                return dateSubscriptionExpired;
            }   // get method
            set
            {
                var obj = JsonConvert.SerializeObject((value ?? "").ToString());
                var result = JsonConvert.DeserializeObject(obj);
                var parseDate = result;
                dateSubscriptionExpired = parseDate;
            }  // set method
        }
        public string Company { get; set; }
        public string CustomerId { get; set; }
        public Product Product
        {
            get
            {
                return GetEmbedded<Product>("product");
            }
        }
    }
}