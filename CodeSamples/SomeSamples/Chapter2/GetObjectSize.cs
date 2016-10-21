using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace SomeSamples.Chapter2
{
    public static class GetObjectSize
    {
        public static void Do()
        {
            TestClass1 testClass1 = new TestClass1();
            testClass1.C = new double[100];
            TestStruct1 testStruct1 = new TestStruct1();
            testStruct1.C = new double[100];

            //List<int> classSizes = new List<int>();
            //List<int> structSizes = new List<int>();

            //for (int i = 0; i < 10000; i++)
            //{
            //    classSizes.Add(Get1(testClass1));
            //    structSizes.Add(Get1(testStruct1));
            //}

            //Console.WriteLine(classSizes.Min());
            //Console.WriteLine(classSizes.Max());
            //Console.WriteLine(structSizes.Min());
            //Console.WriteLine(structSizes.Max());
            Console.WriteLine(Get2<TestClass1>());
            Console.WriteLine(Get2<TestStruct1>());
        }

        public static int Get1(object o)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, o);
            var array = ms.ToArray();
            return array.Length;
        }

        public static int Get2<T>() where T : new()
        {
            return Marshal.SizeOf(new T());
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public class TestClass1
    {
        public int A;
        //public List<string> B;
        public double[] C;
    }

    [Serializable]
    public struct TestStruct1
    {
        public int A;
        //public List<string> B;
        public double[] C;
    }
}