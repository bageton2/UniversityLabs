using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository.Implementations
{
    public class ProviderRepository : IProviderRepository
    {
        public void DeleteProvider(Provider provider)
        {
            using (var context = new ProductionDBContext())
            {

            }
        }

        public List<Provider> Get()
        {
            throw new NotImplementedException();
        }

        public Provider GetProviderByGID(Guid gid)
        {
            using (var context = new ProductionDBContext())
            {
                return null;
            }
        }

        public void InsertProvider(Provider provider)
        {
            throw new NotImplementedException();
        }

        public void UpdateProvider(Provider provider)
        {
            throw new NotImplementedException();
        }
    }
}
