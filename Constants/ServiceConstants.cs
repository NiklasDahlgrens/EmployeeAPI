namespace EmployeeAPI.Constants
{
    public class ServiceConstants
    {
        #region GroupOne
        public static class GroupOne
        {
            public const string Name = nameof(GroupOne);
            public const string PaymentService = nameof(PaymentService);
            public const string LoggingService = nameof(LoggingService);
            public const string SalesService = nameof(SalesService);
            public const string LocalScheduleService = nameof(LocalScheduleService);
        }

        #endregion
        #region GroupTwo
        public static class GroupTwo
        {
            public const string Name = nameof(GroupTwo);
            public const string PresentationService = nameof(PresentationService);
            public const string LocalService = nameof(LocalService);
        }
        #endregion

        #region GroupThree
        public static class GroupThree
        {
            public const string Name = nameof(GroupThree);
            public const string OrganizerService = nameof(OrganizerService);
        }
        #endregion

        #region GroupFour
        public static class GroupFour
        {
            public const string Name = nameof(GroupFour);
            public const string EventService = nameof(EventService);
            public const string ParticipantBookingService = nameof(ParticipantBookingService);
        }
        #endregion

        #region GroupFive
        public static class GroupFive
        {
            public const string Name = nameof(GroupFive);
            public const string PersonnelClearanceService = nameof(PersonnelClearanceService);
            public const string LoginService = nameof(LoginService);
            public const string EmployeeService = nameof(EmployeeService);
        }
        #endregion

        #region GroupSix
        public static class GroupSix
        {
            public const string Name = nameof(GroupSix);
            public const string MailService = nameof(MailService);
            public const string SponsorService = nameof(SponsorService);
        }
        #endregion

        #region EventTypes
        public static class EventType
        {
            public const string Information = nameof(Information);
            public const string Warning = nameof(Warning);
            public const string Error = nameof(Error);
            public const string Critical = nameof(Critical);
            public const string Suspend = nameof(Suspend);
            public const string Resume = nameof(Resume);
            public const string Stop = nameof(Stop);
            public const string Start = nameof(Start);
        }
        #endregion
        
    }
}
