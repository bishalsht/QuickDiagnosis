using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.IO;

namespace PivotApp1
{
    public partial class moreinfo : PhoneApplicationPage
    {
        public static int dis_no { set; get; }
        public moreinfo()
        {
            InitializeComponent();

            
            string s=string.Format("/diag_data/{0}.jpg",dis_no);
            Uri st = new Uri(s,UriKind.Relative);
            BitmapImage str = new BitmapImage(st);
            img1.Source = str;

            s=string.Format("diag_data/{0}.txt",dis_no);
            using (StreamReader rdr=new StreamReader(s)){
                title1.Header = rdr.ReadLine();
                txt1.Text = rdr.ReadToEnd();
                txt1.Height = 2000;
                stack.Height = 2000;
                grid.Height = 2000;
            }
        }
    }
}