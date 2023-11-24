using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class Reissue
    {
        public string CSR { get; private set; }
        private DCVType _dcvType;
        public string DCVType
        {
            get
            {
                return _dcvType.ToString().ToUpperInvariant();
            }
        }
        private List<string> _subjectAlternativeNames;
        public string SubjectAlternativeNames
        {
            get
            {
                return (_subjectAlternativeNames != null) ? string.Join(",", _subjectAlternativeNames) : String.Empty;
            }
        }
        public List<RequestDCV> DCV { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }        
        public string ApproverFirstName { get; set; }
        public string ApproverLastName { get; set; }
        public string ApproverEmail { get; set; }
        public string ApproverPhone { get; set; }
        public string ApproverRepresentativeFirstName { get; set; }
        public string ApproverRepresentativeLastName { get; set; }
        public string ApproverRepresentativeEmail { get; set; }
        public string ApproverRepresentativePhone { get; set; }
        public string ApproverRepresentativePosition { get; set; }        
        public string KVK { get; set; }
        public string Reference { get; set; }

        public Reissue(string csr, DCVType dcvType)
        {
            CSR = csr;

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
            DCV.Add(dcv);
            return this;
        }

        public Reissue SetCompany(string company)
        {
            Company = company;
            return this;
        }

        public Reissue SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public Reissue SetZipcode(string zipcode)
        {
            Zipcode = zipcode;
            return this;
        }

        public Reissue SetCity(string city)
        {
            City = city;
            return this;
        }

        public Reissue SetApproverFirstName(string approverFirstName)
        {
            ApproverFirstName = approverFirstName;
            return this;
        }

        public Reissue SetApproverLastName(string approverLastName)
        {
            ApproverLastName = approverLastName;
            return this;
        }

        public Reissue SetApproverEmail(string approverEmail)
        {
            ApproverEmail = approverEmail;
            return this;
        }

        public Reissue SetApproverPhone(string approverPhone)
        {
            ApproverPhone = approverPhone;
            return this;
        }
        public Reissue SetApproverRepresentativeFirstName(string approverRepresentativeFirstName)
        {
            ApproverRepresentativeFirstName = approverRepresentativeFirstName;
            return this;
        }

        public Reissue SetApproverRepresentativeLastName(string approverRepresentativeLastName)
        {
            ApproverRepresentativeLastName = approverRepresentativeLastName;
            return this;
        }

        public Reissue SetApproverRepresentativeEmail(string approverRepresentativeEmail)
        {
            ApproverRepresentativeEmail = approverRepresentativeEmail;
            return this;
        }

        public Reissue SetApproverRepresentativePhone(string approverRepresentativePhone)
        {
            ApproverRepresentativePhone = approverRepresentativePhone;
            return this;
        }

        public Reissue SetApproverRepresentativePosition(string approverRepresentativePosition)
        {
            ApproverRepresentativePosition = approverRepresentativePosition;
            return this;
        }

        public Reissue SetProvince(string province)
        {
            Province = province;
            return this;
        } 
        
        public Reissue SetCountry(string country)
        {
            Country = country;
            return this;
        }        

        public Reissue SetKvk(string kvk)
        {
            KVK = kvk;
            return this;
        }

        public Reissue SetReference(string reference)
        {
            Reference = reference;
            return this;
        }
    }
}