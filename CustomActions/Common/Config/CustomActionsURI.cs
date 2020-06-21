using CustomActions.Common.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomActions.Common.Config
{
    public class AppConfiguration
    {
        public static string SyncInterval = "300000";
        public static string SourceofBusiness = "2";
        public static int DoctorsListPageCount = 10;
        public static int VisitingDoctorsWidgetListPageCount = 2;
        public static int VisitingDoctorsListPageCount = 10;
    }

    public class URI
    {
#if DEBUG
        public static string BaseURL = "http://10.24.100.142:90/api/";
        public static string BaseAttachmentURL = "http://10.24.100.142:90";
#else

        ////test
        //public static string BaseURL = "http://ahq-test-01:5100/api/";
        //public static string BaseAttachmentURL = "http://ahq-test-01:5100";

        //perf
        //public static string BaseURL = "http://ahq-perf-01:5100/api/";
        //public static string BaseAttachmentURL = "http://ahq-perf-01:5100";

        ////prelive 
        public static string BaseURL = "http://3.122.9.23:5100/api/";
        public static string BaseAttachmentURL = "http://3.122.9.23:5100";

         ////live 
        //public static string BaseURL = "https://www.mydotcare.com/api/";
        //public static string BaseAttachmentURL = "https://www.mydotcare.com";

#endif
        public static string PingUrl = "https://www.yahoo.com/";


        //------------------------------------------------------------------------------- PHR 
        public static string AddDiagnose = BaseURL + "Diagnose/AddDiagnose";
        public static string AddMedication = BaseURL + "Medication/AddMedication";
        public static string ForgetPasswordUrl = BaseURL + "Test/ChangePassword";
        public static string StreamFileUrl = BaseURL + "Test/SaveProfilePicture";
        public static string ResendVerificationCode = BaseURL + "Test/ResendVerificationCode?userID={0}";
        public static string CheckServerAvailabilityUrl = BaseURL + "Test/CheckServerAvailability";

        //---------------------------- PHR -> setting
        public static string GetDomainsURL = BaseURL + "Setting/GetDomainsURL";
        public static string GetTermsPrivacyURL = BaseURL + "Setting/GetTermsPrivacyURL";

        //---------------------------- PHR -> Login
        public static string VerifyAccount = BaseURL + "Login/IsVerifiedUser?userID={0}&verificationCode={1}&isVerified={2}";
        public static string LoginURL = BaseURL + "Login/Login";

        //---------------------------- PHR -> LifeStyle
        public static string LifeStyleLookups = BaseURL + "LifeStyle/GetLifeStyleLookups";
        public static string LifeStyleDataUser = BaseURL + "LifeStyle/GetLifeStylePerUser/{0}";
        public static string UpdateLifeStyleLookup = BaseURL + "LifeStyle/UpdateLifeStylePerLookup/{0}/{1}";

        //---------------------------- PHR -> Register
        public static string CreateUserUrl = BaseURL + "Register/Signup";
        public static string IsUserExistUrl = BaseURL + "Register/IsUser";
        public static string ForgetPass1Url = BaseURL + "Register/forgetpassstepone";
        public static string SetNewPassword = BaseURL + "register/changepass";

        //---------------------------- PHR -> Notification
        public static string SendSMS = BaseURL + "Notification/SendSMS";
        public static string Sendemail = BaseURL + "Notification/Sendemail";

        //---------------------------- PHR -> PersonalData
        public static string GetMainPersonalDataPerUser = BaseURL + "PersonalData/GetMainPersonalDataPerUser/{0}/{1}";
        public static string UpdateUserData = BaseURL + "PersonalData/UpdateUserData";
        public static string GetUserName = BaseURL + "PersonalData/GetUserName/{0}";
        public static string UpdateUserName = BaseURL + "PersonalData/UpdateUserName?userID={0}&Name={1}";
        public static string GetUserPhoto = BaseURL + "PersonalData/GetUserPhoto/{0}";
        public static string UpdateUserPhoto = BaseURL + "PersonalData/UpdateUserPhoto?userID={0}&PhotoName={1}";
        public static string PersonalLookups = BaseURL + "PersonalData/GetPersonalLookups";
        public static string PersonalDataUser = BaseURL + "PersonalData/GetPersonalDataPerUser/{0}";
        public static string UpdatePersonalLookup = BaseURL + "PersonalData/UpdatePersonalDataPerLookup/{0}/{1}";
        public static string CheckNationalID = BaseURL + "PersonalData/CheckNationalIDExists/{0}";
        public static string UpdatePersonalDataPerSingleEntry = BaseURL + "PersonalData/UpdatePersonalDataPerSingleEntry?PropertyName={0}&PropertyNameData={1}&UserID={2}";
        public static string UpdatePersonalUserDataPerSingleEntry = BaseURL + "PersonalData/UpdatePersonalUserDataPerSingleEntry/{0}/{1}";

        //---------------------------- PHR -> Attachments
        public static string innerPagePath_Server = BaseAttachmentURL + "/Attachments/InnerPages/";
        public static string HospitalLogosPath_Server = BaseAttachmentURL + "/Attachments/HospitalLogos/";

        //---------------------------- PHR -> InnerPage
        public static string SaveInnnerPageRecord = BaseURL + "InnerPage/SaveRecordAsync";
        public static string DeleteInnerPageRecord = BaseURL + "InnerPage/DeleteRecord?EntityName={0}&recordId={1}&userId={2}";
        public static string GetCardUrl = BaseURL + "InnerPage/GetRecord?ID={0}&EntityName={1}&Language={2}";

        //---------------------------- PHR -> Reservation
        public static string SaveReservation = BaseURL + "Reservation/SaveReservation";
        public static string SendOPDReservation = BaseURL + "Reservation/SendOPDReservation";


        //---------------------------- PHR -> map Patient by provider
        public static string GetAllEntities = BaseURL + "BusinessUnit/GetAllBusinessUnits?PreferedCountry={0}&orderbyLanguage={1}";
        public static string SyncPatientDataByProvider = BaseURL + "Syncronization/SyncPatientDataByProvider";
        public static string SyncTimelineData = BaseURL + "Syncronization/SyncTimelineData";

        //---------------------------- PHR -> Log 
        public static string Log = BaseURL + "Log/LogForPHRMobile";

        //------------------------------------------------------------------------------------ Online Booking  
        public static string GetSpecs
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "Speciality/GetClinicSpecialtiesData?isArabic={0}&CountryID={1}";
            }
        }
        public static string GetHospitalsLookup
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "BusinessUintContract/GetVisitingDoctorHospitalData?countryId={0}&isArabic={1}";
            }
        }
        public static string GetProfile
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetDoctorProfilePHR?doctorID={0}&countDays={1}&countryId={2}&isArabic={3}";
            }
        }
        public static string GetDoctorPatterns
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "Pattern/GetDoctorPatternsInWeek?countryId={0}&doctorId={1}&startDate={2}&isArabic={3}";
            }
        }
        public static string CheckOnlineBookingServerAvailabilityUrl
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "Test/CheckServerAvailability";
            }
        }
        public static string GetDoctorsListBySpeciality
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetDoctorsListBySpeciality";
            }
        }
        public static string GetVisitingDoctorsPatternBySpeciality
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetVisitingDoctorsPatternBySpeciality?specialityId={0}&countryID={1}&IsArabic={2}&SearchDate={3}";
            }
        }
        public static string SaveReservationOnlineBooking
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/CreateNewReservationPHR";
            }
        }
        public static string GetSearchSpecialty
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetSearchSpecialty?CountryId={0}&Text={1}";
            }
        }
        public static string SaveQuotaReservationOnlineBooking
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/CreateNewReservationPHRQuota";
            }
        }
        public static string CreateNewReservationPHRVisitingDoctor
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/CreateNewReservationPHRVisitingDoctor ";
            }
        }
        public static string GetSearchDoctor
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetSearchDoctor?CountryId={0}&Text={1}&isArabic={2}";
            }
        }
        public static string GetVisitingDoctorsByCountryWidget
        {
            get { return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetVisitingDoctorsByCountryWidget?countryID={0}&IsArabic={1}&getList={2}&page={3}&count={4}"; }
        }

        public static string GetReservationByUserId
        {
            get
            {
                return ApplicationProperties.OnlineBookingBaseURL + "DotCare/GetReservationByUserId?userId={0}&countryId={1}";
            }
        }

        //------------------------------------------------------------------------------------HMIS

        //public static string OPDBooknAppointmentForMobile
        //{
        //    get
        //    {
        //        return ApplicationProperties.OPDBaseURL + "http://ads-medical:9097/OutPatientServices/api/Appointment/BooknAppointmentForMobile";
        //    }
        //}

        //------------------------------------------------------------------------------------UI
        public static string attachmentPath = "/Attachments";
        public static string profilePicturePath = "/ProfilePictures";
        public static string profilePicturePath_LocalDevice = "ProfilePictures";
        public static string innerPagePath_LocalDevice = "InnerPage";

    }
}