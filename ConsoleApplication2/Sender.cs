namespace MSMQSpike2
{
    using System;
    using System.Messaging;
    using System.Transactions;

    /// <summary>
    /// Class Sender.
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// The queue path.
        /// </summary>
        private string qPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sender"/> class.
        /// </summary>
        /// <param name="qPath">The q path.</param>
        public Sender(string qPath)
        {
            this.qPath = qPath;
        }

        /// <summary>
        /// Sends the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Send(string text)
        {
            var myData = new MyData { SecretMessage = text };

            var queue = new MessageQueue(this.qPath);
            var msg = new Message { Body = myData };
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                queue.Send(msg, MessageQueueTransactionType.Automatic);
                ts.Complete();
            }

            Console.WriteLine("Sender says - Message Sent");
        }
    }
}
