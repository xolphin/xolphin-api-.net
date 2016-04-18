using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class Request
    {
        public int product { get; private set; }
        public int years { get; private set; }
        public string csr { get; private set; }
        private DCVType _dcvType;
        public string dcvType
        {
            get
            {
                return _dcvType.ToString().ToUpperInvariant();
            }
        }
        private List<string> _subjectAlternativeNames;
        public string subjectAlternativeNames
        {
            get
            {
                return (_subjectAlternativeNames != null) ? string.Join(",", _subjectAlternativeNames) : String.Empty;
            }
        }
        public List<RequestDCV> dcv { get; set; }
        public string company { get; set; }
        public string department { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string approverFirstName { get; set; }
        public string approverLastName { get; set; }
        public string approverEmail { get; set; }
        private string approverPhone { get; set; }
        public string kvk { get; set; }
        public string reference { get; set; }

        public Request(int product, int years, string csr, DCVType dcvType) 
        {
            this.product = product;
            this.years = years;
            this.csr = csr;

            _dcvType = dcvType;

            _subjectAlternativeNames = new List<string>();
        }

        public Request AddSubjectAlternativeName(string subjectAlternativeName)
        {
            _subjectAlternativeNames.Add(subjectAlternativeName);
            return this;
        }

        public Request AddDcv(RequestDCV dcv)
        {
            this.dcv.Add(dcv);
            return this;
        }

        public Request SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public Request SetDepartment(string department)
        {
            this.department = department;
            return this;
        }

        public Request SetAddress(string address)
        {
            this.address = address;
            return this;
        }

        public Request SetZipcode(string zipcode)
        {
            this.zipcode = zipcode;
            return this;
        }

        public Request SetСity(string city)
        {
            this.city = city;
            return this;
        }

        public Request SetApproverFirstName(string approverFirstName)
        {
            this.approverFirstName = approverFirstName;
            return this;
        }

        public Request SetApproverLastName(string approverLastName)
        {
            this.approverLastName = approverLastName;
            return this;
        }

        public Request SetApproverEmail(string approverEmail)
        {
            this.approverEmail = approverEmail;
            return this;
        }

        public Request SetApproverPhone(string approverPhone)
        {
            this.approverPhone = approverPhone;
            return this;
        }

        public Request SetKvk(string kvk)
        {
            this.kvk = kvk;
            return this;
        }

        public Request SetReference(string reference)
        {
            this.reference = reference;
            return this;
        }
    }
}