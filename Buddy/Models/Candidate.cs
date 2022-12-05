using System.ComponentModel.DataAnnotations;
namespace Buddy.Models
{
    public class Candidate
    {
        [Key]
    public int CandidateID {get;set;}
    public string? FirstName {get;set;}
    public string? LastName {get;set;}
    
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get;set;}
    public long IDNumber {get;set;}
    public long ContactNumber {get;set;}
    [EmailAddress]
    public string? EmailAddress {get;set;}
    [DataType(DataType.Date)]
    public DateTime hireDate {get;set;}
    }
}