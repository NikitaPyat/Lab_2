using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Lab1.Models
{
    public struct DataItem : IComparable<DataItem>
    {
        public Vector2 coord { get; set; }
        public Vector2 val { get; set; }

        public DataItem(Vector2 c, Vector2 v)
        {
            coord = c;
            val = v;
        }

        public override string ToString()
        {
            return coord.ToString() + " " + val.ToString();
        }

        public string ToString(string format)
        {
            return coord.ToString(format) + " " + val.ToString(format);
        }

        public int CompareTo([AllowNull] DataItem other)
        {
            if (coord.Length() < other.coord.Length())
                return -1;
            if (coord.Length() == other.coord.Length())
                return 0;
            if (coord.Length() > other.coord.Length())
                return 1;
            else
                return -1;
        }
    }
}
