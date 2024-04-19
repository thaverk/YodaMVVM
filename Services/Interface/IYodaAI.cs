using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodaMVVM.Models;
using YodaMVVM.Services.Interface;
using YodaMVVM.ViewModels;
using YodaMVVM.Services;

namespace YodaMVVM.Services.Interface
{
    public interface IYodaAI
    {

        Task<ChatMessage> GetCompletion();
    }
}
