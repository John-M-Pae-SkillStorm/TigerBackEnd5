using TigerBackEnd5.Models.Profiles;

namespace TigerBackEnd5.ProfileSeeds
{
    public static class SeedPlanProfiles
    {
        public static List<PlanProfile> AvailiblePlans => new()
        {
            new PlanProfile
            {
                Id = 1,
                PlanName = "Cub",
                PlanPrice = 10,
                DeviceLimit = 4
            },
            new PlanProfile
            {
                Id = 2,
                PlanName = "Leopard",
                PlanPrice = 20,
                DeviceLimit = 8
            },
            new PlanProfile
            {
                Id = 3,
                PlanName = "Tiger",
                PlanPrice = 30,
                DeviceLimit = 12
            }
        };
    }
}
