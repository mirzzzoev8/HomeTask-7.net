using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class EmployeeServices
{
    private readonly DapperContext _context;
    public EmployeeServices()
    {
        _context = new DapperContext();
    }
    public List<Employees> GetEmployees()
    {
        var qq = "select * from employees";
        return _context.Connection().Query<Employees>(qq).ToList();
    }

    public void AddEmployee(Employees employees)
    {
        var qq = "insert into employees (Id,FirstName,LastName,DepartmentId,Position,Hiredate) values (@Id,@FirstName,@LastName,@DepartmentId,@Position,@Hiredate)";
        _context.Connection().Execute(qq,employees);
    }

    public void UpdateEmployees(Employees employees)
    {
        var qq = "update employees set FirstName = @FirstName,LastName = @LastName,DepartmentId = @DepartmentId,Position = @Position,Hiredate = @Hiredate  where id = @id";
        _context.Connection().Execute(qq , employees); 
    }
    
    public void DeleteEmployees(int id)
    {
        var qq = "delete from employees where id = @id";
        _context.Connection().Execute(qq, new {Id = id});
    }
    public List<Employees> GetEmployeesByDepartmentId(int id)
    {
        var qq = @"select e.Id,e.FirstName,e.DepartmentId
                  from Employees as e 
                  join Departments as d on d.Id = e.DepartmentId
                  where e.DepartmentId = @id";
        return _context.Connection().Query<Employees>(qq,new {Id = id}).ToList();          
    } 
    

}
