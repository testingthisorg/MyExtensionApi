using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;

namespace Assassins.DataModels.Actions
{
    public class Action : IDataModel
    {
        public int AaId { get; set; }
        public int action_type_id { get; set; }
        public virtual ActionType action_type { get; set; }
        public double value { get; set; }
        public string Discriminator { get; set; }
        public int? CampaignInsightId { get; set; }
        public CampaignInsight CampaignInsight { get; set; }
        public IDataViewModel ToViewModel()
        {
            var vm = new ActionViewModel()
            {
                AaId = AaId,
                action_type_id = action_type_id,
                value = value,
                Discriminator = Discriminator
            };
            if (action_type != null)
            {
                vm.action_type = (ActionTypeViewModel)action_type.ToViewModel();
            }
            return vm;
        }
    }

    public class ActionViewModel : IDataViewModel
    {
        public int AaId { get; set; }
        public int action_type_id { get; set; }
        public virtual ActionTypeViewModel action_type { get; set; }
        public double value { get; set; }
        public string Discriminator { get; set; }
        public IDataModel ToModel()
        {
            var model = new Action()
            {
                AaId = AaId,
                action_type_id = action_type_id,
                value = value,
                Discriminator = Discriminator
            };
            if (action_type != null)
            {
                model.action_type = (ActionType)action_type.ToModel();
            }
            return model;
        }
    }
}
