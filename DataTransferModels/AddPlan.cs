using TigerBackEnd5.Data;
using TigerBackEnd5.Models;

namespace TigerBackEnd5.DataTransferModels
{
    public class AddPlan
    {
        public int UserId { get; set; }
        public int PlanProfileId { get; set; }

        public async Task<Plan> ToDataModel(TigerContext context)
        {
            return new Plan
            {
                UserId = UserId,
                User = await context.Users.FindAsync(UserId),
                PlanProfileId = PlanProfileId,
                Profile = await context.PlanProfiles.FindAsync(PlanProfileId),
                Devices = new List<Device>()
            };
        }
    }
}
