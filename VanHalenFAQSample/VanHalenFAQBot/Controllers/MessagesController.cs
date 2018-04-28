using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace VanHalenFAQBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            #region
            //var userAccount = new ChannelAccount(name: "Larry", id: "b106dbec-356a-4ab0-87bb-7a8656ef12eb");
            //var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            //var length = activity.Text.Length;
            //Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
            //await connector.Conversations.ReplyToActivityAsync(reply);

            //var connector = new ConnectorClient(new Uri(actvity.ServiceUrl));
            //var conversationId = await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount);

            //IMessageActivity message = Activity.CreateMessageActivity();
            //message.From = botAccount;
            //message.Recipient = userAccount;
            //message.Conversation = new ConversationAccount(id: conversationId.Id);
            //message.Text = "Hello, Larry!";
            //message.Locale = "en-Us";
            //await connector.Conversations.SendToConversationAsync((Activity)message);
            #endregion
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                new Task(async () =>
                {
                    await Conversation.SendAsync(message, () => new Dialogs.RootDialog());
                }).RunSynchronously();
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
                System.Diagnostics.Debug.Print("");
            }

            return null;
        }
    }
}