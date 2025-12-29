// See https://aka.ms/new-console-template for more information


using Microsoft.Data.SqlClient;
using System.Data;
using ZKDotNetTrainingBatch3;

Console.WriteLine("Hello, World!");

ProductService productService = new ProductService();
//productService.Read();
//productService.Create();
//productService.Update();
productService.Delete();

Console.WriteLine();