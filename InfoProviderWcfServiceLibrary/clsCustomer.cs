using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InfoProviderWcfServiceLibrary
{
    [DataContract]
    public class clsCustomer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public bool NameStyle { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Suffix { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string SalesPerson { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string Phone { get; set; }
        

        public clsCustomer GetCustomerFromEF(Customer c)
        {
            clsCustomer myC = new clsCustomer();
            myC.CustomerID = c.CustomerID;
            myC.NameStyle = c.NameStyle;
            myC.Title = c.Title;
            myC.FirstName = c.FirstName;
            myC.MiddleName = c.MiddleName;
            // eccetera...

            return myC;

        }
    }
}
