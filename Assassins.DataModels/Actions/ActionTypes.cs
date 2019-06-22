using Assassins.DataModels.Interfaces;
using System.Collections.Generic;

namespace Assassins.DataModels.Actions
{
    public class ActionType : IDataModel
    {
        public int AaId { get; set; }
        public string action_type { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public override IDataViewModel ToViewModel()
        {
            var vm = new ActionTypeViewModel()
            {
                AaId = AaId,
                action_type = action_type
            };
            return vm;
        }
    }
    public class ActionTypeViewModel : IDataViewModel
    {
        public int AaId { get; set; }
        public string action_type { get; set; }
        public IDataModel ToModel()
        {
            var model = new ActionType()
            {
                AaId = AaId,
                action_type = action_type
            };
            return model;
        }
    }
}
