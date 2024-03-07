using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class SalaryServices
{
    private readonly DapperContext _context;
    public SalaryServices()
    {
        _context = new DapperContext();
    }
    public List<Salaries> GetSalaries()
    {
        var qq = "select * from salaries";
        return _context.Connection().Query<Salaries>(qq).ToList();
    }
    public string GetAvgOfSalaries(int id)
    {
        var sql = @"select Avg(s.Amount) from Salaries as s
                    join Employees as e on s.EmployeeID = e.Id 
                    where e.DepartmentID = @id";
        return _context.Connection().Query<AvgOfSalaries>(sql).ToString();
    }
    public List<AvgOfSalaries> GetEmpBySalary(decimal amount)
    {
        var sql = @"select e.Id,e.FirstName,s.Amount
                    from Employees as e
                    join Salaries as s on s.EmployeeId = e.Id
                    where s.Amount > @amount
                    order by s.Amount";
        return _context.Connection().Query<AvgOfSalaries>(sql , new { Amount = amount }).ToList();        
    }
    

    public void AddSalari(Salaries salaries)
    {
        var qq = "insert into salaries (EmployeeId,Amount,Data) values (@EmployeeId,@Amount,@Data)";
        _context.Connection().Execute(qq,salaries);
    }

    public void UpdateSalaries(Salaries salaries)
    {
        var qq = "update salaries set EmployeeId = @EmployeeId,Amount = @Amount,Data = @Data where id = @id";
        _context.Connection().Execute(qq , salaries); 
    }
    
    public void DeleteSalaries(int id)
    {
        var qq = "delete from salaries where id = @id";
        _context.Connection().Execute(qq, new {Id = id});
    }
}
