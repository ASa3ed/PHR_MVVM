using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace CustomActions.Common.Cache
{
    public static class ApplicationProperties
    {
        public const string RequestedPermission = "RequestedPermission";
        public const string LocationKey = "Location";
        public const string LanguageKey = "Language";
        public const string ResendKey = "Resend";
        public const string ResendTimeKey = "ResendTime";
        public const string UserIDKey = "UserID";
        public const string IsLoggedInUserKey = "UserID";
        public const string IsGuestKey = "IsGuest";
        public const string UserBirthDateDayKey = "UserBirthDateDay";
        public const string UserBirthDateMonthKey = "UserBirthDateMonth";
        public const string UserBirthDateYearKey = "UserBirthDateYear";
        public const string TimelineSyncDateKey = "TimelineSyncDate";
        public const string ReturnPageKey = "ReturnPage";
        public const string JwtSecurityTokenKey = "JwtSecurityToken";
        public const string CrownStatusKey = "CrownStatus";
        public const string OnlineBookingBaseURLKey = "onlineBookingBaseURL";
        public const string OPDBaseURLKey = "opdBaseURL";
        public const string LogConnectionStringKey = "logConnectionString";
        public const string TermsArURLKey = "termsArURL";
        public const string TermsEnURLKey = "termsEnURL";
        public const string PrivacyArURLKey = "privacyArURL";
        public const string PrivacyEnURLKey = "privacyEnURL";
        public const string PaymentURLKey = "PaymentURL";
        
        public static bool HasConnectionPopup = false;

        public static string UserBirthDateDay
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(UserBirthDateDayKey))
                    return Application.Current.Properties[UserBirthDateDayKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[UserBirthDateDayKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string UserBirthDateMonth
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(UserBirthDateMonthKey))
                    return Application.Current.Properties[UserBirthDateMonthKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[UserBirthDateMonthKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string UserBirthDateYear
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(UserBirthDateYearKey))
                    return Application.Current.Properties[UserBirthDateYearKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[UserBirthDateYearKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static bool IsGuest {
            get
            {
                if (Application.Current.Properties.ContainsKey(IsGuestKey))
                    return bool.Parse(Application.Current.Properties[IsGuestKey].ToString());
                return true;
            }
            set
            {
                Application.Current.Properties[IsGuestKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string UserID
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(UserIDKey))
                    return Application.Current.Properties[UserIDKey].ToString();
                return string.Empty;
            }
            set
            {
                Application.Current.Properties[UserIDKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static Page ReturnPage
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(ReturnPageKey))
                    return Application.Current.Properties[ReturnPageKey] as Page;
                return null;
            }
            set
            {
                Application.Current.Properties[ReturnPageKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string Location
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(LocationKey))
                    return Application.Current.Properties[LocationKey].ToString();
                return string.Empty;
            }
            set
            {
                Application.Current.Properties[LocationKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string Language
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(LanguageKey))
                    return Application.Current.Properties[LanguageKey].ToString();
                return string.Empty;
            }
            set
            {
                Application.Current.Properties[LanguageKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static FlowDirection FlowDirection
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(LanguageKey))
                {
                    if (Application.Current.Properties[LanguageKey].ToString().Contains("ar"))
                        return FlowDirection.RightToLeft;
                    return FlowDirection.LeftToRight;
                }
                else
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                    if (currentCulture.ToString().Contains("ar"))
                        return FlowDirection.RightToLeft;
                    return FlowDirection.LeftToRight;
                }
            }
        }
        public static DateTime? TimelineSyncDate
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(TimelineSyncDateKey))
                    return Convert.ToDateTime(Application.Current.Properties[TimelineSyncDateKey]);

                return null;
            }
            set
            {
                Application.Current.Properties[TimelineSyncDateKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static int Resend
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(ResendKey))
                    return int.Parse(Application.Current.Properties[ResendKey].ToString());
                return 0;
            }
            set
            {
                Application.Current.Properties[ResendKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static DateTime? ResendTime
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(ResendTimeKey))
                    return DateTime.Parse(((DateTime)Application.Current.Properties[ResendTimeKey]).ToShortTimeString());
                return  null as DateTime?;
            }
            set
            {
                Application.Current.Properties[ResendTimeKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static bool IsLoggedInUser
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(IsLoggedInUserKey))
                    return bool.Parse(Application.Current.Properties[IsLoggedInUserKey].ToString());
                return false;
            }
            set
            {
                Application.Current.Properties[IsLoggedInUserKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public async static System.Threading.Tasks.Task<string> GetToken()
        {
            string token = null;

            try
            {
                 token = await Xamarin.Essentials.SecureStorage.GetAsync("Hellotoken");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message.ToString(), "cancel");
            }

            return token;
        }
        public async static System.Threading.Tasks.Task SetToken(string token)
        {
            try
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("Hellotoken", token);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message.ToString(), "cancel");
            }
        }
        public static int CrownStatus
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(CrownStatusKey))
                    return (int)Application.Current.Properties[CrownStatusKey];
                return 0;
            }
            set
            {
                Application.Current.Properties[CrownStatusKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static FlowDirection FlowDirectionl { get; set; }
        public static void ClearChache()
        {
            var lang = ApplicationProperties.Language;
            var location = ApplicationProperties.Location;
            Application.Current.Properties.Clear();
            Xamarin.Essentials.SecureStorage.RemoveAll();
            ApplicationProperties.Language = lang;
            ApplicationProperties.Location = location;
            Xamarin.Essentials.Preferences.Clear();
        }
        //----------------------------------------------
        public static string OnlineBookingBaseURL
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(OnlineBookingBaseURLKey))
                    return Application.Current.Properties[OnlineBookingBaseURLKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[OnlineBookingBaseURLKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string LogConnectionString
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(LogConnectionStringKey))
                    return Application.Current.Properties[LogConnectionStringKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[LogConnectionStringKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string TermsEnURL
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(TermsEnURLKey))
                    return Application.Current.Properties[TermsEnURLKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[TermsEnURLKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string TermsArURL
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(TermsArURLKey))
                    return Application.Current.Properties[TermsArURLKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[TermsArURLKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string PrivacyArURL
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(PrivacyArURLKey))
                    return Application.Current.Properties[PrivacyArURLKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[PrivacyArURLKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string PrivacyEnURL
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(PrivacyEnURLKey))
                    return Application.Current.Properties[PrivacyEnURLKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[PrivacyEnURLKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        public static string PaymentURL
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(PaymentURLKey))
                    return Application.Current.Properties[PaymentURLKey].ToString();
                return null;
            }
            set
            {
                Application.Current.Properties[PaymentURLKey] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
        

    }
}