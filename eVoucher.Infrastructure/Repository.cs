using NHibernate;
using System.Data.Common;
using System.Data;
using System.Linq.Expressions;
using eVoucher.Domain.SeekWork;

namespace eVoucher.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly ISession _session;
        private readonly IRepositoryFactory _repositoryFactory;
        public Repository(IRepositoryFactory repositoryFactory)
        {
            this._repositoryFactory = repositoryFactory;
            this._session = this._repositoryFactory.CreateSession();
        }

        public void Add(object entity, bool commit = true)
        {
            this._session.Save(entity);

            if (commit)
            {
                this.CommitChanges();
            }
        }
        public void Remove(object entity, bool commit = true)
        {
            this._session.Delete(entity);

            if (commit)
            {
                this.CommitChanges();
            }
        }
        public void Update(object entity, bool commit = true)
        {
            if (this._session.Contains(entity))
            {
                entity = this._session.Merge(entity);
            }

            this._session.Update(entity);

            if (commit)
            {
                this.CommitChanges();
            }
        }
        public void AddOrUpdate(object entity, bool commit = true)
        {
            this._session.SaveOrUpdate(entity);
            if (commit)
            {
                this.CommitChanges();
            }
        }
        public T Get<T>(Guid id)
        {
            return _session.Get<T>(id);
        }
        public IList<T> Get<T>(Expression<Func<T, bool>> filter)
        {
            return _session.Query<T>().Where(filter).ToList();
        }
        public void CommitChanges()
        {
            try
            {
                this._session.BeginTransaction();
                if (this._session.Transaction.IsActive)
                {
                    this._session.Transaction.Commit();
                }                
            }
            catch
            {
                if (this._session.Transaction.IsActive)
                {
                    this._session.Transaction.Rollback();
                }
                throw;
            }
        }
        public object ExecuteScalar(string command, CommandType commandType, params DbParameter[] parameters)
        {
            IDbCommand dbCommand = this._session.Connection.CreateCommand();

            dbCommand.CommandText = command;
            dbCommand.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var para in parameters)
                {
                    dbCommand.Parameters.Add(para);
                }
            }

            return dbCommand.ExecuteScalar();
        }
        public void ExecuteCommand(string command, CommandType commandType, params object[] parameters)
        {
            IDbCommand dbCommand = _session.Connection.CreateCommand();

            dbCommand.CommandText = command;
            dbCommand.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var para in parameters)
                {
                    dbCommand.Parameters.Add(para);
                }
            }

            dbCommand.ExecuteNonQuery();
        }
        private bool _disposed = false;
        public void Dispose()
        {
            if (!this._disposed)
            {
                if (this._session != null)
                {
                    this._session.Clear();
                    this._session.Dispose();
                }

                this._disposed = true;
            }
        }
        public void Refresh(object entity)
        {
            this._session.Refresh(entity);
        }
    }
}