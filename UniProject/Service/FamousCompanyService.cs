using System.Collections.Generic;
using System.IO;
using System.Linq;
using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using System.Xml.Linq;
using UniProject;

public class FamousCompanyService
{
    public FamousCompany GetCompanyWithMostEmployees()
    {
        var xmlDocument = XDocument.Load("CompanyConfig.xml");
        var xmlCompanies = xmlDocument.Root.Elements("company")
            .Select(element => new FamousCompany
            {
                FamousName = element.Attribute("name").Value,
                Employees = int.Parse(element.Attribute("employees").Value)
            });

        var jsonText = File.ReadAllText("CompanyConfig.json");
        var jsonCompanies = JsonConvert.DeserializeObject<List<FamousCompany>>(jsonText);

  
        var iniData = new FileIniDataParser().ReadFile("CompanyConfig.ini");
        var iniCompanies = iniData.Sections
            .Select(section => new FamousCompany
            {
                FamousName = section.SectionName,
                Employees = int.Parse(section.Keys["employees"])
            });

        var allCompanies = xmlCompanies.Concat(jsonCompanies).Concat(iniCompanies);

        var maxEmployeesCompany = allCompanies.OrderByDescending(c => c.Employees).FirstOrDefault();

        return maxEmployeesCompany;
    }
}
