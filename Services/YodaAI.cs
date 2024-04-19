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

       

        public async Task<ChatMessage> GetCompletion()
        {
            try
            {

                var client = new OpenAIClient(new Uri(_settings.AzureOpenAiEndPoint), new AzureKeyCredential(_settings.AzureOpenAiKey));
                string deploymentName = "yodaAssignment";

                var chatCompletionsOptions = new ChatCompletionsOptions()
                {


                    Messages =
                {
                    new ChatMessage(ChatRole.System,("You are an AI bot that gives information and fun facts on the Star Wars franchise in the personality of Yoda.")),
                    new ChatMessage(ChatRole.User,("Give me a Fun Fact!")),
                },

                };
                Response<ChatCompletions> response = await client.GetChatCompletionsAsync(deploymentName, chatCompletionsOptions);
                ChatMessage responseMessage = response.Value.Choices[0].Message;

                return responseMessage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
