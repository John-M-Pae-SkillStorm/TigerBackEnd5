using TigerBackEnd5.Models.Profiles;

namespace TigerBackEnd5.ProfileSeeds
{
    public static class SeedDeviceProfiles
    {
        public static List<DeviceProfile> AvailibleDevices => new()
        {
            new DeviceProfile
            {
                Id = 1,
                Type = "Smart Fridge",
                Model = "2a347b",
                DevicePrice = 1000,
            },
            new DeviceProfile
            {
                Id = 2,
                Type = "Samsung Galaxy",
                Model = "S9",
                DevicePrice = 600
            }
        };
    }
}
