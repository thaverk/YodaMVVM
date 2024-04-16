using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using YodaMVVM.Models;
using YodaMVVM.Services.Interface;
using YodaMVVM.Enum;

namespace YodaMVVM.ViewModels
{
    public partial class QuestionViewModel : BaseViewModel
    {

        private IYodaAI _assistant;

        private ObservableCollection<ChatMessage> _chatHistory;

        public ObservableCollection<ChatMessage> ChatHistory
        {
            get { return _chatHistory; }
            set
            {
                _chatHistory = value;

                OnPropertyChanged();
            }
        }

        private string _currentQuestion;
        public string CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;

                OnPropertyChanged();
            }
        }

        public QuestionViewModel(IYodaAI assistant)
        {
            _assistant = assistant;
            ChatHistory = new ObservableCollection<ChatMessage>();
            ChatHistory.Add(new ChatMessage { MessageType = Enum.ChatMessageTypeEnum.Inbound, MessageBody = "Greetings Young Padawan! Help you, how can I? Hmm?" });
        }

        [RelayCommand]
        public async Task ChatSelected(ChatMessage message)
        {
            var navigationParameter = new Dictionary<string, object>
             {
                 { "Response", message }
             };
            await Shell.Current.GoToAsync($"answerpage", navigationParameter);

        }

        [RelayCommand]
        public async Task AskQuestion(ITextInput view, CancellationToken token)
        {
            var inboundMessages = ChatHistory.Where(x => x.MessageType == Enum.ChatMessageTypeEnum.Inbound).ToList();

            var currentChatMessage = new ChatMessage { MessageType = Enum.ChatMessageTypeEnum.Outbound, MessageBody = CurrentQuestion };

            try
            {
                var response = _assistant.GetCompletion(inboundMessages, currentChatMessage);
                ChatHistory.Add(currentChatMessage);

                var responseChatMessage = new ChatMessage { MessageType = Enum.ChatMessageTypeEnum.Inbound, MessageBody = response.Content };
                ChatHistory.Add(responseChatMessage);


                CurrentQuestion = string.Empty;
            }
            catch (Exception ex)
            {

            }
            
            bool isSuccessful = await view.HideKeyboardAsync(token);

        }
    }
}
