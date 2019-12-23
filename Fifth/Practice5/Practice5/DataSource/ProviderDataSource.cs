using Practice5.Catalogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Practice5.DataSource
{
    class ProviderDataSource : IDBDataSource<Provider>
    {
        private string connectionString;

        public ProviderDataSource()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }

        public IEnumerable<Provider> GetAll()
        {
            List<Provider> providers = new List<Provider>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectAllFromProviders]", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    providers.Add(new Provider
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1)
                    });

                }
            }
            return providers;
        }

        public Provider GetDataByID(Guid? id)
        {
            Provider provider = new Provider();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProviderByIDQuery]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    provider = new Provider
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1)
                    };
                }
            }

            return provider;
        }

        public void Delete(Guid? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[DeleteProviderByID]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();
                command.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public void Update(Guid? id, IDictionary<string, string> parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[UpdateProviderByIDQuery]", connection);
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
        public IEnumerable<Provider> GetProvidersByProductCategoryID(Guid productCategoryID)
        {
            List<Provider> providers = new List<Provider>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProvidersByProductCategoryID]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@productCategoryID", productCategoryID));
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    providers.Add(new Provider
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1)
                    });

                }
            }
            return providers;
        }
        public Dictionary<Provider, int> GetProvidersWithMaxCategories()
        {
            Dictionary<Provider, int> providerCategories = new Dictionary<Provider, int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("[dbo].[SelectProvidersWithMaxCategories]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    providerCategories.Add((new Provider{
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1)}),
                        reader.GetInt32(2));

                }
            }
            return providerCategories;
        }
    }
}
