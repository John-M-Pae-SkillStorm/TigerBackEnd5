using System.ComponentModel.DataAnnotations;

namespace TigerBackEnd5.Models.Profiles
{
    public class PlanProfile
    {
        //[Key]
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int PlanPrice { get; set; }
        public int DeviceLimit { get; set; }

        //public virtual ICollection<Plan> Plans { get; set; }
    }
}
