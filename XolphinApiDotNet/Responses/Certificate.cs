using System;
using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Certificate : Base
    {
        public int id { get; set; }
        public string domainName { get; set; }
        public List<string> subjectAlternativeNames { get; set; }
        public DateTime dateIssued { get; set; }
        public DateTime dateExpired { get; set; }
        public string company { get; set; }
        public string customerId { get; set; }
        public Product product
        {
            get
            {
                return GetEmbedded<Product>("product");
            }
        }
    }
}