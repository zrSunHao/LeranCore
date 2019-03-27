using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Sun.DatingApp.Utility.WebUtility
{
    public static class WebClientUtility
    {
        public static T GetJson<T>(string url, NameValueCollection headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json;charset=utf-8";
            httpWebRequest.Method = "GET";

            if (headers != null)
            {
                httpWebRequest.Headers.Add(headers);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var jsonStr = streamReader.ReadToEnd();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                return result;
            }
        }

        public static T Post<T>(string url, string paras, NameValueCollection headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add(headers);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(paras);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var jsonStr = streamReader.ReadToEnd();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                return result;
            }
        }

        public static T PostJson<T>(string url, object dto, NameValueCollection headers)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json;charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add(headers);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var jsonStr = streamReader.ReadToEnd();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                return result;
            }
        }

    }
}
