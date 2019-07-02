using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PruebaCorreo
{
    class Program
    {
        static void Main(string[] args)
        {
            //string jason_query = "{\"From\":" + "\"bataclub@bata.com.pe\"" + "," +
            //                    "\"To\":" + "\"david.mendoza@bata.com\"" + "," +
            //                    "\"Subject\":" + "\"titulo email\"" + "," +
            //                    "\"HtmlBody\":" + "\"<h1>hola2</h1>\"" + "," +
            //                    "\"TextBody\":" + "\"Que tal\"" + "}";
           // DataSet ds = new DataSet();
           // using (SqlConnection cn = new SqlConnection("Server=172.28.7.14;Database=BDPOS;User ID=pos_oracle;Password=Bata2018**;Trusted_Connection=False;"))
           // {
           //     using (SqlCommand cmd = new SqlCommand("select html from tformato_html where codigo='BB'",cn))
           //     {
           //         cmd.CommandType = CommandType.Text;
           //         SqlDataAdapter da = new SqlDataAdapter(cmd);
           //         da.Fill(ds);
           //     }
           // }
           // string html = ds.Tables[0].Rows[0]["html"].ToString();
           ////-- s = s.Replace(""","\"");
           // html = html.Replace("\"", "'");
           // html = html.Replace("bataclubcodigobarra", @"http://posperu.bgr.pe/ws_ec/barra/201906/45AA7EA569EC42F.png");

            PostEnvio.envio_correo("bataclub@bata.com.pe", "david_mendozap@hotmail.com", "Actualización de registro Bata Club", "", "Que tal");
        }
    }
}
