using TigerBackEnd5.Models;
using TigerBackEnd5.Models.Profiles;

namespace TigerBackEnd5.DataTransferModels
{
    public class PlanInfo
    {
        public int Id { get; }
        public int ProfileId { get; }
        public string PlanName { get; }
        public int PlanPrice { get; }
        //public int DeviceLimit { get; }
        public ICollection<Device> Devices { get; set; }
        public PlanInfo(Plan plan, PlanProfile profile)
        {
            Id = plan.Id;
            ProfileId = plan.PlanProfileId;
            PlanName = profile.PlanName;
            PlanPrice = profile.PlanPrice;
            //DeviceLimit = profile.DeviceLimit;
            Devices = plan.Devices;
        }
    }
}
