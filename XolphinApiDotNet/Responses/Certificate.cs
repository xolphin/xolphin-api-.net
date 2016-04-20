using System;
using System.Collections.Generic;

namespace XolphinApiDotNet.Responses
{
    public class Certificate : Base
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public List<string> SubjectAlternativeNames { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DdateExpired { get; set; }
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