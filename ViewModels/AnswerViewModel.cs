using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodaMVVM.Models;

namespace YodaMVVM.ViewModels
{

    [QueryProperty(nameof(Response), "Response")]

    public class AnswerViewModel:BaseViewModel
    {

        private ChatMessage _questionResponseModel;
        public ChatMessage Response
        {
            get { return _questionResponseModel; }
            set
            {
                _questionResponseModel = value;

                OnPropertyChanged();
            }
        }

        
    }



}

