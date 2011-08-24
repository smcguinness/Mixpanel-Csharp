public class Mixpanel
    {
        
        private const string Host = "http://api.mixpanel.com/";
        private string _token;
        private string _mpEvent;
        private Dictionary<string, string> _eventParams;
        // This method that will be called when the thread is started
        public Mixpanel(string token, string mpEvent, Dictionary<string, string> eventParams)
        {
            this._token = token;
            this._mpEvent = mpEvent;
            this._eventParams = eventParams;
        }

        public void Track()
        {
            this._eventParams.Add("token", this._token);
            
            var mpString = new {@event = this._mpEvent, properties = this._eventParams};
            var mpJSON = new JavaScriptSerializer().Serialize(mpString);

            var encbuff = System.Text.Encoding.UTF8.GetBytes(mpJSON);
            var encString = Convert.ToBase64String(encbuff);

            var myReq = (HttpWebRequest)WebRequest.Create(Host + "track/?data=" + encString);
            var myRes = myReq.GetResponse();

        }
    }