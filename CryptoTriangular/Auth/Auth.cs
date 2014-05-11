using System;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Auth
{
    public class AuthUser
    {

        public string getUniqueID(string drive = "")
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();

            //Mix them up and remove some useless 0's
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }

        public ServerPackage ValidateUser()
        {
            try
            {
                //var options = Options.Instance;
                var uniqueId = getUniqueID();
                WebClient client = new WebClient();
                var Server = "http://cryptocurrencyworld.eu/triangular/webservice.php";
                var data = String.Format("cpuid={0}", uniqueId);
                var response = client.UploadString(Server, "POST", data);
                const string a = "45287112549354892144548565456541";
                const string b = "5AUjfdWTz9g57dbVGSVLBb2bZycT18Hi";
                var c = response;
                var temp = read(ParsBytes(c), b, a);
                var deseralizedResponse = JsonConvert.DeserializeObject<JsonResponse>(temp);
                ServerPackage sp = new ServerPackage();
                if (uniqueId != deseralizedResponse.cpuid)
                {
                    return null;
                    //throw new Exception("incorrect uniqueId in relation to id which was get from server.");
                }
                else
                {
                    sp.cpuid = uniqueId;
                }
                sp.locked = Convert.ToBoolean(deseralizedResponse.locked);
                sp.date_added = Convert.ToDateTime(deseralizedResponse.date_added);
                sp.date_expired = Convert.ToDateTime(deseralizedResponse.date_expired);
                sp.date_current_on_server = Convert.ToDateTime(deseralizedResponse.date_current_on_server);
                sp.wallet = deseralizedResponse.wallet;
                sp.newestVersion = deseralizedResponse.newestVersion;
                TimeSpan ts = sp.date_expired - sp.date_current_on_server;
                if (ts.TotalDays < 0)
                {
                    sp.validationResult = ValidationResult.expired;
                    sp.locked = true;
                }
                else if (ts.TotalDays > 0 && sp.locked == false)
                {
                    sp.validationResult = ValidationResult.actual;
                    sp.locked = false;
                }

                return sp;
            }
            catch (Exception e)
            {
                bool timeout = e is WebException;
                //Log.Error(e,timeout);
                if (timeout == true)
                    return null;
            }
            return new ServerPackage();
        }

        public byte[] ParsBytes(string str)
        {
            var decbuff = Convert.FromBase64String(str);
            return decbuff;
        }

        static public String read(byte[] cypher, string KeyString, string IVString)
        {
            var sRet = "";

            var encoding = new UTF8Encoding();
            var Key = encoding.GetBytes(KeyString);
            var IV = encoding.GetBytes(IVString);

            using (var rj = new RijndaelManaged())
            {
                try
                {
                    rj.Padding = PaddingMode.PKCS7;
                    rj.Mode = CipherMode.CBC;
                    rj.KeySize = 256;
                    rj.BlockSize = 256;
                    rj.Key = Key;
                    rj.IV = IV;
                    var ms = new MemoryStream(cypher);

                    using (var cs = new CryptoStream(ms, rj.CreateDecryptor(Key, IV), CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(cs))
                        {
                            sRet = sr.ReadLine();
                        }
                    }
                }
                finally
                {
                    rj.Clear();
                }
            }
            return sRet;
        }

    }
}

