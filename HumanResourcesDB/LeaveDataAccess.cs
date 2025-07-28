using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class LeaveDataAccess
{
    private string connectionString;

    public LeaveDataAccess()
    {
        connectionString = ConfigurationManager.ConnectionStrings["HRDbConnection"].ConnectionString;
    }

    public List<LeaveType> GetLeaveTypes()
    {
        var list = new List<LeaveType>();
        using (var conn = new SqlConnection(connectionString))
        {
            string query = "SELECT LeaveTypeID, LeaveTypeName FROM LeaveTypes";
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new LeaveType
                    {
                        LeaveTypeID = reader.GetInt32(0),
                        LeaveTypeName = reader.GetString(1)
                    });
                }
            }
        }
        return list;
    }

    public bool AddLeaveRequest(LeaveRequest leaveRequest)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO LeaveRequests
                             (EmployeeID, LeaveTypeID, StartDate, EndDate, TotalDays, Reason, Status, RequestedDate)
                             VALUES
                             (@EmployeeID, @LeaveTypeID, @StartDate, @EndDate, @TotalDays, @Reason, @Status, @RequestedDate)";

            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", leaveRequest.EmployeeID);
                cmd.Parameters.AddWithValue("@LeaveTypeID", leaveRequest.LeaveTypeID);
                cmd.Parameters.AddWithValue("@StartDate", leaveRequest.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", leaveRequest.EndDate);
                cmd.Parameters.AddWithValue("@TotalDays", leaveRequest.TotalDays);
                cmd.Parameters.AddWithValue("@Reason", leaveRequest.Reason ?? "");
                cmd.Parameters.AddWithValue("@Status", leaveRequest.Status ?? "Beklemede");
                cmd.Parameters.AddWithValue("@RequestedDate", leaveRequest.RequestedDate);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
