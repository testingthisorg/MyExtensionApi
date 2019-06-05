using Assassins.DataModels.Interfaces;

namespace Assassins.DataModels.AdAccounts
{
    public class AttributionSpec : IDataModel
    {
        public int AaId { get; set; }
        public string event_type { get; set; }
        public int window_days { get; set; }
        public int AdAccountId { get; set; }
        public AdAccount AdAccount { get; set; }
        public IDataViewModel ToViewModel()
        {
            var vm = new AttributionSpecViewModel()
            {
                AaId = AaId,
                event_type = event_type,
                window_days = window_days
            };
            return vm;
        }
    }
    public class AttributionSpecViewModel : IDataViewModel
    {
        public int AaId { get; set; }
        public string event_type { get; set; }
        public int window_days { get; set; }

        public int AdAccountId { get; set; }
        public IDataModel ToModel()
        {
            var model = new AttributionSpec()
            {
                AdAccountId = AdAccountId,
                AaId = AaId,
                event_type = event_type,
                window_days = window_days
            };
            return model;
        }
    }
}
