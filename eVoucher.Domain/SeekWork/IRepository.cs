using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace eVoucher.Domain.SeekWork
{
    public interface IRepository : IDisposable
    {
        T Get<T>(Guid id);
        IList<T> Get<T>(Expression<Func<T, bool>> filter);
        void Update(object entity, bool commit = true);
        void AddOrUpdate(object entity, bool commit = true);
        void Add(object entity, bool commit = true);
        void Remove(object entity, bool commit = true);
        void CommitChanges();
        object ExecuteScalar(string command, CommandType commandType, params DbParameter[] parameters);
        void ExecuteCommand(string command, CommandType commandType, params object[] parameters);
        void Refresh(object entity);
    }
}
