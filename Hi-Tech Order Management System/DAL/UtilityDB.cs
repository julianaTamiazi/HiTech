using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Hi_Tech_System.DAL
{
    public static class UtilityDB
    {
        static DataSet dsHiTechDistributionDB;
        static DataTable dtCustomers;
        static SqlDataAdapter da;
        public static SqlConnection ConnectDB()
        {
            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["connectionHiTechDistributionDB1"].ConnectionString;
            connDB.Open();
            return connDB;
        }

        public static DataSet InitializeDataSet()
        {
            dsHiTechDistributionDB = new DataSet("HiTechDistributionDS");

            dtCustomers = new DataTable("Customers");
            dtCustomers.Columns.Add("CustomerId", typeof(Int32));
            dtCustomers.Columns.Add("Name", typeof(string));
            dtCustomers.Columns.Add("StreetNo", typeof(Int32));
            dtCustomers.Columns.Add("StreetName", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PhoneNumber", typeof(string));
            dtCustomers.Columns.Add("FaxNumber", typeof(string));
            dtCustomers.Columns.Add("Credit", typeof(float));
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerId"] };
            dsHiTechDistributionDB.Tables.Add(dtCustomers);

            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(da);
            da.Fill(dsHiTechDistributionDB.Tables["Customers"]);

            return dsHiTechDistributionDB;
        }

        public static void UpdateDBTable(string tableName)
        {
            SqlCommandBuilder swlBuilder = new SqlCommandBuilder(da);
            da.Update(dsHiTechDistributionDB.Tables[tableName]);
        }
    }
}
