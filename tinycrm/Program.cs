using System;

namespace tinycrm
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = "C://Users//Dimtris//Desktop//project future//tinycrminput.txt";

            Console.WriteLine(InputProductList.AddPricestoProducts());
            Console.WriteLine(InputProductList.ReadInput(path));
         
        }
    }
}
