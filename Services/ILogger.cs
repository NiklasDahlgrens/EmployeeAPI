using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public interface ILogger
    {
        Task<bool> LoggAsync(string serviceName, string loggEventType, string message);
    }
}