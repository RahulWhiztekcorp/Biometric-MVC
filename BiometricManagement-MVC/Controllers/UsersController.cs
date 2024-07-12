using BiometricManagement_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiometricManagement_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly BiometricContext _context;

        public UsersController(BiometricContext context)
        {
            _context = context;
        }

        //// Get: Users
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Users.ToListAsync());
        //}
        public async Task<IActionResult> Index(DateTime? date)
        {
            var users = await _context.Users
                .Include(u => u.DevicesIn)
                .Include(u => u.DevicesOut)
                .ToListAsync();

            var userDurations = new List<UserDurationViewModel>();

            foreach (var user in users)
            {
                var logins = user.DevicesIn.Select(d => d.LoginTime).ToList();
                var logouts = user.DevicesOut.Select(d => d.LogoutTime).ToList();

                var durations = new List<TimeSpan>();

                for (int i = 0; i < logins.Count; i++)
                {
                    if (i < logouts.Count)
                    {
                        var loginDate = logins[i].Date;
                        if (!date.HasValue || loginDate == date.Value.Date)
                        {
                            durations.Add(logouts[i] - logins[i]);
                        }
                    }
                }

                if (durations.Any())
                {
                    userDurations.Add(new UserDurationViewModel
                    {
                        Username = user.Username,
                        FullName = user.FullName,
                        Durations = durations.Select(d => d.ToString(@"hh\:mm\:ss\.fff")).ToList()
                    });
                }
            }

            return View(userDurations);
        }

        // Get: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.DevicesIn)
                .Include(u => u.DevicesOut)
                .FirstOrDefaultAsync(m => m.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            var logins = user.DevicesIn.Select(d => d.LoginTime).ToList();
            var logouts = user.DevicesOut.Select(d => d.LogoutTime).ToList();
            var durations = new List<TimeSpan>();

            for (int i = 0; i < logins.Count; i++)
            {
                if (i < logouts.Count)
                {
                    durations.Add(logouts[i] - logins[i]);
                }
            }

            ViewBag.Durations = durations;

            return View(user);
        }

        // Post: Users/Login
        [HttpPost]
        public async Task<IActionResult> Login(int userId)
        {
            var login = new DeviceIn
            {
                UserId = userId,
                LoginTime = DateTime.Now
            };

            _context.DevicesIn.Add(login);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = userId });
        }

        // Post: Users/Logout
        [HttpPost]
        public async Task<IActionResult> Logout(int userId)
        {
            var logout = new DeviceOut
            {
                UserId = userId,
                LogoutTime = DateTime.Now
            };

            _context.DevicesOut.Add(logout);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = userId });
        }

    }
    public class UserDurationViewModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public List<string> Durations { get; set; }
    }

}
