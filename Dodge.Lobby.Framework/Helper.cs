using Dodge.Lobby.Framework.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge.Lobby.Framework
{
    public static class Helper
    {
        //public static string Encode(string value)
        //{
        //    var hash = System.Security.Cryptography.SHA1.Create();
        //    var encoder = new ASCIIEncoding();
        //    var combined = encoder.GetBytes(value ?? "");
        //    return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        //}
        //public static string Base64ForUrlEncode(string str)
        //{
        //    byte[] encbuff = Encoding.UTF8.GetBytes(str);
        //    return HttpServerUtility.UrlTokenEncode(encbuff);
        //}

        public static string EncodeTo64(string toEncode)
        {
            try
            {
                byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
                string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string ConvertToJson(AuthReq data)
        {
            try
            {
                return JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
