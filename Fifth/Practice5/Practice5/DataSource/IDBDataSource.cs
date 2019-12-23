using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5.DataSource
{
    interface IDBDataSource<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetDataByID(Guid? id);
        void Update(Guid? id, IDictionary<string,string> parameters);
        void Delete(Guid? id);
    }
}
