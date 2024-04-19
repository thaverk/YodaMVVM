using Azure.AI.OpenAI;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodaMVVM.Services.Interface;

namespace YodaMVVM.ViewModels
{
    public partial class FactPageViewModel:BaseViewModel
    {
        private IYodaAI _yodaAI;
        private ChatMessage _chat;

        public ChatMessage Chat
        {
            get { return _chat; }
            set { _chat = value; OnPropertyChanged(); }
        }   

        public FactPageViewModel(IYodaAI aI)
        {
            _yodaAI= aI;   
        }

        [RelayCommand]
        public async void GetFact()
        {
            Chat = await _yodaAI.GetCompletion();
        }
    
    }
}
