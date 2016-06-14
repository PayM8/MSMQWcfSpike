namespace MSMQSpike2
{
    using System;
    using System.Messaging;
    using System.ServiceModel;

    public class ReceiverHost : IDisposable
    {
        private ServiceHost host;

        public ReceiverHost(string qPath)
        {
            var qSubPath = qPath.Substring(qPath.IndexOf("."));
            if (!MessageQueue.Exists(qSubPath))
            {
                Console.WriteLine("Queue missing....creating {0}", qPath);
                MessageQueue.Create(qSubPath, true);
                Console.WriteLine("Created.");
            }

            host = new ServiceHost(typeof(Receiver));
            host.Faulted += host_Faulted;
            host.Open();
            Console.WriteLine("The receiver is ready");
        }
        void host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Faulted. Damn!!");
        }

        public void Dispose()
        {
            if (host != null)
            {
                if (host.State == CommunicationState.Faulted)
                {
                    host.Abort();
                }
                host.Close();
            }
        }
    }
}
