using Microsoft.AspNetCore.Mvc;

namespace UniProject.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
                var company = new CompanyModel
                {
                    Name = "Streamdigo Inc.",
                    YearFounded = 2000,
                    Location = "NewYork"
                };

                Random random = new Random();
                int randomNumber = random.Next(0, 101);

                company.RandomNumber = randomNumber;

                return View(company);
            }
        }
    }
