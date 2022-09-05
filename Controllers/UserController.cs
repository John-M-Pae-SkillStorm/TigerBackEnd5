using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TigerBackEnd5.Data;
using TigerBackEnd5.DataTransferModels;
using TigerBackEnd5.Models;
using TigerBackEnd5.Models.Profiles;

namespace TigerBackEnd5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly TigerContext _context;

        public UserController(ILogger<UserController> logger, TigerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _context.Users
                .Include(u => u.Plans)
                .ToListAsync();
        }

        [HttpGet("Plans")]
        public async Task<ActionResult<IEnumerable<PlanProfile>>> GetAllPlans()
        {
            if (_context.PlanProfiles == null)
            {
                return NotFound();
            }
            return await _context
                .PlanProfiles
                .ToListAsync();
        }

        [HttpGet("Devices")]
        public async Task<ActionResult<IEnumerable<DeviceProfile>>> GetAllDevices()
        {
            if (_context.DeviceProfiles == null)
            {
                return NotFound();
            }
            return await _context
                .DeviceProfiles
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserInfo(int userId)
        {
            if (_context.Users == null) { return NotFound(); }
            
            User? TargetUser = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Plans)
                .FirstAsync();

            if (TargetUser == null) { return NotFound(); }

            return TargetUser;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUser(CreateUser newUser)
        {
            if (_context == null) { return Problem("New user could not be created."); }

            User user = newUser.ToDataModel();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("{id}/Plan")]
        public async Task<ActionResult<User>> CreatePlanForUser(int userId, Plan plan)
        {
            User? user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Plans)
                .FirstOrDefaultAsync();
            if (user == null) { return NotFound(); }

            _context.Plans.Add(plan);
            user.Plans.Add(plan);

            await _context.SaveChangesAsync();

            return user;
        }

        [HttpPost("{id}/Device")]
        public async Task<ActionResult<User>> CreateDeviceForUserWithPlan(int userId, int planId, Device device)
        {
            User? user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Plans)
                .FirstOrDefaultAsync();
            Plan? plan = await _context.Plans
                .Where(p => p.Id == planId)
                .Include(p => p.Devices)
                //.Include(p => p.PlanProfileId)
                .FirstOrDefaultAsync();
            if (user == null || plan == null) { return NotFound(); }

            var profile = await _context.PlanProfiles.FindAsync(plan.PlanProfileId);
            if (profile == null) { return NotFound(); }
            if (profile.DeviceLimit >= plan.Devices.Count)
            {
                return Problem("This plan cannot support any more devices.");
            }

            _context.Devices.Add(device);
            plan.Devices.Add(device);
            await _context.SaveChangesAsync();

            return await GetUserInfo(userId);
        }
    }
}