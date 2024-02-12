namespace CityInfo.API.Services
{
    public class LocalMailServer
    {
        private string _mailTo = "admin@softworx.com";
        private string _mailFrom = "noreply@softworx.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(LocalMailServer)}.");
            Console.WriteLine(subject);
            Console.WriteLine(message);
        }
    }
}