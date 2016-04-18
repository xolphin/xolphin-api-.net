using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class Reissue
    {
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
        private string kvk { get; set; }
        private string reference { get; set; }

        public Reissue(string csr, DCVType dcvType)
        {
            this.csr = csr;

            _dcvType = dcvType;

            _subjectAlternativeNames = new List<string>();
        }

        public Reissue AddSubjectAlternativeName(string subjectAlternativeName)
        {
            _subjectAlternativeNames.Add(subjectAlternativeName);
            return this;
        }

        public Reissue AddDcv(RequestDCV dcv)
        {
            this.dcv.Add(dcv);
            return this;
        }

        public Reissue SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public Reissue SetAddress(string address)
        {
            this.address = address;
            return this;
        }

        public Reissue SetZipcode(string zipcode)
        {
            this.zipcode = zipcode;
            return this;
        }

        public Reissue SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public Reissue SetApproverFirstName(string approverFirstName)
        {
            this.approverFirstName = approverFirstName;
            return this;
        }

        public Reissue SetApproverLastName(string approverLastName)
        {
            this.approverLastName = approverLastName;
            return this;
        }

        public Reissue SetApproverEmail(string approverEmail)
        {
            this.approverEmail = approverEmail;
            return this;
        }

        public Reissue SetApproverPhone(string approverPhone)
        {
            this.approverPhone = approverPhone;
            return this;
        }

        public Reissue SetKvk(string kvk)
        {
            this.kvk = kvk;
            return this;
        }

        public Reissue SetReference(string reference)
        {
            this.reference = reference;
            return this;
        }
    }
}