using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class JsonResponse
    {
        public string cpuid { get; set; }
        public string date_added { get; set; }
        public string date_expired { get; set; }
        public string date_current_on_server { get; set; }
        public string wallet { get; set; }
        public string id { get; set; }
        public int locked { get; set; }
        public int promo { get; set; }
        public string lastLogged { get; set; }
        public string newestVersion { get; set; }
    }

    public enum ValidationResult
    {
        actual = 0,
        expired,
        temporary
    }

    public class ServerPackage
    {
        public string cpuid;
        public DateTime date_added;
        public DateTime date_expired;
        public DateTime date_current_on_server;
        public string wallet;
        public bool locked;
        public string newestVersion;

        public ValidationResult validationResult = ValidationResult.temporary;

        public int GetDaysToExpire()
        {
            TimeSpan sp = date_expired - date_current_on_server;
            return Convert.ToInt32(sp.TotalDays);
        }
    }
}
