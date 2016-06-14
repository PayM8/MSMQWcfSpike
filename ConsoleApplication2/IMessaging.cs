namespace MSMQSpike2
{
    using System.ServiceModel;
    using System.ServiceModel.MsmqIntegration;

    [ServiceContract]
    [ServiceKnownType(typeof(MyData))]
    public interface IMessaging
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessIncomingMessage(MsmqMessage<MyData> incoming);
    }
}
