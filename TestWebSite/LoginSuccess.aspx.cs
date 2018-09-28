using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginSuccess : System.Web.UI.Page
{
    public string img = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        getRt();
    }

    private string GetFullname(string first, string last)
    {
        var _first = first ?? "";
        var _last = last ?? "";
        if (string.IsNullOrEmpty(_first) || string.IsNullOrEmpty(_last))
            return "";
        return _first + " " + _last;
    }

    private void getgoogleplususerdataSer(string access_token)
    {

        if (access_token != null)
        {

            String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" +
access_token.ToString();

            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(URI);
            string b;

            /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
            using (StreamReader br = new StreamReader(stream))
            {
                b = br.ReadToEnd();
            }

            b = b.Replace("id", "").Replace("email", "");
            b = b.Replace("given_name", "");
            b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
            b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
            b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");

            /*
                 
            "id": "109124950535374******"
              "email": "usernamil@gmail.com"
              "verified_email": true
              "name": "firstname lastname"
              "given_name": "firstname"
              "family_name": "lastname"
              "link": "https://plus.google.com/10912495053537********"
              "picture": "https://lh3.googleusercontent.com/......./photo.jpg"
              "gender": "male"
              "locale": "en" } 
           */

            Array ar = b.Split(",".ToCharArray());
            for (int p = 0; p < ar.Length; p++)
            {
                ar.SetValue(ar.GetValue(p).ToString().Trim(), p);

            }
            string EmailId = ar.GetValue(1).ToString();
            string AnotherId = ar.GetValue(0).ToString();
            string CustomerName = ar.GetValue(4).ToString() + " " + ar.GetValue(5).ToString();
            string Phone = "";
            string userProfilePic = ar.GetValue(7).ToString();
            userProfilePic = userProfilePic.Replace("https", "https:");
            img = userProfilePic;
            string LoginType = "g";
            //int CustomerId = 0;

            //imgProfile.ImageUrl = userProfilePic;
            //ClientEmail.Text = Email_address;
            //ClientName.Text = firstName + " " + LastName;

        }
    }
    private void getRt()
    {

        try
        {
            var url = Request.Url.Query;
            if (url != "")
            {
                string queryString = url.ToString();
                char[] delimiterChars = { '=' };
                string[] words = queryString.Split(delimiterChars);
                string code = words[1];

                if (code != null)
                {
                    //get the access token 
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                    webRequest.Method = "POST";
                    //string Parameters = "code=" + code + "&client_id=590319039890-ch2k0tvs7749rgf8vjp3eeep24n5hj5s.apps.googleusercontent.com&client_secret=qOHQHR2ch1CgFsCNhttul8yZ&redirect_uri=http://localhost:1049/site1/googleReturn.aspx&grant_type=authorization_code";
                    string Parameters = "code=" + code + "&client_id=645346265016-09bade801ee8s618m5ng54cn9b0pi8qt.apps.googleusercontent.com&client_secret=Ozhmx_tUT9-xnraibBctCF8B&redirect_uri=http://localhost:17017/LoginSuccess.aspx&grant_type=authorization_code";
                    byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.ContentLength = byteArray.Length;
                    Stream postStream = webRequest.GetRequestStream();
                    // Add the post data to the web request
                    postStream.Write(byteArray, 0, byteArray.Length);
                    postStream.Close();

                    WebResponse response = webRequest.GetResponse();
                    postStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(postStream);
                    string responseFromServer = reader.ReadToEnd();

                    GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

                    if (serStatus != null)
                    {
                        string accessToken = string.Empty;
                        accessToken = serStatus.access_token;

                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            // This is where you want to add the code if login is successful.
                            getgoogleplususerdataSer(accessToken);
                        }
                        else
                        { }
                    }
                    else
                    { }
                }
                else
                { }
            }
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message, ex);
            //   Response.Redirect("index.aspx");
        }

    }
    public class GooglePlusAccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
        public string refresh_token { get; set; }
    }

    public class GoogleUserOutputData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
    }

}