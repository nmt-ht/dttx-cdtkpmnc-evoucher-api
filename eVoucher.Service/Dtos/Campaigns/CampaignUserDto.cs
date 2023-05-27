using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.Service.Dtos.Campaigns
{
    public class CampaignUserDto
    {
        public Guid ID { get; set; }
        public DateTime JoinDate { get; set; }
        public Guid User_ID { get; set; }
        public Guid Campaign_ID { get; set; }
    }
}
