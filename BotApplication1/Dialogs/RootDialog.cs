using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotApplication1.Dialogs
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
            //context.PostAsync("hk");

            // Calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // Return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }

        /*private async Task Greeting(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            if (string.IsNullOrEmpty(message.Text))
            {

                // Hero Card
                var cardMsg = context.MakeMessage();
                var attachment = BotWelcomeCard("Hello,I am a bot.", "");
                cardMsg.Attachments.Add(attachment);
                await context.PostAsync(cardMsg);

            }
            else
            {
                // else code
            }
        }

   
        private static Attachment BotWelcomeCard(string responseFromQNAMaker, string userQuery)
        {
            var heroCard = new HeroCard
            {
                Title = userQuery,
                Subtitle = "",
                Text = responseFromQNAMaker,
                Images = new List<CardImage> { new CardImage("../img/bot.gif") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.ImBack, "Show Menu", value: "Show Bot Menu") }
            };

            return heroCard.ToAttachment();
        }*/
    }
}