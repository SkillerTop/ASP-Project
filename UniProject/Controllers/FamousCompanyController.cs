using Microsoft.AspNetCore.Mvc;
using UniProject;

public class FamousCompanyController : Controller
{
    private readonly FamousCompanyService _companyService;

    public FamousCompanyController(FamousCompanyService companyService)
    {
        _companyService = companyService;
    }

    public IActionResult Index()
    {
        var maxEmployeesCompany = _companyService.GetCompanyWithMostEmployees();

        return View(maxEmployeesCompany);
    }
}
