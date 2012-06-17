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
using System.Collections.Generic;
using System.Linq;

namespace TileQuiz
{
    public class XMLtoImageList
    {
        public List<string> images;
        public string size { get; set; }
        public XMLtoImageList(XElement unparsed,string size)
        {
           this.size = size;
           images = new List<string>();
           var items = from albums in unparsed.Descendants("album").Elements("image")
                                where albums.Attribute("size").Value==size
                                select new album { thumbnail = (string) albums.Value };
            
            foreach (album record in items){
                images.Add(record.thumbnail);
            }
        }
        


    }

    public class album
    {
        public string thumbnail;
    }
}
