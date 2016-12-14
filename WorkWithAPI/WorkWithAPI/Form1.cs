using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;


namespace WorkWithAPI
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public static String ShortCode = "BN86VA8hlQ7";
        private void Form1_Load(object sender, EventArgs e)
        {
            //https://api.instagram.com/v1/users/self/media/recent/?access_token=ACCESS-TOKEN
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string st=Work.MethodAPI(ShortCode);
            listBox1.Items.Add(st);
            Clipboard.SetText(st);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String InfoRecent = Work.GetRecent();
            textBox1.Text = InfoRecent;
            //string InfoRecent=textBox1.Text;
            string[] lines = new string[40000];
            int ind = 0;
          while (InfoRecent.Contains("\"attribution\":"))
         {
               
                InfoRecent=InfoRecent.Remove(0,InfoRecent.IndexOf("filter")+7);
                textBox2.Text = textBox2.Text + "Filter" + InfoRecent.Substring(0, InfoRecent.IndexOf(","));
                InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("link") + 5);
                textBox2.Text = textBox2.Text + " Link" + InfoRecent.Substring(0, InfoRecent.IndexOf(","));
                InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("url") + 4);
                textBox2.Text = textBox2.Text + " Low_resolution_url" + InfoRecent.Substring(0, InfoRecent.IndexOf("?"))+"\" ";
                InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("url") + 4);
                textBox2.Text = textBox2.Text + "Thumbnail_url" + InfoRecent.Substring(0, InfoRecent.IndexOf("?")) + "\" ";
                InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("url") + 4);
                textBox2.Text = textBox2.Text + "Standart_resolution_url" + InfoRecent.Substring(0, InfoRecent.IndexOf("?")) + "\" " + ((char)13) + ((char)10);
                
            /* lines[ind] = lines[ind] + "Filter" + InfoRecent.Substring(0, InfoRecent.IndexOf(","));
             InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("link") + 5);
             lines[ind] = lines[ind] + " Link" + InfoRecent.Substring(0, InfoRecent.IndexOf(","));
             InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("url") + 4);
             lines[ind] = lines[ind] + " Low_resolution_url" + InfoRecent.Substring(0, InfoRecent.IndexOf("?")) + "\" ";
             InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("url") + 4);
             lines[ind] = lines[ind] + "Thumbnail_url" + InfoRecent.Substring(0, InfoRecent.IndexOf("?")) + "\" ";
             InfoRecent = InfoRecent.Remove(0, InfoRecent.IndexOf("url") + 4);
             lines[ind] = lines[ind] + "Standart_resolution_url" + InfoRecent.Substring(0, InfoRecent.IndexOf("?")) + "\" " + (char)13;
             ++ind;   */
          }
          lines[0]=textBox2.Text;
          System.IO.File.WriteAllLines(@"Testtext.txt", lines);
        }

      
       
    }
}
