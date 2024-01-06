using System;
using System.Globalization;
using System.Reflection;

namespace Product_management_application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = { "Milk", "Eggs", "Canned Tuna", "Cookies", "Soda", "Pasta", "Peanut Butter" };
            string opt;

            do
            {
                Console.WriteLine("\n ============ PRODUCT MANAGEMENT ============");
                Console.WriteLine("1. Bütün mehsullara bax");
                Console.WriteLine("2. Secilmis mehsula bax");
                Console.WriteLine("3.Yeni mehsul elave et");
                Console.WriteLine("4. Mehsulun adini deyis");
                Console.WriteLine("5. Secilmis mehsulu sil");
                Console.WriteLine("0. Çıx");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        ProductWindow(products);
                        break;

                    case "2":
                        Console.Write("Axtardiginiz mehsulun indexini daxil edin - ");
                        string indexStr = Console.ReadLine();
                        try
                        {
                            int index = int.Parse(indexStr);
                            Console.WriteLine(products[index]);
                        }
                        catch
                        {
                            Console.WriteLine("Xeta bas verdi!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Yeni mehsulun adini daxil edin - ");
                        string newProduct = Console.ReadLine();

                        AddProduct(ref products, newProduct);
                        break;

                    case "4":
                        NameChange(products);   
                        break;

                    case "5":
                        RemoveProduct(ref products);
                        break;

                    default:
                        if(opt != "0")
                        {
                            Console.WriteLine("Yanlis emeliyyat !");
                            break;
                        }
                        break;
                        

                }

            } while(opt != "0");
           

        }

        static void ProductWindow(string[] arr)
        {
            Console.WriteLine("\n ============ PRODUCTS ============");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i}.{arr[i]}");
            }
        }

        static void AddProduct(ref string[] arr, string product)
        {
            bool trueLength = false;
            bool productExists = false;

            do
            {
                product = FrontSpaces(product);
                product = LastSpace(product);

                if (product.Length >= 2 && product.Length <= 20)
                {
                    trueLength = true;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (product == arr[i])
                        {
                            productExists = true;
                            Console.WriteLine("Eyni mehsul daxil etmek olmaz!");
                            break;  
                        }
                    }

                    if (!productExists)
                    {
                        string[] newArr = new string[arr.Length + 1];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            newArr[i] = arr[i];
                        }
                        newArr[newArr.Length - 1] = product;
                        arr = newArr; 

                        ProductWindow(arr);  
                    }
                }
                else
                {
                    Console.Write("Mehsul adinin uzunlugu 2-20 olmalidir. Yeniden daxil edin :");
                    product = Console.ReadLine();  
                }

            } while (!trueLength); 
        }



        static void NameChange(string[] arr)
        {
            Console.WriteLine("Adini deyiseceyiniz mehsulun indexini daxil edin:");
            int index = 0;

            bool isValidIndex = false;

            while (!isValidIndex)
            {
                try
                {
                    string indexStr = Console.ReadLine();
                    index = int.Parse(indexStr);

                    if (index >= 0 && index < arr.Length)
                    {
                        isValidIndex = true;
                    }
                    else
                    {
                        Console.WriteLine("Index duzgun daxil edilmedi !");
                    }
                }
                catch 
                {
                    Console.WriteLine("Xeta bas verdi, yalnız reqem daxil etmek mumkundur:");
                }
            }

            string newName = Console.ReadLine();
            newName = FrontSpaces(newName); 
            newName = LastSpace(newName);

            while (newName.Length < 2 || newName.Length > 20)
            {
                
                Console.WriteLine("Yeni adı daxil edin:");
                newName = Console.ReadLine();
                

                if (newName.Length < 2 || newName.Length > 20)
                {
                    Console.WriteLine("Adin uzunlugu 2 ile 20 arasında olmalıdır:");
                }
            }
            
            arr[index] = newName;
            ProductWindow(arr);
        }


        static void RemoveProduct(ref string[] arr)
        {
            bool validIndex = true;  

            Console.WriteLine("Silmek istediyiniz mehsulun indexini daxil edin:");

            try
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0 || index >= arr.Length)
                {
                    Console.WriteLine("Daxil etdiyiniz index dogru deyil.");
                    validIndex = false;  
                }
                else
                {
                    string[] newArr = new string[arr.Length - 1];
                    int j = 0;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i != index)
                        {
                            newArr[j] = arr[i];
                            j++;
                        }
                    }

                    arr = newArr;   
                    ProductWindow(arr);  
                }
            }
            catch 
            {
                Console.WriteLine("Xeta bas verdi. Index yanliz reqem olabiler.");
                validIndex = false;  
            }

            
        }
   

        static string FrontSpaces(string str)
        {
            string newStr = "";
            int startIndex = IlkIndex(str);

            if (startIndex == -1) return str;

            for (int i = startIndex; i < str.Length; i++)
            {
                newStr += str[i];
            }

            return newStr;
        }

        static string LastSpace(string str)
        {
            string newStr = "";
            int endIndex = SonIndex(str);

            if (endIndex == -1) return str;

            for (int i = 0; i <= endIndex; i++)
            {
                newStr += str[i];
            }

            return newStr;
        }

        #region Son ve ilk index ucun mehtodlar
        static int SonIndex(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (str[i] != ' ') return i;
            }

            return -1;
        }
        static int IlkIndex(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ') return i;
            }

            return -1;
        }
        #endregion
    }
}
