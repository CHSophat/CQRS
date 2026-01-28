using Domain.Entities;


namespace Application.DTOs.Products
{
    public class PayrollDto
    {
    public string SalaryMonth { get; set; } // Format: "YYYY-MM"
    public decimal BaseSalary { get; set; }
    public decimal Allowance { get; set; }
    public decimal Deduction { get; set; }
    public decimal NetSalary { get; set; }
    public DateTime? PaidDate { get; set; }

    // Foreign keys
    public int EmployeeId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }

    }
}

