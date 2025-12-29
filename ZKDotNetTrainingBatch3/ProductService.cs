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
            TrustServerCertificate = true,
        };   
        
        public void Read()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [Product_Id]
                          ,[Product_Name]
                          ,[Product_Quantity]
                          ,[Product_Price]
                          ,[Product_DeleteFlag]
                      FROM [dbo].[Tbl_Product]";

            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Product_Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["Product_Name"] + " (" + row["Product_Quantity"] + price.ToString("n0") + ") ");
            }
        }

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
                               ([Product_Name]
                               ,[Product_Quantity]
                               ,[Product_Price]
                               ,[Product_DeleteFlag])
                         VALUES
                               ('WaterMalon'
                               ,3
                               ,3500
                               ,0)";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
            string message = (result > 0 ? "Saving Success." : "Saving Filed");
            Console.WriteLine(message);
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
                           SET [Product_Name] = 'Malon'
                              ,[Product_Quantity] = 6
                              ,[Product_Price] = 8000
                              ,[Product_DeleteFlag] = 0
                         WHERE Product_Id = 16;";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = (result > 0 ? "Update Success." : "Update Filed");
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"Delete From Tbl_Product WHERE Product_Id = 13;";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = (result > 0 ? "Delete Success." : "Delete Filed");
            Console.WriteLine(message);
        }
    }
}
