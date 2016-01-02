using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace Services.Service.Models.Support
{
    public class SupportStaffRosterDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public int RecurrenceId { get; set; }
        public string RecurrenceException { get; set; }
        public string RecurrenceRule { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }




        public List<Color> GetAllColors()
        {
            List<Color> allColors = new List<Color>();

            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                {
                    allColors.Add((Color)property.GetValue(null));
                }
            }

            return allColors.Skip(1).ToList();
        }

        static readonly Color[] Colors = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(propInfo => propInfo.GetValue(null, null))
            .Cast<Color>()
            .ToArray();

        private Random rand = new Random();

        public Color GetRandomColor()
        {
            return Colors[rand.Next(0, Colors.Length)];
        }

        // NESTED CLASS - Random Color Generator
        //public static class RandomColor
        //{

        //    Array.Copy(colorsArray, allColors, colorsArray.Length);

        //    static Random rnd = new Random();
        //    static List<string> Colors
        //    {
        //        get
        //        {
        //            return new List<string>
        //            {
        //                { "#00FF00", "#0000FF", "#FFFF00", "#00FFFF", "#FF00FF", "#C0C0C0", "#808080", "#800000", "#808000", "#008000", "#800080", "#008080", "#000080", "#FF4500", "#556B2F", "#6495ED", "#8B008B", "#008080", "#FF00FF", "#FFE4E1", "#FFE4B5", "#B0C4DE", "#F0FFF0" };
        //                "RGB(0,255,255)","RGB(255,0,255)","RGB(0,255,0)","RGB(255,255,255)","RGB(0,0,255)","RGB(0,255,0)"
        //            };
        //        }
        //    }

        //    static public string PickRandomColorFromList()
        //    {
        //        return Colors.ElementAt(rnd.Next(Colors.Count()));
        //    }
        //    static public string PickAnyRandomColor()
        //    {
        //        return string.Format("RGB({0},{1},{2})", rnd.Next(0, 255).ToString(), rnd.Next(0, 255).ToString(), rnd.Next(0, 255).ToString());
        //    }
        //}
    }
}
