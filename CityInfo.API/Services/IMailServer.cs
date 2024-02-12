namespace CityInfo.API.Services
{
    public interface IMailServer
    {
        void Send(string subject, string message);
    }
}