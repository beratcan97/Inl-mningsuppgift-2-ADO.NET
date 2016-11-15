using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämningsuppgift_2_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
        }
        public static void start()
        {
            {
                //Skriver på skärmen
                Console.WriteLine("Lägg till ny kund? Tryck 1");
                Console.WriteLine("Lägg till ny produkt? Tryck 2");
                Console.WriteLine("Uppdatera pris på en  vara? Tryck 3");
                Console.WriteLine("Avsluta? Tryck 0");


                bool valloop = true;
                while (valloop)
                {
                    //Gör val
                    string val = Console.ReadLine();

                    if (val == "1")
                    {
                        SkapaKund();
                    }
                    else if (val == "2")
                    {
                        SkapaProdukt();
                    }
                    else if (val == "3")
                    {
                        UppdateraPris();
                    }
                    else if (val == "0")
                    {
                        Console.WriteLine("Program avslutas....");
                        valloop = false;
                    }
                    else
                    {
                        Console.WriteLine("Du kan endast välja 1,2,3 eller 0 för att avsluta");
                        Console.ReadLine();
                    }
                }
            }
        }
        public static void SkapaKund()
        {
            try
            {
                Console.WriteLine("Kund ID:");
                string customerId = Console.ReadLine();
                Console.WriteLine("Företags namn:");
                string companyName = Console.ReadLine();
                Console.WriteLine("Kontakt namn:");
                string contactName = Console.ReadLine();
                Console.WriteLine("Kontakt titel:");
                string contactTitle = Console.ReadLine();
                Console.WriteLine("Adress:");
                string address = Console.ReadLine();
                Console.WriteLine("Stad:");
                string city = Console.ReadLine();
                Console.WriteLine("ort:");
                string region = Console.ReadLine();
                Console.WriteLine("Postnummer:");
                string postalCode = Console.ReadLine();
                Console.WriteLine("Land:");
                string country = Console.ReadLine();
                Console.WriteLine("Telefonnummer:");
                string phone = Console.ReadLine();
                Console.WriteLine("Fax nummer:");
                string fax = Console.ReadLine();


                string cns = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;

                SqlConnection cn = new SqlConnection(cns);
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CustomerInsert";
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@CompanyName", companyName);
                cmd.Parameters.AddWithValue("@ContactName", contactName);
                cmd.Parameters.AddWithValue("@ContactTitle", contactTitle);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Region", region);
                cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Fax", fax);
                cmd.ExecuteNonQuery();
                cn.Close();
                Console.WriteLine("Kunden är nu skapad!");
                Console.WriteLine("");
                Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Kund id finns redan!, Tryck på valfri tangent för start menyn!");
                Console.ReadLine();
                //throw;
            }
            start();
        }
        private static void SkapaProdukt()
        {
            Console.WriteLine("Produkt namn:");
            string productName = Console.ReadLine();
            Console.WriteLine("Leverantör ID:");
            int supplierId = int.Parse(Console.ReadLine());
            Console.WriteLine("Katogori ID:");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Mängd per enhet:");
            string quantityPerUnit = Console.ReadLine();
            Console.WriteLine("Produkt pris:");
            decimal unitPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Produkt i lager(st):");
            string unitsInStock = Console.ReadLine();
            Console.WriteLine("Produkt i order:");
            string unitsOnOrder = Console.ReadLine();
            Console.WriteLine("Beställningsnivå:");
            string reorderLevel = Console.ReadLine();

            string cns = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ProductInsert";
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@SupplierID", supplierId);
            cmd.Parameters.AddWithValue("@CategoryID", categoryId);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
            cmd.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("Produkten är nu skapad!");
            Console.WriteLine("");
            start();
        }
        public static void UppdateraPris()
        {
            Console.WriteLine("Produkt ID på varan som du vill byta pris på:");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ny pris på varan:");
            decimal unitPrice = decimal.Parse(Console.ReadLine());

            string cns = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProductPrice";
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmd.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("Priset är nu ändrat!");
            Console.WriteLine("");
            start();
        }
    }
}
