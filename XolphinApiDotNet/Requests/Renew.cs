using System;
using System.Collections.Generic;
using XolphinApiDotNet.Models;
using XolphinApiDotNet.Responses;

namespace XolphinApiDotNet.Requests
{
    public class Renew
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

        public Renew(int product, int years, string csr, DCVType dcvType)
        {
            Product = product;
            Years = years;
            CSR = csr;

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
            DCV.Add(dcv);
            return this;
        }

        public Renew SetCompany(string company)
        {
            Company = company;
            return this;
        }

        public Renew SetDepartment(string department)
        {
            Department = department;
            return this;
        }

        public Renew SetAddress(string address)
        {
            Address = address;
            return this;
        }

        public Renew SetZipcode(string zipcode)
        {
            Zipcode = zipcode;
            return this;
        }

        public Renew SetCity(string city)
        {
            City = city;
            return this;
        }

        public Renew SetApproverFirstName(string approverFirstName)
        {
            ApproverFirstName = approverFirstName;
            return this;
        }

        public Renew SetApproverLastName(string approverLastName)
        {
            ApproverLastName = approverLastName;
            return this;
        }

        public Renew SetApproverEmail(string approverEmail)
        {
            ApproverEmail = approverEmail;
            return this;
        }

        public Renew SetApproverPhone(string approverPhone)
        {
            ApproverPhone = approverPhone;
            return this;
        }

        public Renew SetKvk(string kvk)
        {
            KVK = kvk;
            return this;
        }

        public Renew SetReference(string reference)
        {
            Reference = reference;
            return this;
        }

        public Renew SetCertificateChainAlternative(string certificateChainAlternative)
        {
            CertificateChainAlternative = certificateChainAlternative;
            return this;
        }
    }
}