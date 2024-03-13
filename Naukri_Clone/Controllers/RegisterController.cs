    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Naukri_Clone.Models;
    using Naukri_Clone.Service;
    using Naukri_Clone.wwwroot.Service;


namespace Naukri_Clone.Controllers
    {
        public class RegisterController : Controller
        {
            private readonly SeekerDAL seekerDAL;
            private readonly EmpDAL empDAL;


        public RegisterController(IConfiguration configuration)
            {
                seekerDAL = new SeekerDAL(configuration);
                empDAL=new EmpDAL(configuration);
            }

        
        public IActionResult EmpRegister()
            {
                return View();
            }
        [HttpPost]
        public IActionResult EmpRegister(Employer employer)
        {
            if (ModelState.IsValid)
            {
                bool InsertEmployeSuccess = empDAL.InsertEmployer(employer.EFName, employer.ELName, employer.Email, employer.PhoneNumber, employer.Password, employer.DateOfBirth, employer.Designation, employer.OrganizationName);
                if (InsertEmployeSuccess)
                {
                    TempData["InsertEmployeMsg"] = "<script>alert('User Saved Succes..')</script>";
                    return RedirectToAction("EmpLogin", "Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to register seeker. Please try again.");
                    return View(employer);
                }
            }
            return View(employer);
        }



        public IActionResult SeekerRegister() {
            return View();
            }
        [HttpPost]
        
            public IActionResult SeekerRegister(JobSeeker jobSeeker)
            {
                if (ModelState.IsValid)
                {
              
                bool insertionSuccess = seekerDAL.InsertSeeker(jobSeeker.FName, jobSeeker.LName, jobSeeker.Email, jobSeeker.PhoneNumber, jobSeeker.Password, jobSeeker.DateOfBirth);


                if (insertionSuccess)
                    {
                    TempData["InsertMsg"] = "<script>alert('User Saved Succes..')</script>";
                    return RedirectToAction("SeekerLogin","Login");
                    }
                    else
                    {
                      
                        ModelState.AddModelError(string.Empty, "Failed to register seeker. Please try again.");
                        return View(jobSeeker);
                    }
                }

            
                return View(jobSeeker);
            }
        }
    }
