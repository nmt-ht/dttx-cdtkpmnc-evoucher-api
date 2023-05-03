﻿using eVoucher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.Infrastructure.Maps
{
    public class PartnerMap : EntityMap<Partner>
    {
        public PartnerMap()
        {
            Table("Partner");

            Map(p => p.CompanyName);
            Map(p => p.Description);
            Map(p => p.CompanyEmailAddress);
            Map(p => p.CompanyPhone);
            Map(p => p.Image);
            Map(p => p.JoinDate);
            Map(p => p.Type);
            Map(p => p.IsActive);


            HasMany<Address>(p => p.CompanyAddess)
                   .Table("Address")
                   .KeyColumn("Address_ID")
                   .Cascade.AllDeleteOrphan();
        }
    }
}