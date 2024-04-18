using Azure;
using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodaMVVM.Configuration;
using YodaMVVM.Models;
using YodaMVVM.Services.Interface;

namespace YodaMVVM.Services
{
    public class YodaAI : IYodaAI
    {
        private ISettings _settings;


        public YodaAI(ISettings settings)
        {
            _settings = settings;
        }

        private IList<ChatRequestMessage> BuildChatContext(IList<ChatMessage> chatInboundHistory, ChatMessage userMessage)
        {
            var chatContext = new List<ChatRequestMessage>();

            foreach (var chatMessage in chatInboundHistory)

                chatContext.Add(new ChatRequestUserMessage(chatMessage.MessageBody));

            chatContext.Add(new ChatRequestUserMessage(userMessage.MessageBody));

            return chatContext;

        }

        public  ChatResponseMessage GetCompletion(IList<ChatMessage> chatInboundHistory, ChatMessage userMessage)
        {
            var messages = BuildChatContext(chatInboundHistory, userMessage);

            var client = new OpenAIClient(new Uri(_settings.AzureOpenAiEndPoint), new AzureKeyCredential(_settings.AzureOpenAiKey));
            string deploymentName = "yodaAssignment";

            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
               

                Messages =
                {
                    new ChatRequestSystemMessage("You are an AI bot that gives information and fun facts on the Star Wars franchise in the personality of Yoda."),
                    new ChatRequestUserMessage("Greetings Young Padawan! Help You,How can I? Hmmm?")
                },
                DeploymentName = deploymentName,
            };


            foreach (var message in messages)

                chatCompletionsOptions.Messages.Add(message);


            Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);


            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
           
            return responseMessage;
            
        }
    }
}
