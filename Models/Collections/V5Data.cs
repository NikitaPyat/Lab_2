using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    public abstract class V5Data
    {
        public string info { get; set; }
        public DateTime date { get; set; }

        public abstract List<DataItem> Ditems { get; set; }

        public V5Data(string i, DateTime d)
        {
            info = i;
            date = d;
            Ditems = new List<DataItem>();
        }

        public abstract Vector2[] NearEqual(float eps);

        public override string ToString()

        {
            return "V5Data:\nInfo: " + info.ToString() + "\nDate: " + date.ToString();
        }
        public abstract string ToLongString();

        public virtual string ToString(string format)
        {
            return "Info: " + info + "\n" + "Data: " + date.ToString() + "\n";
        }
    }
}