using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace VanHalenFAQBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            string message = string.Empty;
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            string message = string.Empty;
            if (activity.Type == "conversationUpdate")
            {
                message = "こんにちは";
            }
            else
            {
                int length = (activity.Text ?? string.Empty).Length;
                message = $"You sent {activity.Text} which was {length} characters";
                //CosmosDBで質問を補正
                //QnA Makerへ問合せ
            }
            if (context.UserData.Count==0)
            {
                await context.PostAsync(message);
            }
            context.UserData.SetValue("greeting", "yes");
            activity.Value = message;
            context.Wait(MessageReceivedAsync);
        }
    }
    class MessageActivity : IMessageActivity
    {
        public string Locale { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Speak { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InputHint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Summary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TextFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AttachmentLayout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IList<Attachment> Attachments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SuggestedActions SuggestedActions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IList<Entity> Entities { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Importance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DeliveryMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset? Expiration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ServiceUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset? Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset? LocalTimestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ChannelId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ChannelAccount From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ConversationAccount Conversation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ChannelAccount Recipient { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ReplyToId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic ChannelData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IContactRelationUpdateActivity AsContactRelationUpdateActivity()
        {
            throw new NotImplementedException();
        }

        public IConversationUpdateActivity AsConversationUpdateActivity()
        {
            throw new NotImplementedException();
        }

        public IEndOfConversationActivity AsEndOfConversationActivity()
        {
            throw new NotImplementedException();
        }

        public IEventActivity AsEventActivity()
        {
            throw new NotImplementedException();
        }

        public IInstallationUpdateActivity AsInstallationUpdateActivity()
        {
            throw new NotImplementedException();
        }

        public IInvokeActivity AsInvokeActivity()
        {
            throw new NotImplementedException();
        }

        public IMessageActivity AsMessageActivity()
        {
            throw new NotImplementedException();
        }

        public IMessageDeleteActivity AsMessageDeleteActivity()
        {
            throw new NotImplementedException();
        }

        public IMessageReactionActivity AsMessageReactionActivity()
        {
            throw new NotImplementedException();
        }

        public IMessageUpdateActivity AsMessageUpdateActivity()
        {
            throw new NotImplementedException();
        }

        public ISuggestionActivity AsSuggestionActivity()
        {
            throw new NotImplementedException();
        }

        public ITraceActivity AsTraceActivity()
        {
            throw new NotImplementedException();
        }

        public ITypingActivity AsTypingActivity()
        {
            throw new NotImplementedException();
        }

        public TypeT GetChannelData<TypeT>()
        {
            throw new NotImplementedException();
        }

        public Mention[] GetMentions()
        {
            throw new NotImplementedException();
        }

        public bool HasContent()
        {
            throw new NotImplementedException();
        }

        public bool TryGetChannelData<TypeT>(out TypeT instance)
        {
            throw new NotImplementedException();
        }
    }
}