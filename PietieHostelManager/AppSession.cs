using System;
using System.Collections.Generic;
using System.Text;

namespace PietieHostelManager
{
    internal class AppSession
    {
        public static string CurrentUsername { get;private set; } = string.Empty;

        public static string CurrentRole { get;private set; } = string.Empty;

        public static bool IsAdmin =>
            string.Equals(CurrentRole, "Admin",
                StringComparison.OrdinalIgnoreCase);

        public static bool IsUser =>
            string.Equals(CurrentRole, "User",
                StringComparison.OrdinalIgnoreCase);

        public static void SetUser(string username, string role)
        {
            CurrentUsername = username;
            CurrentRole = role;
        }

        public static void ClearUser()
        {
            CurrentUsername = string.Empty;
            CurrentRole = string.Empty;
        }
    }
}
