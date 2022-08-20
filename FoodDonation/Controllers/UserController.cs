using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using FoodDonation.Models;

namespace FoodDonation.Controllers
{
    public class UserController : Controller
    {

        /*public IActionResult GetFoodRequestDonors()
        {
            List<User> users = new List<User>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.UserMaster.Where(x => x.RollId == 2 &&  x.DonorCategory == "Food Request").ToList();
            }
            return View(users);
        }
        public IActionResult GetLogisticsRequestDonors()
        {
            List<User> users = new List<User>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.UserMaster.Where(x => x.RollId == 2 && x.DonorCategory == "Logistics sponsor").ToList();
            }
            return View(users);
        }*/
        public IActionResult ViewUsers() // admin can see all the details of the users 
        {
            List<User> users = new List<User>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.UserMaster.Where(x => x.RollId == 2).ToList();
            }
            return View(users);
        }
        public IActionResult ManageUser() // admin managing the users edit and delete
        {
            List<User> users = new List<User>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.UserMaster.Where(x => x.RollId == 2).ToList();
            }
            return View(users);
            
        }

        [HttpGet]
        public IActionResult Edit(string email)
        {
            List<SelectListItem> DonorCategory = new List<SelectListItem>
            {
                new SelectListItem{Value="Food Donor",Text="Food Donor" },
                new SelectListItem{Value="Logistics sponsor",Text="Logistics sponsor" }

            };
            ViewBag.DonorCategory = DonorCategory;
            using (FoodDonationContext db = new FoodDonationContext())
            {
                var row = db.UserMaster.Where(x => x.Email == email).FirstOrDefault();
                
                return View(row);

            }
              
        }
        [HttpPost]
        public IActionResult Edit(User user )
        {
            using (FoodDonationContext db = new FoodDonationContext())
            {
                //db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var row =db.UserMaster.Where(x => x.Email == user.Email).FirstOrDefault();
                var result = db.UserMaster.Find(user.Email);
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.DOB= user.DOB;
                result.Gender = user.Gender;
                result.MobileNo = user.MobileNo;
                result.Email = user.Email;
                result.UserId = user.UserId;
                result.Password = user.Password;
                
                 
                //db.UserMaster.Update(row);
                //int a=await db.SaveChangesAsync();
                int a = db.SaveChanges();
                ModelState.Clear();
                if (a > 0)
                {
                    TempData["Update"] = "ok";

                }
                return View();
                
            }
            

        }
        [HttpGet]
        public IActionResult Delete(string id) 
        {
            using (FoodDonationContext db=new FoodDonationContext())
            {
                var user=db.UserMaster.Where(x=>x.UserId==id).FirstOrDefault();
                db.UserMaster.Remove(user);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.DeleteMessage = "<script>alert('Data Deleted!!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.DeleteMessage = "<script>alert('Data not Deleted!!')</script>";

                }

            }
            return RedirectToAction("ManageUser", "User");
        
        }
      
        public IActionResult LogisticsRequest() // admin requesting users for Logistics donation
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogisticsRequest(LogisticRequest logistic) // admin requesting users for Logistics donation
        {
            using (FoodDonationContext db = new FoodDonationContext())
            {
                db.LogisticRequest.Add(logistic);
                if (db.SaveChanges() > 0)
                {
                    TempData["logisticrequeststatus"] = "ok";
                }
            }
            return View();
        }

        public IActionResult FoodRequest() // admin requesting users for food donation
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult FoodRequest(FoodRequest foodrequest) // admin requesting users for food donation
        {
            using (FoodDonationContext db = new FoodDonationContext())
            {
                db.FoodRequest.Add(foodrequest);
                if (db.SaveChanges() > 0)
                {
                    TempData["foodrequeststatus"] = "ok";
                }
            }
            return View();
        }
        public IActionResult UserFoodRequest()//admins can view all the food donation request of users who are willing to donate the food
        {
            List<FoodDonationRequestByUser> users = new List<FoodDonationRequestByUser>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.FoodDonationRequest.Select(x => x).ToList();
            }
            return View(users);
        }
        public IActionResult UserLogisticRequest()//admins can view all the Logistic donation request of users who are willing to provide logistic facilities
        {
            List<LogisticDonationRequestByUser> users = new List<LogisticDonationRequestByUser>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.LogisticDonationRequest.Select(x => x).ToList();
            }
            return View(users);
        }

        public IActionResult FoodDonationRequest() // users willing to donate food- users will raise a food donation request
        {
            return View();
        }
        [HttpPost]
        public IActionResult FoodDonationRequest(FoodDonationRequestByUser foodrequest) // users willing to donate food- users will raise a food donation request
        {
            using (FoodDonationContext db = new FoodDonationContext())
            {
                db.FoodDonationRequest.Add(foodrequest);
                if (db.SaveChanges() > 0)
                {
                    TempData["foodDonationrequeststatus"] = "ok";
                }
            }
            return View();
        }
        public IActionResult LogisticDonationRequest() // users willing to donate Logistic- users will raise a Logistic donation request
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogisticDonationRequest(LogisticDonationRequestByUser logistic) // users willing to donate Logistic- users will raise a Logistic donation request
        {
            using (FoodDonationContext db = new FoodDonationContext())
            {
                db.LogisticDonationRequest.Add(logistic);
                if (db.SaveChanges() > 0)
                {
                    TempData["LogisticDonationrequeststatus"] = "ok";
                }
            }
            return View();
        }

        public IActionResult ViewFoodRequired() //users can see the required food request raised by admin
        {
            List<FoodRequest> users = new List<FoodRequest>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.FoodRequest.Select(x => x).ToList();
            }
            return View(users); 
        }
        public IActionResult ViewLogisticRequired() //users can see the required Logistic request raised by admin
        {
            List<LogisticRequest> users = new List<LogisticRequest>();
            using (FoodDonationContext db = new FoodDonationContext())
            {
                users = db.LogisticRequest.Select(x => x).ToList();
            }
            return View(users);
        }

    }
}
