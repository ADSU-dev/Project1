using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkWithAPI;
namespace WorkWithAPI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       // String log, pass;


        public static String AccTock;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public void Form2_Load(object sender, EventArgs e)
        {
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            try
            {
                System.IO.Directory.Delete(Path, true);
            }
            catch (Exception)
            {
            }//cache clear
            //InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            //webBrowser1.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<    a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(    c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((    new Date()).getTime()-1e11).toGMTString());}}}})())");
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");//— полная очистка кэша браузера
            webBrowser1.Navigate("https://www.instagram.com/accounts/login/?force_classic_login");
           
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            String ssilka = webBrowser1.Url.ToString();
            if (ssilka == "https://www.instagram.com/")
            {
                webBrowser1.Navigate("https://api.instagram.com/oauth/authorize/?client_id=ca8056bdac6643e5af20294fdf587722&redirect_uri=https://vk.com/dolik_k&response_type=token");
                
            }
            if ((webBrowser1.Url.ToString()).Substring(0,15) == "https://vk.com/")
            {
               // webBrowser1.Navigate("https://api.instagram.com/oauth/authorize/?client_id=ca8056bdac6643e5af20294fdf587722&redirect_uri=https://vk.com/dolik_k&response_type=token");
                AccTock = webBrowser1.Url.ToString().Substring(43);
                textBox1.Text = AccTock;
            }
           
        }

       

        
       
    }
}
