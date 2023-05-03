using eVoucher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.Infrastructure.Maps
{
    public class CampaignMap : EntityMap<Campaign>
    {
        public CampaignMap()
        {
            Table("Campaign");

            Map(p => p.Name);
            Map(p => p.Description);
            Map(p => p.CreateDate);
            Map(p => p.StartedDate);
            Map(p => p.ExpiredDate);
            Map(p => p.ModifiedBy);
            Map(p => p.ModifiedDate);
            Map(p => p.IsDeleted);
            Map(p => p.CreatedBy);
            
        }

    }
}
