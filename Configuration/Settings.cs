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
        public string AzureOpenAiKey { get => "d2a68b6fd28a49fbb6f77c53f132dee4"; }
    }
}
