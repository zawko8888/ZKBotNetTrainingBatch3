using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKDotNetTrainingBatch3
{
    public class ProductDapperService
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
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"SELECT [Product_Id]
                          ,[Product_Name]
                          ,[Product_Quantity]
                          ,[Product_Price]
                          ,[Product_DeleteFlag]
                      FROM [dbo].[Tbl_Product]";
                List<ProductDto> lst = db.Query< ProductDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++) {
                    Console.WriteLine(lst[i].Product_Name);
                }

            }
            
        }
        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"INSERT INTO [dbo].[Tbl_Product]
                               ([Product_Name]
                               ,[Product_Quantity]
                               ,[Product_Price]
                               ,[Product_DeleteFlag])
                         VALUES
                               ('GreatFruid'
                               ,9
                               ,5500
                               ,0)";
                int result = db.Execute(query);
                string message = (result > 0 ? "Create Success." : "Create Filed");
                Console.WriteLine(message);
            }
        }

        public void Update()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"UPDATE [dbo].[Tbl_Product]
                           SET [Product_Name] = 'Papaya'
                              ,[Product_Quantity] = 6
                              ,[Product_Price] = 8000
                              ,[Product_DeleteFlag] = 0
                         WHERE Product_Id = 10;";
            int result = db.Execute(query);
            string message = (result > 0 ? "Update Success." : "Update Filed");
            Console.WriteLine(message);
        }

        public void Delete()
        {
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            db.Open();
            string query = @"Delete From Tbl_Product WHERE Product_Id = 14;";
            int result = db.Execute(query);
            string message = (result > 0 ? "Delete Success." : "Delete Filed");
            Console.WriteLine(message);
        }
    }

    public class ProductDto //DTO = Data Transfer Object
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }
        public bool Product_DeleteFlag { get; set; }

    }
}
