using Newtonsoft.Json;

namespace Voiq.ApiClient
{
    public class CallDisposition
    {

        //public static CallDispositions Failed { get; } = new CallDispositions("F", "Failed");
        //public static CallDispositions Busy { get; } = new CallDispositions("B", "Busy Signal");
        //public static CallDispositions NotInService { get; } = new CallDispositions("NIS", "Not In Service");
        //public static CallDispositions NoAnswer { get; } = new CallDispositions("NA", "No Answer");
        //public static CallDispositions Voicemail { get; } = new CallDispositions("VM", "Voicemail");
        //public static CallDispositions WrongNumber { get; } = new CallDispositions("WN", "Wrong Number");
        //public static CallDispositions DoNotCall { get; } = new CallDispositions("DNC", "Do Not Call");
        //public static CallDispositions CallBack { get; } = new CallDispositions("CB", "Call Back");
        //public static CallDispositions InteractiveVoiceResponse { get; } = new CallDispositions("IVR", "Interactive Voice Response");
        //public static CallDispositions SurveyCompleted { get; } = new CallDispositions("SC", "SurveyCompleted");
        //public static CallDispositions NotInterested { get; } = new CallDispositions("NI", "Not Interested");
        //public static CallDispositions PickUpHangUp { get; } = new CallDispositions("PUHU", "Pick Up Hang Up");
        //public static CallDispositions Incomplete { get; } = new CallDispositions("I", "Incomplete");

        //#region Properties

        //public string Name { get; private set; }
        //public string Value { get; private set; }

        //#endregion

        //private CallDispositions(string val, string name)
        //{
        //    Value = val;
        //    Name = name;
        //}

        //public static IEnumerable<CallDispositions> List()
        //{
        //    // alternately, use a dictionary keyed by value
        //    return new[] {
        //        Failed, Busy, NotInService, NoAnswer, Voicemail, WrongNumber, DoNotCall, CallBack, InteractiveVoiceResponse,
        //        SurveyCompleted, NotInterested, PickUpHangUp, Incomplete
        //    };
        //}

        //public static CallDispositions FromString(string CallDispositionsString)
        //{
        //    return List().Single(r => String.Equals(r.Name, CallDispositionsString, StringComparison.OrdinalIgnoreCase));
        //}

        //public static CallDispositions FromValue(string value)
        //{
        //    return List().Single(r => r.Value == value);
        //}


        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }



    }

}