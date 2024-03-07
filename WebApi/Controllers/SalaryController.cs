using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class SalaryController : ControllerBase
{
    private readonly SalaryServices _salcontroller;
    public SalaryController()
    {
        _salcontroller = new SalaryServices();
    }
    [HttpPost("add - salary")]
    public void AddSalari(Salaries salaries)
    {
        _salcontroller.AddSalari(salaries);
    }
    [HttpGet("get-salaries")]
    public List<Salaries> GetSalaries()
    {
        return _salcontroller.GetSalaries();
    }
    [HttpGet("get-employees by salaries ")]
    public List<AvgOfSalaries> GetEmpBySalaries(decimal amount)
    {
        return _salcontroller.GetEmpBySalary(amount);
    }
    [HttpGet("get-employees by average ")]
    public string GetAvgOfSalaries(int id)
    {
        return _salcontroller.GetAvgOfSalaries(id);
    }
    
    [HttpPut("update-salari")]
    public void UpdateSalaries(Salaries salaries)
    {
        _salcontroller.UpdateSalaries(salaries);
    }
    [HttpDelete("delete-salari")]
    public void DeleteSalaries(int id)
    {
        _salcontroller.DeleteSalaries(id);
    }
  
}
