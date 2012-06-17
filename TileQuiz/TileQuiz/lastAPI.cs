using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace TileQuiz
{
    public class lastAPI
    {
        //Vars
        private static readonly string APIKey = "95ef3437a89cdcae6fa34312d5ce37a1";
        public XElement SearchResult {get; set; }
        public delegate void searchDone(XElement Results);
        public event searchDone searchDoneEvent;

        public void lookup(string albumName)
        {
        WebClient lastFM = new WebClient();
        lastFM.DownloadStringCompleted += new DownloadStringCompletedEventHandler(LastFM_downloadcomplete);
        lastFM.DownloadStringAsync(new Uri("http://ws.audioscrobbler.com/2.0/?method=album.search&album="+albumName+"&api_key="+APIKey));

        }

        private void LastFM_downloadcomplete(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }
            XElement resultXML = XElement.Parse(e.Result);
            SearchResult = resultXML;
            if (searchDoneEvent != null) searchDoneEvent(SearchResult);
        }


        
    }
}
