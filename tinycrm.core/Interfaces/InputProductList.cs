using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace tinycrm.core.Interfaces
{
    public class InputProductList
    {
        /* public static decimal AddPricestoProducts()
         {
             var rnd = new Random();
             //Math.Round(rnd.Next
             return (decimal)Math.Round(rnd.NextDouble(),2) * 10M;
         }

         public static int ReadInput(string path)
         {
             var reader = new StreamReader(path);
             var ProductIdList = new List<String>();
             var NameList = new List<String>();
             var DescriptionList = new List<String>();

             while (!reader.EndOfStream)
             {
                 var line = reader.ReadLine();
                 var values = line.Split(';');

                 ProductIdList.Add(values[0]);
                 NameList.Add(values[1]);
                 DescriptionList.Add(values[2]);
             }

             ProductIdList.RemoveAt(0);
             NameList.RemoveAt(0);
             DescriptionList.RemoveAt(0);

             //var dict = new Dictionary<string, decimal>();
             //foreach (var i in ProductIdList.Distinct())
             //{
               //  dict.Add(i, AddPricestoProducts());
             //}
             //Console.WriteLine(dict.Count);
             //Console.WriteLine($"listA has un {listA.Distinct().ToList().Count()}");
             //Console.WriteLine($"listB has un {listB.Distinct().ToList().Count()}");
             //Console.WriteLine($"listC has un {listC.Distinct().ToList().Count()}");
             //Console.WriteLine($"total has un {listA.Count()}");

             //save duplicates
             //var duplicatedlist = Duplicates(ProductIdList);
             //print if there are duplicates duplicates
             //DuplicatesExist(duplicatedlist);
             //print  duplicates 
             //foreach (string str in duplicatedlist)
             //{
               //  int counter = 0;
                // var positions = check(str, ProductIdList);
                // foreach (int i in positions)
             //    {

               //      Console.WriteLine($"Product id, {ProductIdList[i]}-- name, {NameList[i]}-- description, {DescriptionList[i]}");
                 //    if (counter > 0)
                   //  {
                       //  ProductIdList.RemoveAt(i);
                     //    NameList.RemoveAt(i);
                     //    DescriptionList.RemoveAt(i);
                   //  }
                    // counter++;
                 //}
            // }

             //var ListOfProducts = new List<Product>();

             //for (int i = 0; i < DescriptionList.Count; i++)
             //{
              //   ListOfProducts.Add(new Product(ProductIdList[i], NameList[i], DescriptionList[i], AddPricestoProducts()));
             //}
            // return DescriptionList.Count;
        // }

         //public static List<string> Duplicates(List<string> list)
         //{
           //  var myList = new List<string>();
            // var duplicates = new List<string>();

            // foreach (var s in list)
             //{
              //   if (!myList.Contains(s))
                //     myList.Add(s);
                // else
                //     duplicates.Add(s);
            // }
            // Console.WriteLine(duplicates[0]);
             //Console.WriteLine(dict.Count);
           //  return duplicates.Distinct().ToList();
        // }

        // public static bool DuplicatesExist(List<string> list)
         //{
           //  if (list.Count() == 0)
           //  {
             //    Console.WriteLine("There are no duplicates");
             //}
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
         }*/
    }
}
