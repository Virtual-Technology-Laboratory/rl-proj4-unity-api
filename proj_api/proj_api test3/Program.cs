/*
 * Author: Roger Lew (rogerlew@vandals.uidaho.edu || rogerlew@gmail.com)
 * Date: 2/2/2015
 * License: Public Domain
 * 
 * Tests and demonstrates the functionality of the projApi wrapper for Proj.4 
 * 
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjApi;

namespace proj_api_test3
{
    class Program
    {
        static void printArray(double[] x)
        {
            Console.Write("[");
            foreach (double _x in x)
                Console.Write(string.Format("{0}, ", _x));

            Console.Write("]\n");
        }

        static bool assertAlmostEqual(double x, double y, int decimals = 7)
        {
            return Math.Round(x, decimals) == Math.Round(y, decimals);
        }

        static void test1()
        {

            Console.WriteLine("\nIn test1()");
            double[] x = { -16 };
            double[] y = { 20.25 };
            double[] z = { 0 };

            Projection src = new Projection(@"+proj=latlong +ellps=clrk66");
            Projection dst = new Projection(@"+proj=merc +ellps=clrk66 +lat_ts=33");

            Projection.Transform(src, dst, x, y, null);

            printArray(x);
            printArray(y);

            if (!assertAlmostEqual(x[0], -1495284.21147348) ||
                !assertAlmostEqual(y[0], 1920596.78991744))
                Console.WriteLine("test failed");

        }

        static void test2()
        {
            Console.WriteLine("\nIn test2()");
            double[] x = { 565889.360 };
            double[] y = { 4844940.560 };
            double[] z = { 0 };

            Projection src = new Projection(@"+init=epsg:26911");
            Projection dst = new Projection(@"+proj=latlong +datum=WGS84");

            Projection.Transform(src, dst, x, y, null);

            printArray(x);
            printArray(y);
    
            if (!assertAlmostEqual(x[0], -116.181539055055) ||
                !assertAlmostEqual(y[0], 43.7545792737024))
                Console.WriteLine("test failed");

        }

        static void test3()
        {
            Console.WriteLine("\nIn test3()");
            double[] x = { -116.181539055055 };
            double[] y = { 43.7545792737024 };
            double[] z = { 0 };

            Projection src = new Projection(@"+proj=latlong +datum=WGS84");
            Projection dst = new Projection(@"+init=epsg:26911");

            Projection.Transform(src, dst, x, y, null);

            printArray(x);
            printArray(y);

            if (!assertAlmostEqual(x[0], 565889.360) ||
                !assertAlmostEqual(y[0], 4844940.560))
                Console.WriteLine("test failed");

        }

        static void Main(string[] args)
        {
            test1();
            test2();
            test3();

            Console.WriteLine("Press Any Key to End...");
            Console.ReadLine();
        }
    }
}
