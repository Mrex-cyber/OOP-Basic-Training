namespace OOPTraining
{    
    class Direct<T, P> 
        where T : Message 
        where P : Person<int, string>
    {
        public void SendMessage(P sender, P receiver, T message)
        {
            Console.WriteLine("From " + sender.Name);
            Console.WriteLine("To " + receiver.Name);
            Console.WriteLine("Message: " + message.Text);
        }
    }
    class Message
    {
        public string Text { get; }
        public Message(string text)
        {
            Text = text;
        }        
    }


    class EmailMessage : Message
    {        
        public EmailMessage(string text) : base(text) { }
    }
    class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
    }
}
