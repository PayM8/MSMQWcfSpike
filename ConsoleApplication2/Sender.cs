namespace MSMQSpike2
{
    using System;
    using System.Messaging;
    using System.Transactions;

    public class Sender
    {
        private string qPath;
        public Sender(string qPath)
        {
            this.qPath = qPath;
        }

        public void Send(string text)
        {
            var myD = new MyData { SecretMessage = text };

            var queue = new MessageQueue(this.qPath);
            var msg = new Message { Body = myD };
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                queue.Send(msg, MessageQueueTransactionType.Automatic);
                ts.Complete();
            }

            Console.WriteLine("Sender says - Message Sent");
        }

    }
}
