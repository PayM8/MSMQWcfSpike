namespace MSMQSpike2
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Class MyData.
    /// </summary>
    [DataContract]
    public class MyData
    {
        /// <summary>
        /// Gets or sets the secret message.
        /// </summary>
        /// <value>The secret message.</value>
        [DataMember]
        public string SecretMessage { get; set; }
    }
}
