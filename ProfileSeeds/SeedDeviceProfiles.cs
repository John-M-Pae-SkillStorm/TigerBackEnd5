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
                Type = "Apple I-Phone 29",
                Model = "hrc10000",
                DevicePrice = 1300,
            },
            new DeviceProfile
            {
                Id = 2,
                Type = "Garmin Smart-Watch x2000",
                Model = "DJT450",
                DevicePrice = 600
            },
            new DeviceProfile
            {
                Id = 3,
                Type = "Samsung 55-inch Tablet Z",
                Model = "bHo4470",
                DevicePrice = 600
            }
        };
    }
}
