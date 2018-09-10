using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotApplication.Integrate;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotApplication.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // Calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
            if(length > 0)
            {
                Request request = new Request();
                request.Message = activity.Text.ToString();
                request.SessionId = "";
                var response = DialogFlow.getDialogfloW(request);
        
                // Return our reply to the user
                await context.PostAsync(response);

                context.Wait(MessageReceivedAsync);
                return;
            }
            // Return our reply to the user
            await context.PostAsync($"Invalid request");

            context.Wait(MessageReceivedAsync);
        }
    }
}

