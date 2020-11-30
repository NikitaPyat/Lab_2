using Lab1.Models;
using Lab1.Models.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Lab_1
{
    public class Lab_1_main
    {
        static void Main(string[] args)
        {
            V5DataCollection a = new V5DataCollection("", DateTime.Now, "l_2.txt");
            Console.WriteLine(a.ToLongString("f4"));

            V5MainCollection task2 = new V5MainCollection();
            task2.AddDefaults();
            Console.WriteLine(task2.ToString());

            Vector2 p;
            p.X = 1;
            p.Y = 2;

            Console.WriteLine("MaxDistance");
            Console.WriteLine(task2.MaxDistance(p).ToString("f4"));

            Console.WriteLine("MaxDistanceItem");
            foreach (DataItem s1 in task2.MaxDistanceItems(p)){
                Console.WriteLine(s1.ToString("f4"));
            }

            Console.WriteLine("DataItems");
            foreach (DataItem s2 in task2.DataItems)
            {
                Console.WriteLine(s2.ToString());
            }
        }
    }
}

