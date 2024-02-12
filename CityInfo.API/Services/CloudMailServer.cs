namespace CityInfo.API.Services
{
    public class CloudMailServer : IMailServer
    {
        private string _mailTo = string.Empty;
        private string _mailFrom = string.Empty;

        public CloudMailServer(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:MailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(CloudMailServer)}.");
            Console.WriteLine(subject);
            Console.WriteLine(message);
        }
    }
}