namespace MSMQSpike2
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.MsmqIntegration;

    /// <summary>
    /// Class Receiver.
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class Receiver : IMessaging
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Receiver"/> class.
        /// </summary>
        public Receiver()
        {
        }
        
        /// <summary>
        /// Processes the incoming message.
        /// </summary>
        /// <param name="incomingMessage">The incoming message.</param>
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<MyData> incomingMessage)
        {
            Console.WriteLine("Receiver says - received - {0}", incomingMessage.Body.SecretMessage);
        }
    }
}
