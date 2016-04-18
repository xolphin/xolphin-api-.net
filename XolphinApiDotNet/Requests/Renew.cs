using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models;
using XolphinApiDotNet.Responses;

namespace XolphinApiDotNet.Requests
{
    public class Renew
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
        public string approverPhone { get; set; }
        public string kvk { get; set; }
        public string reference { get; set; }

        public Renew(int product, int years, string csr, DCVType dcvType)
        {
            this.product = product;
            this.years = years;
            this.csr = csr;

            _dcvType = dcvType;

            _subjectAlternativeNames = new List<string>();
        }

        public Renew AddSubjectAlternativeName(string subjectAlternativeName)
        {
            _subjectAlternativeNames.Add(subjectAlternativeName);
            return this;
        }

        public Renew AddDcv(RequestDCV dcv)
        {
            this.dcv.Add(dcv);
            return this;
        }

        public Renew SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public Renew SetDepartment(string department)
        {
            this.department = department;
            return this;
        }

        public Renew SetAddress(string address)
        {
            this.address = address;
            return this;
        }

        public Renew SetZipcode(string zipcode)
        {
            this.zipcode = zipcode;
            return this;
        }

        public Renew SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public Renew SetApproverFirstName(string approverFirstName)
        {
            this.approverFirstName = approverFirstName;
            return this;
        }

        public Renew SetApproverLastName(string approverLastName)
        {
            this.approverLastName = approverLastName;
            return this;
        }

        public Renew SetApproverEmail(string approverEmail)
        {
            this.approverEmail = approverEmail;
            return this;
        }

        public Renew SetApproverPhone(string approverPhone)
        {
            this.approverPhone = approverPhone;
            return this;
        }

        public Renew SetKvk(string kvk)
        {
            this.kvk = kvk;
            return this;
        }

        public Renew SetReference(string reference)
        {
            this.reference = reference;
            return this;
        }
    }
}