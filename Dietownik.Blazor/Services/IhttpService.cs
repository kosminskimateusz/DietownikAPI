namespace Dietownik.Blazor.Services
{
    public interface IhttpService
    {
        Task<T> Get<T>(string uri);
    }
}
