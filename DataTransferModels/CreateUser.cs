using TigerBackEnd5.Models;

namespace TigerBackEnd5.DataTransferModels
{
    public class CreateUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Plan>? Plans { get; set; }

        public User ToDataModel()
        {
            if (Plans == null) { Plans = new List<Plan>(); }
            return new User
            {
                UserName = UserName,
                Email = Email,
                Plans = Plans
            };
        }
    }
}
