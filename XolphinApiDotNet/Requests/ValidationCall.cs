using System;
using XolphinApiDotNet.Models.Request;

namespace XolphinApiDotNet.Requests
{
    public class ValidationCall
    {

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ExtensionNumber { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public string Action { get; set; } 
        public string Language { get; set; }
        public string Timezone { get; set; }

        public ValidationCall()
        {

        }

		public ValidationCall SetId(int id)
		{
			Id = id;
			return this;
		}
		public ValidationCall SetDate(string date)
		{ 
			Date = date;
			return this;
		}
        public ValidationCall SetTime(string time)
        {
            Time = time;
            return this;
        }
        public ValidationCall SetTimezone(string timezone)
        {
            Timezone = timezone;
            return this;
        }
        public ValidationCall SetPhoneNumber(string phoneNumber){
			PhoneNumber = phoneNumber;
			return this;
		}
		public ValidationCall SetExtensionNumber(string extensionNumber){
			ExtensionNumber = extensionNumber;
			return this;
		}
		public ValidationCall SetEmail(string email){
			Email = email;
			return this;
		}
		public ValidationCall SetComments(string comments){
			Comments = comments;
			return this;
		}
		public ValidationCall SetAction(string action){
			Action = action;
			return this;
		}
		public ValidationCall SetLanguage(string language){
			Language = language;
			return this;
		}


    }
}