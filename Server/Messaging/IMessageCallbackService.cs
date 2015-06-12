using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server.Messaging
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIMessageCallbackService" in both code and config file together.
    [ServiceContract]
    public interface IMessageCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void NewMessage(String message);


    }
}
