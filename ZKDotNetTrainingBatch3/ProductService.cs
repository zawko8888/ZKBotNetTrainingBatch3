using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKDotNetTrainingBatch3
{
    public class ProductService
    {

        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "VJPG11",
            InitialCatalog = "Batch3MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        //SqlConnectionStringBuilder sqlCollectionStringBuilder = new SqlConnectionStringBuilder();
        //sqlCollectionStringBuilder.DataSource = "VJPG11";
        //sqlCollectionStringBuilder.InitialCatalog = "Batch3MiniPOS";
        //sqlCollectionStringBuilder.UserID = "sa";
        //sqlCollectionStringBuilder.Password = "sasa@123";
        //sqlCollectionStringBuilder.TrustServerCertificate = true;
        
        public void Read()
        {
            //SqlConnection connection = new SqlConnection("Data Source = VJPG11;Initial Catalog=Batch3MiniPOS;User ID=sa;Passwor =sasa@123;TrustServerCertificate=true");
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            
            connection.Open();
            string query = @"SELECT [Product_Id]
                  ,[Product_Name]
                  ,[Product_Quantity]
                  ,[Product_Price]
                  ,[Product_DeleteFlag]
              FROM [dbo].[Tbl_Product]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int RowNo = i + 1;
                decimal Price = Convert.ToDecimal(row["Product_Price"]);
                Console.WriteLine(RowNo.ToString() + ". " + "Product_Name" + row["Product_Name"] + ", " + "Product_Quantity" + " " + row["Product_Quantity"] + " & " + "(" + Price.ToString("n0") + ")");
            }
        }
        public void Create() {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
                           ([Product_Name]
                           ,[Product_Quantity]
                           ,[Product_Price]
                           ,[Product_DeleteFlag])
                     VALUES
                           ('zaw'
                           ,3
                           ,1000
                           ,0)";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving failed";
            
            Console.WriteLine(message);
        }
        public void Update() {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
                           ([Product_Name]
                           ,[Product_Quantity]
                           ,[Product_Price]
                           ,[Product_DeleteFlag])
                     VALUES
                           ('zaw'
                           ,3
                           ,1000
                           ,0)";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving failed";

            Console.WriteLine(message);
        }
        public void Delete() { 
        
        }
    }
}
