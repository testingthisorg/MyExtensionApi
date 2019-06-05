using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataAccess.Repositories.Campaigns
{
    public class CampaignRepository : BaseRepository, ICampaignRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        private readonly string key = "campaigns";
        public CampaignRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }


    }
}
