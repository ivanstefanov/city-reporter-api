using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbProv
{
    public interface IDb<T, K>
    {
        Task Create(T entity);

        Task<T> Read(K entity, bool useNavigationalProperties = false, bool isReadOnlyTrue = true);

        Task<List<T>> ReadAll(bool useNavigationalProperties = false, bool isReadOnlyTrue = true);

        Task Update(T entity, bool useNavigationalProperties);

        Task Delete(K key);
    }
}
