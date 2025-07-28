using System;

public class LeaveRequestViewModel
{
    public int LeaveRequestID { get; set; }
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public string LeaveTypeName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public DateTime RequestedDate { get; set; }
    public string Status { get; set; }
}
