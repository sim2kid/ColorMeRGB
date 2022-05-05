using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApiKeyService
    {
        Dictionary<string, string> apiKeys = new Dictionary<string, string>()
        {
            { "uU53wvf8MR46QfgLvekWFka5wXxW7e5A", "Postman" },
            { "ZMpNcnWQUGAsyf66QC2ntk46VFFUfKTL", "MVC Front" }
        };

        public bool IsKeyValid(string key) 
        {
            return apiKeys.ContainsKey(key);
        }

        public string WhoIsKey(string key) 
        {
            return apiKeys[key];
        }
    }
}
