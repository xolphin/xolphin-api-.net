using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models.Response;

namespace XolphinApiDotNet.Responses
{
    public class Request : Base
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public string Company { get; set; }
        public DateTime DateOrdered { get; set; }
        public RequestValidation Validations { get; set; }
        public List<string> SubjectAlternativeNames { get; set; }
        public int Years { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Reference { get; set; }
        public string ApproverFirstName { get; set; }
        public string ApproverLastName { get; set; }
        public string ApproverEmail { get; set; }
        public string ApproverPhone { get; set; }
        public string Postbox { get; set; }
        public string KVK { get; set; }
        public Boolean ActionRequired { get; set; }
        public Boolean BrandValidation { get; set; }
        public Product Product 
        {
            get
            {
                return GetEmbedded<Product>("product");
            }
        }
    }
}