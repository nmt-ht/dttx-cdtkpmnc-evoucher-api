using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps;

public class AddressMap : EntityMap<Address>
{
    public AddressMap()
    {
        Table("[Address]");

        Map(p => p.Street);
        Map(p => p.District);
        Map(p => p.City);
        Map(p => p.Country);
        Map(p => p.Type).CustomType<int>();
        Map(p => p.IsDeleted);

        References(x => x.User, "User_ID_FK");
    }
}
