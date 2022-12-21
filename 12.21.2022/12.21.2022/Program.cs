using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace _12._21._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num;
            Notebook[] newArray = new Notebook[0];
            Notebook[] notebooks = new Notebook[0];
            Notebook[] filteredArray = new Notebook[0];
            do
            {
                Console.WriteLine("1. Notebooklar uzerinde axtaris et");
                Console.WriteLine("");
                Console.WriteLine("2. Yeni Notebook yarat");
                Console.WriteLine("");
                Console.WriteLine("0. Menudan cix");
                Console.WriteLine("");
                num = Console.ReadLine();

                if (num == "2")
                {
                    notebooks = createNotebook(ref notebooks);
                }
                else if (num == "1")
                {
                    filteredArray = findNotebook(notebooks);

                    for (int i = 0; i < filteredArray.Length; i++)
                    {
                        getInfo(filteredArray[i]);
                    }
                }
            } while (num != "0");



            static Notebook[] createNotebook(ref Notebook[] newArray)
            {
                bool priceExcp;
                bool ramExcp;
                string ad;
                int qiymet = 0;
                int ram = 0;
                do
                {
                    Console.Write("Notebookun adini daxil edin: ");
                    ad = Console.ReadLine();

                } while (!stringIsOkay(ad) == false);

                do
                {
                    priceExcp = false;
                    try
                    {
                        Console.Write("Notebookun qiymetini daxil edin: ");

                        qiymet = int.Parse(Console.ReadLine());

                        if (qiymet <= 0)
                        {
                            priceExcp = true;
                            Console.WriteLine("Eded menfi ve ya sifir ola bilmez!");
                            Console.WriteLine("");

                        }
                    }
                    catch (System.FormatException)
                    {
                        priceExcp = true;
                        Console.WriteLine("Yalniz REQEM daxil oluna biler! ");
                        Console.WriteLine("");
                    }
                } while (priceExcp == true);

                do
                {
                    ramExcp = false;
                    try
                    {
                        Console.Write("Notebookun ramini daxil edin: ");
                        ram = int.Parse(Console.ReadLine());
                        if (ram > 128 || ram <= 0)
                        {
                            ramExcp = true;
                            Console.WriteLine("Eded menfi/sifir ve ya 128 den boyuk ola bilmez!");
                            Console.WriteLine("");
                        }
                    }
                    catch (System.FormatException)
                    {
                        ramExcp = true;
                        Console.WriteLine("Yalniz REQEM daxil oluna biler! ");
                        Console.WriteLine("");
                    }
                } while (ramExcp == true);

                Array.Resize(ref newArray, newArray.Length + 1);

                newArray[newArray.Length - 1] = new Notebook(ad, qiymet, ram);

                return newArray;
            }

            static Notebook[] findNotebook(Notebook[] oldArr)
            {
                string search;
                do
                {

                    Console.Write("Axtaris etmek istediyiniz notebookun adini daxil edin: ");
                    search = Console.ReadLine();

                } while (stringIsOkay(search));
                search.ToLower();

                Notebook[] newArr = new Notebook[0];
                for (int i = 0; i < oldArr.Length; i++)
                {
                    if (oldArr[i].Name.ToLower().Contains(search))
                    {
                        Array.Resize(ref newArr, newArr.Length + 1);
                        newArr[newArr.Length - 1] = oldArr[i];
                    }
                }
                return newArr;
            }

            static void getInfo(Notebook notbukObj)
            {
                Console.WriteLine($"Notbukun adi: {notbukObj.Name} - Notbukun qiymeti: {notbukObj.Price} - Notbukun rami: {notbukObj.Ram}");
            }

            static bool stringIsOkay(string str)
            {
                if (string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Yalniz herf ve reqemlerden istifade oluna biler!");
                    Console.WriteLine("");
                    return true;
                }
                else
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (char.IsLetterOrDigit(str[i]))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Yalniz herf ve reqemlerden istifade oluna biler!");
                            Console.WriteLine("");
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}

//Notebook arrayi yaradin
//Layihe ise dusdukde asagidaki menu penceresi gorunsun:
//1.Notebooklar uzerinde axtaris et (1 secilse elave 2 secilse elave, balaca ile yazsaqda olmalidi boyuk ilede


//2.Yeni notebook yarat (notbukun fieldlerini client set elir, ve arraya qoyururuq.
//Name null ve empty ola bilmez, format error Yeniden daxil et ve ya inputu duzgun daxil eetmelidi,
//price menfi ol bilmez, yalniz reqem olmalidi,
//ram da hemin ve 128den boyuk olmasin

//0.Menudan cix

//Eger exception cixsa idare olnumalidir.