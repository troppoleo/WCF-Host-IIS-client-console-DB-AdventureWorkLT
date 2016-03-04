using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press 1 to try ECHO");
                Console.WriteLine("Press 2 to read all first Name");
                Console.WriteLine("Press 3 to read first Name");
                Console.WriteLine("Press 4 to read first Customer");
                Console.WriteLine("Press 5 to read first 10 Customers");
                Console.WriteLine("Press 6 to read first Product");
                Console.WriteLine("Press 7 to read People");
                Console.WriteLine("Press 8 to add person (return bool)");
                Console.WriteLine("Press 9 to add person2 (return int)");
                Console.WriteLine("Press 0 to Exit");

                string myF = Console.ReadLine();

                switch (myF)
                {
                    case "0":
                        return;
                        break;
                    case "1":
                        EchoMsg();
                        break;
                    case "2":
                        ReadAllFirstName();
                        break;
                    case "3":
                        ReadFirstName();
                        break;
                    case "4":
                        ReadFirstCustomer();
                        break;
                    case "5":
                        ReadFirstTenCustomer();
                        break;
                    case "6":
                        ReadFirstProduct();
                        break;
                    case "7":
                        ReadPeople();
                        break;
                    case "8":
                        AddPerson();
                        break;
                    case "9":
                        AddPerson2();
                        break;
                }


                //Console.WriteLine("Press any button to exit");
                //Console.ReadLine();
            }
        }

        private static void AddPerson2()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();

            ExposedSrv.Persone p = new ExposedSrv.Persone();
            Print("Name:");
            p.name = Console.ReadLine();

            Print("Surname:");
            p.surname = Console.ReadLine();

            int i= mySd.addPersona2(p);
            Print(string.Format("output: {0}", i));
                //mySd.addPersonaCompleted += mySd_addPersonaCompleted;
            //mySd.addPersonaAsync(p);
        }

        private static void AddPerson()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();

            ExposedSrv.Persone p = new ExposedSrv.Persone();
            Print("Name:");
            p.name  = Console.ReadLine();
            
            Print("Surname:");
            p.surname  = Console.ReadLine();
            

            mySd.addPersonaCompleted += mySd_addPersonaCompleted; 
            //mySd.addPersona(p, out myOut, out myOut2);
            mySd.addPersonaAsync(p);
        }

        static void mySd_addPersonaCompleted(object sender, ExposedSrv.addPersonaCompletedEventArgs e)
        {
            Print("Person saved");
        }

        private static void ReadPeople()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();

            Print("-----------------------------------");
            foreach (var p in mySd .GetPeople())
            {
                Print(p.name + " " + p.surname);
            }
            Print("-----------------------------------");        
        }

        private static void ReadFirstProduct()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();
            //ClassLibraryShared.clsProduct myLocalProd = new ClassLibraryShared.clsProduct();
            //myLocalProd =  (ClassLibraryShared.clsProduct)mySd.GetFirstProduct();
            ExposedSrv.clsProduct c = mySd.GetFirstProduct();
            Print(c.Name);
        }

        private static void ReadFirstTenCustomer()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();
                foreach(var c in mySd .GetAllCustomers())
                {
                    Print(c.Title);
                    Print(c.LastName);
                    Print(c.MiddleName );
                    Print(c.FirstName);
                }
 	
        }


        private static void ReadFirstCustomer()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();
            //ExposedSrv.clsCustomer myCC = new ExposedSrv.clsCustomer();
            //myCC.GetCustomerFromEF
            //myCC.FirstName = "leo";
            
            var myC = mySd.GetFirstCustomer();
            Print(myC.Title);
            Print(myC.LastName);
            Print(myC.MiddleName );
            Print(myC.FirstName);

        }


        private static void ReadFirstName()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();
            Print(mySd.GetOneFirstName());
        }

        private static void Print(string p)
        {
            Console.WriteLine(p);
        }

        private static void ReadAllFirstName()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();
            var arr =mySd.GetCustomerFirstNames ();

            Print("----------------------------------------->>>>>");
            foreach (string s in arr.ToList())
            {
                Console.WriteLine(s);
            }
            Print("-----------------------------------------<<<<<");

        }

        private static void EchoMsg()
        {
            ExposedSrv.SrvData mySd = new ExposedSrv.SrvData();


            Console.WriteLine("Write a word to echo it:");
            string myEchoMsg = Console.ReadLine();

            Console.WriteLine("---- Your message -----");
            Console.WriteLine(mySd.GetEcho(myEchoMsg));
            Console.WriteLine("---- END - Your message -----");

        }
    }
}
