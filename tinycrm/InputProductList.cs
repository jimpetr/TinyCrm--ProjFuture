using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace tinycrm
{
    public class InputProductList
    {
        public static decimal AddPricestoProducts()
        {
            var rnd = new Random();
            return (decimal)rnd.NextDouble() * 10M;
        }

        public static int ReadInput(string path)
        {
            var reader = new StreamReader(path);
            var listA = new List<String>();
            var listB = new List<String>();
            var listC = new List<String>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listA.Add(values[0]);
                listB.Add(values[1]);
                listC.Add(values[2]);
            }

            listA.RemoveAt(0);
            listB.RemoveAt(0);
            listC.RemoveAt(0);

            var dict = new Dictionary<string, decimal>();
            foreach (var i in listA.Distinct())
            {
                dict.Add(i, AddPricestoProducts());
            }
            //Console.WriteLine(dict.Count);
            //Console.WriteLine($"listA has un {listA.Distinct().ToList().Count()}");
            //Console.WriteLine($"listB has un {listB.Distinct().ToList().Count()}");
            //Console.WriteLine($"listC has un {listC.Distinct().ToList().Count()}");
            //Console.WriteLine($"total has un {listA.Count()}");

            //save duplicates
            var duplicatedlist = Duplicates(listA);
            //print if there are duplicates duplicates
            DuplicatesExist(duplicatedlist);
            //print  duplicates 
            foreach (string str in duplicatedlist)
            {
                int counter = 0;
                var positions = check(str, listA);
                foreach (int i in positions)
                {

                    Console.WriteLine($"Product id, {listA[i]}-- name, {listB[i]}-- description, {listC[i]}");
                    if (counter > 0)
                    {
                        listA.RemoveAt(i);
                        listB.RemoveAt(i);
                        listC.RemoveAt(i);
                    }
                    counter++;
                }
            }

            var ListOfProducts = new List<Product>();

            for (int i = 0; i < listC.Count; i++)
            {
                ListOfProducts.Add(new Product(listA[i], listB[i], listC[i], AddPricestoProducts()));
            }
            return listC.Count;
        }

        public static List<string> Duplicates(List<string> list)
        {
            var myList = new List<string>();
            var duplicates = new List<string>();

            foreach (var s in list)
            {
                if (!myList.Contains(s))
                    myList.Add(s);
                else
                    duplicates.Add(s);
            }
            Console.WriteLine(duplicates[0]);
            //Console.WriteLine(dict.Count);
            return duplicates.Distinct().ToList();
        }

        public static bool DuplicatesExist(List<string> list)
        {
            if (list.Count() == 0)
            {
                Console.WriteLine("There are no duplicates");
            }
            else
            {
                Console.WriteLine($"There are {list.Count()} duplicates");
            }
            return list.Count() == 0;
        }


        public static List<int> check(string elem, List<string> list)
        {

            var elem_pos = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == elem)
                {
                    elem_pos.Add(i);
                }
            }
            return elem_pos;
        }
    }
}
