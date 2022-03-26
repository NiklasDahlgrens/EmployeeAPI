using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Constants;
using EmployeeAPI.Logic;
using EmployeeAPI.Services;
//using Evenue_Group0ne_WebbClient.Models.LoggingModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EmployeeAPI.Services
{
    public class Logger : ILogger
    {
        private readonly string _baseUrl;
        private readonly string _groupName;
        private readonly TraceSource _traceSource = new TraceSource("DefaultTracer");

        public Logger(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("MySettings:BaseApiUrl");
            _groupName = configuration.GetValue<string>("MySettings:GroupName");
            _traceSource.Switch = new SourceSwitch("AllPass") { Level = SourceLevels.All };
        }
        public async Task<bool> LoggAsync(string serviceName, string loggEventType, string message)
        {
            if (!ArgumentsIsNullOrEmpty(serviceName, loggEventType, message)) return false;
            if (!CheckLoggGroup()) return false;
            if (!CheckLoggService(serviceName)) return false;
            if (!CheckLoggEventType(loggEventType)) return false;


            try
            {
                HttpClient client = new HttpClient();
                var jsonString = JsonConvert.SerializeObject(message);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/Json");
                var Url = $"{_baseUrl}{_groupName}/{serviceName}/{loggEventType}/{message}";
                var response = await client.PostAsync(Url, content);
                //var responseString = await response.Content.ReadAsStringAsync();// if loggs dont post check this
                LoggMessageType(loggEventType, 0, message);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }

        private bool ArgumentsIsNullOrEmpty(string serviceName, string loggEventType, string message)
        {
            if (true.CheckNullOrEmpty(serviceName)
                    .CheckNullOrEmpty(loggEventType)
                    .CheckNullOrEmpty(message) is false)
            {
                _traceSource.TraceEvent(TraceEventType.Warning, 0,
                    $"serviceName: {serviceName}, LoggEventType: {loggEventType}, Message: {message}");
                _traceSource.Flush();
                return false;
            }

            ;
            return true;
        }

        private bool CheckLoggEventType(string loggEventType)
        {
            if (true.CheckEventTypeCall(loggEventType) is not false) return true;
            _traceSource.TraceEvent(TraceEventType.Warning, 0,
                $"Argument for logging is spelled incorrectly use service constants. - LoggEventType: {loggEventType}");
            _traceSource.Flush();
            return false;

        }

        private bool CheckLoggService(string serviceName)
        {
            if (true.CheckServiceCall(serviceName) is not false) return true;
            _traceSource.TraceEvent(TraceEventType.Warning, 0,
                $"Argument for logging is spelled incorrectly use service constants. - serviceName: {serviceName}");
            _traceSource.Flush();
            return false;

        }

        private bool CheckLoggGroup()
        {
            if (true.CheckGroupCall(_groupName) is not false) return true;
            _traceSource.TraceEvent(TraceEventType.Warning, 0,
                $"Setting for logging incorrectly configured - appsettings.json GroupName is value: {_groupName}");
            _traceSource.Flush();
            return false;

        }

        private void LoggMessageType(string loggEventTypeName, int loggEventId, string message)
        {
            switch (loggEventTypeName)
            {
                case ServiceConstants.EventType.Critical:
                    _traceSource.TraceEvent(TraceEventType.Critical, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Error:
                    _traceSource.TraceEvent(TraceEventType.Error, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Information:
                    _traceSource.TraceEvent(TraceEventType.Information, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Resume:
                    _traceSource.TraceEvent(TraceEventType.Resume, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Start:
                    _traceSource.TraceEvent(TraceEventType.Start, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Stop:
                    _traceSource.TraceEvent(TraceEventType.Stop, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Suspend:
                    _traceSource.TraceEvent(TraceEventType.Suspend, loggEventId, message);
                    break;
                case ServiceConstants.EventType.Warning:
                    _traceSource.TraceEvent(TraceEventType.Warning, loggEventId, message);
                    break;
                default:
                    break;
            }
            _traceSource.Flush();
        }
    }
}
