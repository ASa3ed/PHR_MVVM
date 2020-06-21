using CustomActions.Common.Cache;
using CustomActions.Common.Translation.Resx;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CustomActions.Common
{
    public  class DateHelper
    {
        public static string GetStringDate(DateTime? DatePattern, string format = null)
        {
            if (DatePattern != null)
            {

                if (format == "yyyy-MM-dd")
                {
                    return DatePattern.Value.Year + "-" + DatePattern.Value.Month + "-" + DatePattern.Value.Day;
                }
                else if (format == "dd-MM-yyyy")
                {
                    return DatePattern.Value.Day + "-" + DatePattern.Value.Month + "-" + DatePattern.Value.Year;
                }
                //"dd/MM/yyyy" format
                else if (ApplicationProperties.Language == "ar")
                {
                    var month = (DatePattern.Value.Month.ToString().Length == 1) ? '0' + DatePattern.Value.Month.ToString() : DatePattern.Value.Month.ToString();
                    var day = (DatePattern.Value.Day.ToString().Length == 1) ? '0' + DatePattern.Value.Day.ToString() : DatePattern.Value.Day.ToString();
                    if (format == "dd/MM/yyyy")
                        return day + "/" + month + "/" + DatePattern.Value.Year;
                    else
                        return DatePattern.Value.Year + "/" + month + "/" + day;
                }
                else
                {
                    return DatePattern.Value.Day + "/" + DatePattern.Value.Month + "/" + DatePattern.Value.Year;
                }

            }
            else
            {
                return null;
            }
        }

        public static string ConvertDateToString(DateTime? date)
        {
            if (date == null)
                return null;

            string newdate;

            if (ApplicationProperties.Language == "ar")
            {
                var input = date.Value.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                newdate = ConvertNumberToArabic(input);
            }
            else
                newdate = date.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            return newdate;
        }


        public static string ConvertStringEnglishDateToArabic(string date)
        {
            if (string.IsNullOrEmpty(date)) return null;
            //if(string.Format("MM/dd/yyyy",date))
            //{
            //  date=  DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
            //}
           
            var _date = date.Split('/');
            var ddd = new DateTime(int.Parse(_date[2]), int.Parse(_date[1]), int.Parse(_date[0]));
           return ConvertDateToString(ddd);
           
        }
        public static string ConvertStringArabicDateToEnglish(string date)
        {
            if (string.IsNullOrEmpty(date)) return null;

            var _date = date.Split('/');
            
            var _newdate = _date[2] + '/' + _date[1] + '/' + _date[0];
            if(_date[1].StartsWith("0")|| _date[1].StartsWith("٠"))
            {
                _date[1] = _date[1].Substring(1, 1);
            }
            return ConvertNumberToEnglish(_newdate);
        }
        public static string ConvertNumberToArabic(string input)
        {
            if (ApplicationProperties.Language == "en") return input;

            return input.Replace('0', '٠')
                    .Replace('1', '١')
                    .Replace('2', '٢')
                    .Replace('3', '٣')
                    .Replace('4', '٤')
                    .Replace('5', '٥')
                    .Replace('6', '٦')
                    .Replace('7', '٧')
                    .Replace('8', '٨')
                    .Replace('9', '٩')
                    .Replace("AM", "ص")
                    .Replace("PM", "م");
        }

        public static string ConvertNumberToEnglish(string input)
        {
            return input.Replace('٠','0' )
                    .Replace('١','1' )
                    .Replace('٢','2' )
                    .Replace('٣','3' )
                    .Replace('٤','4' )
                    .Replace('٥','5' )
                    .Replace('٦','6' )
                    .Replace('٧','7' )
                    .Replace('٨','8' )
                    .Replace('٩','9' );
        }

        public static string convertEnglishTimeToArabic(string value)
        {
            if (value == null) return null;

            var str = (string)value;

            var arr = str.Trim().Split(':');

            TimeSpan timeSpan = new TimeSpan(int.Parse(arr[0]), int.Parse(arr[1]), 0);

            DateTime time = DateTime.Today.Add(timeSpan);

            string displayTime = time.ToString("hh:mm tt");

            if (ApplicationProperties.Language == "ar")
            {
                displayTime = CustomActions.Common.DateHelper.ConvertNumberToArabic(displayTime);
            }

            return displayTime;
        }
        public static int ConvertNumberToArabic(int input)
        {
            if (ApplicationProperties.Language == "en") return input;

            var output = input.ToString().Replace('0', '٠')
                    .Replace('1', '١')
                    .Replace('2', '٢')
                    .Replace('3', '٣')
                    .Replace('4', '٤')
                    .Replace('5', '٥')
                    .Replace('6', '٦')
                    .Replace('7', '٧')
                    .Replace('8', '٨')
                    .Replace('9', '٩');

            return int.Parse(output);
        }
        public static string GetDayName(DateTime date)
        {
            var cr = Plugin.Multilingual.CrossMultilingual.Current.CurrentCultureInfo;
            if (date.Date == DateTime.Now.Date)
            {
                return Resource.ResourceManager.GetString("Today", cr);
            }
            else if (date.Date == DateTime.Now.Date.AddDays(1))
            {
                return Resource.ResourceManager.GetString("Tomorrow", cr) ;
            }
            else
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        return Resource.ResourceManager.GetString("Saturday", cr);

                    case DayOfWeek.Sunday:
                        return Resource.ResourceManager.GetString("Sunday", cr);

                    case DayOfWeek.Monday:
                        return Resource.ResourceManager.GetString("Monday", cr);
                    case DayOfWeek.Thursday:
                        return Resource.ResourceManager.GetString("Thursday", cr);

                    case DayOfWeek.Tuesday:
                        return Resource.ResourceManager.GetString("Tuesday", cr);

                    case DayOfWeek.Wednesday:
                        return Resource.ResourceManager.GetString("Wednesday", cr);

                    case DayOfWeek.Friday:
                        return Resource.ResourceManager.GetString("Friday", cr);

                    default:
                        return string.Empty;
                };
            }
        }
    }
}
