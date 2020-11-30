using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Lab1.Models.Collections
{
    class V5MainCollection : IEnumerable
    {
        private List<V5Data> V5List;
        public V5MainCollection()
        {
            V5List = new List<V5Data>();
        }
        public IEnumerable<DataItem> DataItems
        {
            get
            {
                return from data in V5List
                       from item in data.Ditems
                       orderby item
                       select item;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return V5List.GetEnumerator();
        }
        public int Count()
        {
            return V5List.Count;
        }

        public void Add(V5Data item)
        {
            V5List.Add(item);
        }

        public bool Remove(string id, DateTime d)
        {
            bool flag = false;
            for (int i = 0; i < V5List.Count; i++)
            {
                if (String.Equals(V5List[i].info, id) == true
                        && V5List[i].date.CompareTo(d) == 0)
                {
                    V5List.RemoveAt(i);
                    i--;
                    flag = true;
                }
            }
            return flag;
        }

        public void AddDefaults()
        {
            Random rand = new Random();
            int NElem = rand.Next(2, 11), Rand1, Rand2;
            Grid2D Gr;
            V5DataCollection DataColl;
            V5DataOnGrid DataGrid;
            V5List = new List<V5Data>();
            for (int i = 0; i < NElem; i++)
            {
                Rand1 = rand.Next(0, 2);
                Gr = new Grid2D(8, 4, 3, 3);
                if (Rand1 == 0)
                {
                    DataGrid = new V5DataOnGrid("", DateTime.Now, Gr);
                    DataGrid.InitRandom(0, 9);
                    V5List.Add(DataGrid);
                }
                else
                {
                    Rand2 = rand.Next(1, 10);
                    DataColl = new V5DataCollection("", DateTime.Now);
                    DataColl.InitRandom(Rand2, 3, 18, 3, 5);
                    V5List.Add(DataColl);
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (V5Data item in V5List)
            {
                str += item.ToString();
            }
            str += "\n";
            return str;
        }

        public string ToLongString(string format)
        {
            string str = "";
            foreach (V5Data item in V5List)
            {
                str += item.ToString(format);
            }
            return str;
        }

        public float MaxDistance(Vector2 v)
        {
            var res = from data in V5List
                        from item in data.Ditems
                        select Vector2.Distance(v, item.coord);
            return res.Max();
        }

        public IEnumerable<DataItem> MaxDistanceItems (Vector2 v)
        {
            var res = from data in V5List
                        from item in data.Ditems
                        where Vector2.Distance(v, item.coord) == MaxDistance(v)
                        select item;
            return res;
        }
        
    }
}
