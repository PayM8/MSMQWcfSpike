namespace MSMQSpike2
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MyData
    {
        [DataMember]
        public string SecretMessage { get; set; }

    }
}
