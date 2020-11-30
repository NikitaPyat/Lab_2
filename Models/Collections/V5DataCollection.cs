using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    public class V5DataCollection : V5Data, IEnumerable<DataItem>
    {
        public override List<DataItem> Ditems { get; set; }
        public Dictionary<System.Numerics.Vector2, System.Numerics.Vector2> dic { get; set; }

        public V5DataCollection(string s, DateTime t) : base(s, t)
        {
            dic = new Dictionary<Vector2, Vector2>();
        }

        public V5DataCollection(string info, DateTime date, string filename) : base(info, date)
        {
            try
            {
                dic = new Dictionary<Vector2, Vector2>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string str1, str2;
                    Vector2 key, value;
                    float x, y, xVal, yVal;
                    while ((str1 = sr.ReadLine()) != null)
                    {
                        str2 = str1;

                        string[] pool = str2.Split(new char[] { ' ' });

                        x = float.Parse(pool[0]);
                        y = float.Parse(pool[1]);
                        xVal = float.Parse(pool[2]);
                        yVal = float.Parse(pool[3]);

                        key = new Vector2(x, y);
                        value = new Vector2(xVal, yVal);
                        Console.WriteLine(value);
                        dic.Add(key, value);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Cannot read file: " + exc.Message);
            }
        }

        public void InitRandom(int nItems, float xmax, float ymax, float minValue, float maxValue)
        {
            Random r = new Random();
            float x, y, data_x, data_y;
            Vector2 point, value;
            for (int i = 0; i < nItems; i++)
            {

                x = (float)r.NextDouble();
                y = (float)r.NextDouble();
                data_x = (float)r.NextDouble();
                data_y = (float)r.NextDouble();
                data_x = minValue + (maxValue - minValue) * data_x;
                data_y = minValue + (maxValue - minValue) * data_y;
                x = xmax * x;
                y = ymax * y;
                point = new Vector2(x, y);
                value = new Vector2(data_x, data_y);
                dic.Add(point, value);
            }
        }

        public override Vector2[] NearEqual(float eps)
        {
            List<Vector2> vec = new List<Vector2>();
            foreach (KeyValuePair<Vector2, Vector2> keys in dic)
            {
                Vector2 zn = keys.Value;
                if (Math.Abs(zn.X - zn.Y) <= eps)
                    vec.Add(zn);
            }
            Vector2[] res = vec.ToArray();
            return res;
        }

        public override string ToString()

        {
            string str = "V5DataCollection(s): " + info + " " + date.ToString() + "\nNumber of elements: " + dic.Count + "\n";
            return str;
        }

        public override string ToLongString()
        {
            string str = "V5DataCollection\n";
            str += info + " " + date.ToString() + "\nNumber of elements: " + dic.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> key in dic)
            {
                str += key.Key + " " + key.Value + "\n";
            }
            return str;
        }

        public string ToLongString(string format)
        {
            string str = "V5DataCollection(ls):" + info + " " + date.ToString(format) + "\nNumber of elements: " + dic.Count + "\n";
            foreach (KeyValuePair<Vector2, Vector2> pair in dic)
            {
                str += pair.Key + " " + pair.Value.ToString(format) + "\n";
            }
            return str;
        }

        public IEnumerator<DataItem> GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 val, coord;
            DataItem addition;

            foreach (KeyValuePair<Vector2, Vector2> pair in dic)
            {
                val = pair.Value;
                coord = pair.Key;
                addition = new DataItem(coord, val);
                list.Add(addition);
            }
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<DataItem> list = new List<DataItem>();
            Vector2 value, coordinate;
            DataItem tmp;

            foreach (KeyValuePair<Vector2, Vector2> pair in dic)
            {
                coordinate = pair.Key;
                value = pair.Value;
                tmp = new DataItem(coordinate, value);
                list.Add(tmp);
            }
            return list.GetEnumerator();
        }

    }
}
