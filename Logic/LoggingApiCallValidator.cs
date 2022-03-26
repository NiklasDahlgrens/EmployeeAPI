using static EmployeeAPI.Constants.ServiceConstants;
namespace EmployeeAPI.Logic
{
    public static class LoggingApiCallValidator
    {
        #region @bool checks
        public static bool CheckNullOrEmpty(this bool isNotFailed, string input)
            => isNotFailed is true && !string.IsNullOrEmpty(input);

        public static bool CheckGroupCall(this bool isNotFailed, string group)
            => isNotFailed is true && group is GroupOne.Name
                or GroupTwo.Name
                or GroupThree.Name
                or GroupFour.Name
                or GroupFive.Name
                or GroupSix.Name;

        public static bool CheckServiceAndGroupCall(this bool isNotFailed, string group, string service)
          => isNotFailed is true && group switch
          {
              GroupOne.Name => service
                  is GroupOne.LoggingService
                  or GroupOne.PaymentService
                  or GroupOne.SalesService
                  or GroupOne.LocalScheduleService,

              GroupTwo.Name => service
                  is GroupTwo.LocalService
                  or GroupTwo.PresentationService,

              GroupThree.Name => service
                  is GroupThree.OrganizerService,

              GroupFour.Name => service
                  is GroupFour.ParticipantBookingService
                  or GroupFour.EventService,

              GroupFive.Name => service
                  is GroupFive.LoginService
                  or GroupFive.EmployeeService
                  or GroupFive.PersonnelClearanceService,

              GroupSix.Name => service
                  is GroupSix.MailService
                  or GroupSix.SponsorService,
              _ => false
          };

        public static bool CheckServiceCall(this bool isNotFailed, string service)
            => isNotFailed is true && service
                is GroupOne.LoggingService
                or GroupOne.PaymentService
                or GroupOne.SalesService
                or GroupOne.LocalScheduleService

                or GroupTwo.LocalService
                or GroupTwo.PresentationService

                or GroupThree.OrganizerService

                or GroupFour.ParticipantBookingService
                or GroupFour.EventService

                or GroupFive.PersonnelClearanceService
                or GroupFive.EmployeeService
                or GroupFive.LoginService

                or GroupSix.MailService
                or GroupSix.SponsorService;

        public static bool CheckEventTypeCall(this bool isNotFailed, string eventType)
            => isNotFailed is true && eventType is EventType.Critical
                or EventType.Error
                or EventType.Warning
                or EventType.Information
                or EventType.Resume
                or EventType.Start
                or EventType.Stop
                or EventType.Suspend;
        #endregion
    }
}
