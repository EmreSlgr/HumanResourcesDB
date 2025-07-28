using System;

public class Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public int DepartmentID { get; set; }       // Eğer varsa ID
    public string DepartmentName { get; set; }  // İsim olarak
    public int PositionID { get; set; }         // Eğer varsa ID
    public string PositionName { get; set; }    // İsim olarak
    public DateTime? HireDate { get; set; }
    public string Phone { get; set; }
    public string RelativePhone { get; set; }
    public string Address { get; set; }
    public string CVFilePath { get; set; }
    public string ProfileImagePath { get; set; }
    public string Email { get; set; }
    public DateTime? StartDate { get; set; }
    public byte[] Photo { get; set; }
    public int? UserID { get; set; }
    public string FullName
    {
        get { return Name + " " + Surname; }
    }

}
