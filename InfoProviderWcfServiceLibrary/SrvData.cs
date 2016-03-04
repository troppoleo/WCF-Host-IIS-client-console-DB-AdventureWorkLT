using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InfoProviderWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SrvData : ISrvData
    {
     
        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetEcho(string pWord)
        {
            return "Your word: " + pWord;
        }

        public List<string> GetCustomerFirstNames()
        {
            
            AdventureWorksLTEntities myEn = new AdventureWorksLTEntities();
            return myEn.Customers.Select(f => f.FirstName).ToList();
        }

        public string GetOneFirstName()
        {
            try
            {
                AdventureWorksLTEntities myEn = new AdventureWorksLTEntities();
                return myEn.Customers.FirstOrDefault().FirstName;
            }
            catch(Exception ex)
            {
                string myErr;
                myErr = ex.Message;
            }
            return "c'è stato un errore";
        }

        public clsCustomer GetFirstCustomer()
        {
            AdventureWorksLTEntities myEn = new AdventureWorksLTEntities();
            Customer myC = myEn.Customers.First();
            clsCustomer myOut = new clsCustomer();
            myOut = myOut.GetCustomerFromEF(myC);

            return myOut;
        }



        public List<clsCustomer> GetAllCustomers()
        {
            AdventureWorksLTEntities myEn = new AdventureWorksLTEntities();
            
            clsCustomer myC = new clsCustomer();

            List<clsCustomer> myCustomerList = new List<clsCustomer>();
            
            foreach (var c in myEn.Customers.Take(10))
            {
                myCustomerList.Add(myC.GetCustomerFromEF(c));
            }

            return myCustomerList;
        }

        public ClassLibraryShared.clsProduct GetFirstProduct()
        {
            ClassLibraryShared.clsProduct myP = new ClassLibraryShared.clsProduct();

            AdventureWorksLTEntities myEn = new AdventureWorksLTEntities();
            var myProd = myEn.Products.First();

            myP.Name = myProd.Name;


            return myP;
        }


        #region people function

        public List<Persone> GetPeople()
        {
            AdventureWorksLTEntities myEn = new AdventureWorksLTEntities();
            return myEn.Persones.ToList();

        }

        public bool addPersona(Persone p)
        {
            using (AdventureWorksLTEntities myEn = new AdventureWorksLTEntities())
            {
                try
                {
                    myEn.Persones.Add(p);
                    int myOut = myEn.SaveChanges();
                    return myOut > 0;
                }catch(Exception ex)
                {
                    string myErr = ex.Message;
                }
            }
            return false;
        }

        public int addPersona2(Persone p)
        {
            using (AdventureWorksLTEntities myEn = new AdventureWorksLTEntities())
            {
                try
                {
                    myEn.Persones.Add(p);
                    int myOut = myEn.SaveChanges();
                    return myOut;
                }
                catch (Exception ex)
                {
                    string myErr = ex.Message;
                }
            }
            return -1;
        }

        

        #endregion people function

    }
}
