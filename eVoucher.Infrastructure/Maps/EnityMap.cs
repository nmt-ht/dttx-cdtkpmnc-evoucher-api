using eVoucher.Domain.SeekWork;
using FluentNHibernate.Mapping;

namespace eVoucher.Infrastructure.Maps
{
    public class EntityMap<T> : ClassMap<T> where T : Entity
    {
        protected EntityMap()
        {
            Id(e => e.Id);
        }
    }
}
