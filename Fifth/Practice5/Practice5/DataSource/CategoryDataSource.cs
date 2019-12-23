using Practice5.Catalogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Practice5.DataSource
{
    class CategoryDataSource : IDBDataSource<ProductCategory>
    {
        private string connectionString;

        public CategoryDataSource()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = new List<ProductCategory>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectAllFromProductCategories]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productCategories.Add(new ProductCategory
                    {
                        Id = reader.GetGuid(0),
                        Caption = reader.GetString(1)
                    });

                }
            }
            return productCategories;
        }

        public ProductCategory GetDataByID(Guid? id)
        {
            ProductCategory productCategory = new ProductCategory();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProductCategoryByID]", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productCategory = new ProductCategory
                    {
                        Id = reader.GetGuid(0),
                        Caption = reader.GetString(1)
                    };
                }
            }

            return productCategory;
        }

        public void Delete(Guid? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[DeleteProductCategoryByID]", connection);

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
                SqlCommand command = new SqlCommand("[dbo].[UpdateProductCategoryByID]", connection);

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
       
    }
}
