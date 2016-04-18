using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models.Response;

namespace XolphinApiDotNet.Responses
{
    public class Request : Base
    {
        public int id { get; set; }
        public string domainName { get; set; }
        public string company { get; set; }
        public DateTime dateOrdered { get; set; }
        public RequestValidation validations { get; set; }
        public List<string> subjectAlternativeNames { get; set; }
        public int years { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string reference { get; set; }
        public string approverFirstName { get; set; }
        public string approverLastName { get; set; }
        public string approverEmail { get; set; }
        public string approverPhone { get; set; }
        public string postbox { get; set; }
        public string kvk { get; set; }
        public Product product 
        {
            get
            {
                return GetEmbedded<Product>("product");
            }
        }
    }
}