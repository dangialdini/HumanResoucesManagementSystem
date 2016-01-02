using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Support.Models
{
    public static class RandomColor
    {
        static Random rnd = new Random();
        static List<string> Colors
        {
            get
            {
                return new List<string>
                {
                    //"#00ee00","#ee0000","#0000ee","#eeee00","#00eeee","#ee00ee"
                    "RGB(0,255,255)","RGB(255,0,255)","RGB(0,255,0)","RGB(255,255,255)","RGB(0,0,255)","RGB(0,255,0)"
                    //"red","green","black","blue"
                };
            }
        }
        static public string PickRandomColorFromList()
        {
            return Colors.ElementAt(rnd.Next(Colors.Count()));
        }
        static public string PickAnyRandomColor()
        {
            return string.Format("RGB({0},{1},{2})", rnd.Next(0, 255).ToString(), rnd.Next(0, 255).ToString(), rnd.Next(0, 255).ToString());
        }
    }
}