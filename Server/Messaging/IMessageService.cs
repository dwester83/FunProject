using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Messaging
{
    [ServiceContract(CallbackContract = typeof(IMessageCallbackService))] //, SessionMode = SessionMode.Required)]
    public interface IMessageService
    {
        [OperationContract]
        void LogIn(String userName, String password);

        [OperationContract]
        void LogOff(String userName, String password);

        [OperationContract(IsOneWay = true)]
        void SendMessage(String userName, String message);
    }
}
