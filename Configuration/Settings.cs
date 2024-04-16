using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodaMVVM.Configuration
{
    public class Settings:ISettings
    {

        public string AzureOpenAiEndPoint { get => "https://ketyodaassignment.openai.azure.com/"; }
        public string AzureOpenAiKey { get => "5f2751f73a5a419885b2194b045ce2f5"; }
    }
}
