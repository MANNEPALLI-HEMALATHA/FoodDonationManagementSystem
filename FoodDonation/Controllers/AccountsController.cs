using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodDonation.Models;



namespace FoodDonation.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(UserLogin user)
        {
            using (FoodDonationContext db = new FoodDonationContext())
            {
                var users = db.UserMaster.Where(x => x.UserId == user.UserId && x.Password == user.Password).ToList();
               // var FullName = users[0].FirstName + users[0].LastName; 
                if (users.Count() > 0)
                {
                    HttpContext.Session.SetString("name", users[0].FirstName);
                    HttpContext.Session.SetInt32("role", users[0].RollId);
                    HttpContext.Session.SetString("category", users[0].DonorCategory);

                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["LoginStatus"] = "Fail";
                }
            }
            return View();
        }
        public IActionResult Signup() 
        {
            List<SelectListItem> DonorCategory = new List<SelectListItem>
            {
                new SelectListItem{Value="Food Donor",Text="Food Donor" },
                new SelectListItem{Value="Logistics sponsor",Text="Logistics sponsor" }
                
            };
            ViewBag.DonorCategory = DonorCategory;
            return View();
        }
        [HttpPost]
        public IActionResult Signup(User user)

        {
            user.RollId = 2;
            using (FoodDonationContext db = new FoodDonationContext())
            {
                db.UserMaster.Add(user);
                if (db.SaveChanges() > 0)
                {
                    TempData["signupstatus"] = "ok";
                }
            }
            
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Signin", "Accounts");
        }
    }
}
