using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PietieHostelManager
{
    internal class AuditLogger
    {
        private static readonly string connectionString =
                @"Server=localhost;Database=HostelManagementSystem;Integrated Security=True;TrustServerCertificate=True;";

        public static void LogAction(
            string recordType,
            int givenID,
            string details)
        {
            if (string.IsNullOrWhiteSpace(AppSession.CurrentUsername))
            {
                throw new InvalidOperationException(
                    "Cannot create an audit entry because no user is signed in.");
            }

            string sql = @"
                INSERT INTO AuditLog
                    (Username, RecordType, GivenID, QueryDate, Details)
                VALUES
                    (@Username, @RecordType, @GivenID, @QueryDate, @Details);";

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue(
                    "@Username", AppSession.CurrentUsername);

                cmd.Parameters.AddWithValue(
                    "@RecordType", recordType);

                cmd.Parameters.AddWithValue(
                    "@GivenID", givenID);

                cmd.Parameters.AddWithValue(
                    "@QueryDate", DateTime.Today);

                cmd.Parameters.AddWithValue(
                    "@Details", details);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}