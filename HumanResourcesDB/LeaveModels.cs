using System;

public class LeaveType
{
    public int LeaveTypeID { get; set; }
    public string LeaveTypeName { get; set; }
}

public class LeaveRequest
{
    public int LeaveRequestID { get; set; }
    public int EmployeeID { get; set; }
    public int LeaveTypeID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalDays { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public DateTime RequestedDate { get; set; }
    public int? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
}

public class Absence
{
    public int AbsenceID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime AbsenceDate { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public DateTime ReportedDate { get; set; }
}
