using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Messaging
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)] // This is now a singleton that runs on several threads
    public class MessageService : IMessageService
    {
        #region Private Variables

        // Callback variable, used to send things based on events... like a new user or new message.
        private IMessageCallbackService callback = null; // May need to be initialized...

        private List<String> messageList = new List<String>();
        private Dictionary<String, DateTime> userList = new Dictionary<String, DateTime>();
        private DateTime lastClear = DateTime.Now;

        #endregion

        public MessageService()
        {
            //callback = OperationContext.Current.GetCallbackChannel<IMessageCallbackService>();
        }

        public void LogIn(String userName, String password)
        {
            if (!userList.Keys.Contains(userName))
                userList.Add(userName, DateTime.Now);
        }

        public void LogOff(String userName, String password)
        {
            if (userList.Keys.Contains(userName))
                userList.Remove(userName);
        }

        public void SendMessage(string userName, string message)
        {
            var newStr = userName = ": " + message;


            // Add it to the list
            messageList.Add(newStr);

            // Fire the event to update the new message
            callback.NewMessage(newStr);
        }

        //public List<String> SendReadMessage(String userName, String message)
        //{

        //    messageList.Add(message);

        //    // Can be used to get the last few messages?
        //    // Grab the last COUNT of messages, from the last one up.
        //    // return messageList.Skip(Math.Max(0, messageList.Count() - 20)).ToList<String>();
        //}

        private void clearOldUsers()
        {
            if (DateTime.Now > lastClear)
            {
                userList.Clear();


                lastClear = DateTime.Now.AddMinutes(1);
            }
        }
    }
}
