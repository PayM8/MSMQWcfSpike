namespace MSMQSpike2
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.MsmqIntegration;

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class Receiver : IMessaging
    {
        public Receiver()
        {
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<MyData> incoming)
        {
            Console.WriteLine("Receiver says - recieved - {0}", incoming.Body.SecretMessage);
        }
    }
}
