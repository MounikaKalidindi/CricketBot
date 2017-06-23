using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Crick_Bot
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class HttpReqRes
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public HttpReqRes()
        {

            Method = HttpVerb.GET;
            PostData = "";
        }


        public String MakeRequest()
        {
            String res_str = "";
            //int x = 1;
            //RootObject ro;
            EndPoint = "https://newsapi.org/v1/articles?source=espn-cric-info&sortBy=top&apiKey=70ecac24214846759b5ca1eb23c25329";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.Method = Method.ToString();
            using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
            {
                using (System.IO.Stream res_stream = res.GetResponseStream())
                {
                    if (res_stream != null)
                    {
                        StreamReader read = new StreamReader(res_stream);
                        res_str = read.ReadToEnd();

                    }
                }
            }
            return res_str;
        }

    }
}