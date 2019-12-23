using Practice5.Catalogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Practice5.DataSource
{
    class ProductDataSource : IDBDataSource<Product>
    {
        private string connectionString;

        public ProductDataSource()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectAllFromProducts]", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        ProductCategoryID = reader.GetGuid(2)
                    });

                }
            }
            return products;
        }

        public Product GetDataByID(Guid? id)
        {
            Product product = new Product();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProductByID]", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product = new Product
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        ProductCategoryID = reader.GetGuid(2)
                    };
                }
            }

            return product;
        }

        public void Delete(Guid? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[DeleteProductByID]", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();
                command.Parameters.Add( new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public void Update(Guid? id, IDictionary<string, string> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[UpdateProductByID]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", id));
                foreach (var keyValuePair in parameters)
                {
                    command.Parameters.Add(new SqlParameter(keyValuePair.Key, keyValuePair.Value));
                }
                command.Connection.Open();
               
                SqlDataReader reader = command.ExecuteReader();
            }
        }
        public IEnumerable<Product> GetProductsByProductCategoryGid(Guid productCategoryGid)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProductsByCategoryID]", connection);

                command.Parameters.Add(new SqlParameter("@productCategoryGid", productCategoryGid));

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        ProductCategoryID = reader.GetGuid(2)
                    });
                }
            }
            return products;
        }
        public IEnumerable<Product> GetProductsByProviderID(Guid? providerID)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProductByProviderID]", connection);

                command.Parameters.Add(new SqlParameter("@providerID", providerID));

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        ProductCategoryID = reader.GetGuid(2)
                    });

                }
            }
            return products;
        }
    }
}
