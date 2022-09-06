using TigerBackEnd5.Models;

namespace TigerBackEnd5.DataTransferModels
{
    public class AddDevice
    {
        public int DeviceProfileId { get; set; }
        public int PhoneNumberDigits { get; set; }

        public Device ToDataModel() { }
    }
}
