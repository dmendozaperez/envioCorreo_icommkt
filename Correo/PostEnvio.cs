//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
//using System.Web.Script.Serialization;

//namespace Correo
//{
    public class PostEnvio
    {
        [Microsoft.SqlServer.Server.SqlFunction()]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)]
    public static string envio_correo(SqlString from, SqlString to, SqlString subject, SqlString htmlbody, SqlString textbody)
        {
            string gRequest = "";
            try
            {
                Swagger Swagger = new Swagger();
                Ent_Swagger data = new Ent_Swagger();
                
                data.From = from;
                data.To = to;
                data.Subject = subject;
                data.HtmlBody = htmlbody;
                data.TextBody = textbody;

                //data.From = "bataclub@bata.com.pe";
                //data.To = "david.mendoza@bata.com";
                //data.Subject = "titulo email";
                //data.HtmlBody = "<h1>hola2</h1>";
                //data.TextBody = "Que tal";

                //string jsonData = js.Serialize(data);

                //var  jsonData1 = (JsonConvert.DeserializeObject)data;//js.Serialize(data);

                //var serializer = new JavaScriptSerializer();
                //var ss=n
                //var jsonData = JsonConvert.SerializeObject(data);

                //var jsondata = Correo.JsonConverter.Serialize(data);

                string jsonData = convert_object_jason(data);

                gRequest = Swagger.sendEmail(jsonData);

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //var  jsonData = JsonConvert.DeserializeObject<>(data);//js.Serialize(data);
                //gRequest = Swagger.sendEmail(jsonData);
            }
            catch (Exception exc)
            {
                gRequest = exc.Message;                
            }
            return gRequest;
        }
        public static string  convert_object_jason(Ent_Swagger data)
        {
            string jason_query = "";
            try
            {
                if (data!=null)
                   jason_query = "{\"From\":" + "\"" + data.From.ToString() + "\"" + "," +
                                "\"To\":" + "\"" + data.To.ToString() + "\"" + "," +
                                "\"Subject\":" + "\"" + data.Subject.ToString() + "\"" + "," +
                                "\"HtmlBody\":" + "\"" + data.HtmlBody.ToString() + "\"" + "," +
                                "\"TextBody\":" + "\"" + data.TextBody.ToString() + "\"" + "}";

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return jason_query;
        }    
    }
    public class Swagger
    {
        public static string sendEmail(string value)
        {
            string url = "https://api.trx.icommarketing.com/email";
            string apiKey = "e1880171-6bfc-4f66-b008-d5542c31a9e4";

            var request = HttpWebRequest.Create(url);
            var byteData = Encoding.UTF8.GetBytes(value);

            request.Headers["Authorization"] = "Bearer X-Trx-Api-Key";
            request.ContentType = "application/json";
            request.Headers.Add("X-Trx-Api-Key", apiKey);
            request.Method = "POST";

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteData, 0, byteData.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            }
            catch (WebException e)
            {
                return e.Message;
            }
        }
    }
    public class Ent_Swagger
    {
        public SqlString From { get; set; }
        public SqlString To { get; set; }
        public SqlString Subject { get; set; }
        public SqlString HtmlBody { get; set; }
        public SqlString TextBody { get; set; }
    }
//}
