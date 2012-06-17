using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Xml.Linq;
using System.Windows.Media.Imaging;

namespace TileQuiz
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            lastAPI coverprovider = new lastAPI();
            coverprovider.lookup("metallica");
            coverprovider.searchDoneEvent += new lastAPI.searchDone(LastFM_searchDone);
        }

        private void LastFM_searchDone(XElement Results)
        {
            XMLtoImageList parser = new XMLtoImageList(Results, "extralarge");
            List<string> imageList = parser.images;

            ov.Source = new BitmapImage(new Uri(imageList[0],UriKind.Absolute));
            oh.Source = new BitmapImage(new Uri(imageList[1], UriKind.Absolute));
            nv.Source = new BitmapImage(new Uri(imageList[2], UriKind.Absolute));
            nh.Source = new BitmapImage(new Uri(imageList[3], UriKind.Absolute));



        }
    }
}