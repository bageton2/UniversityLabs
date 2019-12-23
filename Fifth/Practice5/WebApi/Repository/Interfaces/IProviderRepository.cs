using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repository.Interfaces
{
    public interface IProviderRepository
    {
        Provider GetProviderByGID(Guid gid);
        List<Provider> Get();
        void InsertProvider(Provider provider);
        void UpdateProvider(Provider provider);
        void DeleteProvider(Provider provider);
    }
}
