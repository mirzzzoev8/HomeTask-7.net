using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class DepartmentServices
{
    private readonly DapperContext _context;
    public DepartmentServices()
    {
        _context = new DapperContext();
    }
    public List<Departments> GetDepartments()
    {
        var qq = "select * from departments";
        return _context.Connection().Query<Departments>(qq).ToList();
    }

    public void AddDepartments(Departments departments)
    {
        var qq = "insert into departments (Name) values (@Name)";
        _context.Connection().Execute(qq,departments);
    }

    public void UpdateDepartments(Departments departments)
    {
        var qq = "update departments set Name = @Name where id = @id";
        _context.Connection().Execute(qq , departments); 
    }
    
    public void DeleteDepartments(int id)
    {
        var qq = "delete from departments where id = @id";
        _context.Connection().Execute(qq, new {Id = id});
    }

}
