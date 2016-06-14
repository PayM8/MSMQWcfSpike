namespace MSMQSpike2
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var qPath = @"FormatName:Direct=OS:.\Private$\Spike";
            var c = new ReceiverHost(qPath);
            Console.WriteLine("Enter message to send or 'X' to exit.");
            var txt = Console.ReadLine();
            if(txt.ToUpper()=="X")
            {
                return;
            }

            var s = new Sender(qPath);
            while (txt.ToUpper() != "X")
            {
                s.Send(txt);
                txt = Console.ReadLine();
            }
        }
    }
}
