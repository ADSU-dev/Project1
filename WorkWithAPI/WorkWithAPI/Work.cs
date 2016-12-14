using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithAPI;
using xNet;

namespace WorkWithAPI
{
    class Work
    {
        
        public static String AccTocken = Form2.AccTock;
        //public static String AccTocken = "4240058795.ca8056b.b74fe2b89e5b4424b6a6d9e031ac3a64";
        public static String ClientId = "ca8056bdac6643e5af20294fdf587722";
        //public static String AccTocken = ;
        //public static String ShortCode = "BN86VA8hlQ7";
        /*private String Auth(String Login, String Pass)
        {
            using (var req = new HttpRequest()) {
                char[] simbol = { '-', '&' };
               // req.Get(String.Format(), Login, Pass);
                string[] StrData = req.Response.Address.ToString().Split(simbol);
             
                return StrData[1];
            }
        }*/
        
        static public String MethodAPI(String ShortCode)
        {
            using (var req = new HttpRequest())
            {
                
                
               HttpResponse resp = req.Get(String.Format("https://api.instagram.com/v1/media/shortcode/{0}?access_token={1}", ShortCode, AccTocken));
               
                // return req.Get(String.Format("https://api.instagram.com/v1/media/shortcode/{0}?access_token={1}",ShortCode,AccTocken)).ToString();

               return resp.ToString();
            }
 
        }
        static public String GetRecent()
        {
            using (var req = new HttpRequest())
            {


                HttpResponse resp = req.Get(String.Format("https://api.instagram.com/v1/users/self/media/recent/?access_token={0}",AccTocken));
                return resp.ToString();
            }

        }


        public string AccTock { get; set; }
    }
}

