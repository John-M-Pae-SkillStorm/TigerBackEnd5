using TigerBackEnd5.Models.Profiles;

namespace TigerBackEnd5.Models
{
    public class Plan
    {
        public int Id { get; set; }

        public int PlanProfileId { get; set; }
        public PlanProfile Profile { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
