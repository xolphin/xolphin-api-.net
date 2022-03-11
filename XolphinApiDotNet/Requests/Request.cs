using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models;

namespace XolphinApiDotNet.Requests
{
    public class Request
    {
        public int Product { get; private set; }
        public int Years { get; private set; }
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
        public string ApproverFirstName { get; set; }
        public string ApproverLastName { get; set; }
        public string ApproverEmail { get; set; }
        public string ApproverPhone { get; set; }
        public string KVK { get; set; }
        public string Reference { get; set; }
        public string CertificateChainAlternative { get; set; }
        public string Language { get; set; }
        public bool DisableFreeSan { get; set; }

        public Request(int product, int years, string csr, DCVType dcvType) 
        {
            Product = product;
            Years = years;
            CSR = csr;

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
            DCV.Add(dcv);
            return this;
        }

        public Request SetCompany(string company)
        {
            Company = company;
            return this;
        }

        public Request SetDepartment(string department)
        {
            Department = department;
            return this;
        }

        public Request SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public Request SetZipcode(string zipcode)
        {
            Zipcode = zipcode;
            return this;
        }

        public Request SetСity(string city)
        {
            City = city;
            return this;
        }

        public Request SetApproverFirstName(string approverFirstName)
        {
            ApproverFirstName = approverFirstName;
            return this;
        }

        public Request SetApproverLastName(string approverLastName)
        {
            ApproverLastName = approverLastName;
            return this;
        }

        public Request SetApproverEmail(string approverEmail)
        {
            ApproverEmail = approverEmail;
            return this;
        }

        public Request SetApproverPhone(string approverPhone)
        {
            ApproverPhone = approverPhone;
            return this;
        }

        public Request SetKvk(string kvk)
        {
            KVK = kvk;
            return this;
        }

        public Request SetReference(string reference)
        {
            Reference = reference;
            return this;
        }

        public Request SetCertificateChainAlternative(string certificateChainAlternative = null)
        {
            CertificateChainAlternative = certificateChainAlternative;
            return this;
        }

        public Request SetLanguage(string language)
        {
            Language = language;
            return this;
        }

        public Request SetDisableFreeSan(bool disableFreeSan)
        {
            DisableFreeSan = disableFreeSan;
            return this;
        }
    }
}