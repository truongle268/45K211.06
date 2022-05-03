using System;
using System.Collections.Generic;
using System.Text;

namespace IMD.Models
{
    public static class Constants
    {
        public static List<string> Admins = new List<string>()
        {
            "admin",
            "admin1",
            "hoangquynh"
        };
        public static bool IsAdmin = false;
        public static string Uid { get; set; }

        public static bool IsDev = true;

        public static string DomainAPI = "http://192.168.1.4:100/api/";

    }
}
