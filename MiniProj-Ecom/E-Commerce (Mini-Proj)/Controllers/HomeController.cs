using E_Commerce__Mini_Proj_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace E_Commerce__Mini_Proj_.Controllers
{
    
    public class HomeController : Controller
    {
        private YourDbContext db = new YourDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                // Fetch user from the database
                var user = db.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
                if (user != null)
                {
                    // Set authentication cookie
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    // Redirect to Home after login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If invalid, show error (you can also pass this to a modal)
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            // Return error if login fails
            return View("Index");
        }

        // Register POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string Name, string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                // Check if user already exists
                var existingUser = db.Users.FirstOrDefault(u => u.Email == Email);
                if (existingUser == null)
                {
                    // Create new user
                    var newUser = new User { UserName = Name, Email = Email, Password = Password };

                    // Add user to the database
                    db.Users.Add(newUser);
                    db.SaveChanges();

                    // Log the user in
                    FormsAuthentication.SetAuthCookie(newUser.Email, false);

                    // Redirect to Home after registration
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email is already registered.");
                }
            }

            // Return error if registration fails
            return View("Index");
        }

        // Logout Action
        public ActionResult Logout()
        {
            // Sign out the user
            FormsAuthentication.SignOut();

            // Redirect to Home after logout
            return RedirectToAction("Index", "Home");
        }

        // Optional: Profile Action
        [Authorize]
        public ActionResult Profile()
        {
            var user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            if (user != null)
            {
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //public ActionResult UpdateProfile(User model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Update user data in the database
        //        // Example: _userRepository.UpdateUser(model);

        //        // Redirect or show a success message
        //        ViewBag.Message = "Profile updated successfully!";
        //    }

        //    return View(model);
        //}

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult PD()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult pp()
        {
            return View();
        }
    }
}