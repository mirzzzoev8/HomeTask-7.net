using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeControllers : ControllerBase
{
    private readonly EmployeeServices _empcontroller;
    public EmployeeControllers()
    {
        _empcontroller = new EmployeeServices();
    }
    [HttpPost("add - employee")]
    public void AddEmployee(Employees employees)
    {
        _empcontroller.AddEmployee(employees);
    }
    [HttpGet("get-employees")]
    public List<Employees> GetEmployees()
    {
        return _empcontroller.GetEmployees();
    }
    [HttpGet("get-employees by department id")]
    public List<Employees> GetEmployeesByDepartmentId(int id)
    {
        return _empcontroller.GetEmployeesByDepartmentId(id);
    }
    

    [HttpPut("update-employee")]
    public void UpdateEmployees(Employees employees)
    {
        _empcontroller.UpdateEmployees(employees);
    }
    [HttpDelete("delete-employee")]
    public void DeleteEmployees(int id)
    {
        _empcontroller.DeleteEmployees(id);
    }
  
}
