using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Microsoft.Extensions.Options;

namespace Assassins.DataAccess.Repositories
{
    public class LeadFormRepository : BaseRepository, ILeadFormRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        private readonly string key = "lead-forms";
        public LeadFormRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

    }
}
