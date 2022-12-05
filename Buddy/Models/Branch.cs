using System.ComponentModel.DataAnnotations;
namespace Buddy.Models
{
    public class Branch
    {
        [Key]
        public int BranchID {get;set;}
        public string Name {get;set;}
        public bool isActive {get;set;}
        public BranchType branchType {get;set;}

        List<Employee>? Employees {get;set;}
        List<Candidate>? Candidates {get;set;}
    }

    public enum BranchType
    {
        Stallite, Remote, Main
    }
}