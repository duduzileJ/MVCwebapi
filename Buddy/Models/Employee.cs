using System.ComponentModel.DataAnnotations;
namespace Buddy.Models
{
    public class Employee
    {
        [Key]
        public int EmpID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public bool isActive {get;set;}
        public EmployeeType employeeType {get;set;}
        public EmployeeRole employeeRole {get;set;}
        
    }
    public enum EmployeeType
    {
        Volunteer, Contract, Permanent
    }
    public enum EmployeeRole
    {
        Manager, Owner, FirstAssistant, General
    }
}