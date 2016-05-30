using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Dodge.Lobby.Framework;
using Newtonsoft.Json;
using System.IO;
using Dodge.Lobby.Framework.Entities;

namespace Dodge.Lobby.Data
{
    public class Login
    {
        public Login() { }
        public dynamic Authenticate(string data)
        {
            try
            {
                string url = @"https://ssoqa.construction.com/SingleSignOnWebServicesRest/api/user";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";

                string encodedCred = Helper.EncodeTo64(data);
                AuthReq authPostData = new AuthReq();
                authPostData.Authorization = "Basic " + encodedCred;
                string postData = Helper.ConvertToJson(authPostData);

                byte[] byteArray = Encoding.ASCII.GetBytes(postData);

                req.ContentType = "application/json";
                req.ContentLength = byteArray.Length;

                Stream dataStream = req.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                var response = (HttpWebResponse)req.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                var responseObj = JsonConvert.DeserializeObject<dynamic>(responseString);

                if (responseObj.status.Value == "sucess")
                {
                    return responseObj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
