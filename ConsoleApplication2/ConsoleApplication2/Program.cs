using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApplication2
{
    class Program
    {
        private static int silnia(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }



        static void Main(string[] args)
        {



            Console.WriteLine("Wybierz rodzaj testów:");
            Console.WriteLine("1.Test wyszukiwarki");
            Console.WriteLine("2.Test działań matematycznych");
            Console.WriteLine("Wybierz 1 lub 2 i naciśnij Enter");


            string choose = Console.ReadLine();

            

            Random rnd = new Random();

            IWebDriver driver = new ChromeDriver
               ("C:\\Program Files (x86)\\Google\\Chrome\\Application");


            driver.Navigate().GoToUrl("http:/www.google.pl/");
            driver.Manage().Window.Maximize();

            // IWebElement button = driver.FindElement(By.Id("menu-button"));
            // button.Click();

            if (choose == "1")
            {

                StreamWriter sw1 = File.CreateText("E:\\googletest.txt");
                //dodaktowe hasła
                string[] wyszukiwania = { "Warszawa","Poznan", ".NET", "testy automatyczne", "quality assurance", "Programa", "OLX" };


                try
                {

                    foreach (string rek in wyszukiwania)
                    {
                        IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                        classInput.Clear();



                        classInput.SendKeys(rek);
                        classInput.SendKeys(Keys.Enter);

                        System.Threading.Thread.Sleep(3000);

                        IWebElement result = driver.FindElement(By.Id("resultStats"));

                        IWebElement result1 = driver.FindElement(By.ClassName("r"));

                        IWebElement result2 = driver.FindElement(By.ClassName("_Rm"));

                       // IWebElement test = driver.FindElement(By.ClassName("st"));

                                         

                      //  string x = test.Text;

                        string wyn_czas = result.Text;
                        string first = result1.Text;
                        string link = result2.Text;
                        string wynikgoogle="";

                        if (first.Contains(rek))
                        {
                            Console.WriteLine("OK!");
                            wynikgoogle = "OK!";
                        }

                        else
                        {
                            Console.WriteLine("Error");
                            wynikgoogle = "Error";
                        }

                        sw1.WriteLine("Wynik: "+ wynikgoogle + " Hasło: "+ rek+"   "+"Wynik: "+ wyn_czas +"   "+"Pierwszy wynik: "+ first+"   "+"Link: "+link);
                        Console.WriteLine(wyn_czas);

                        Console.WriteLine(first);
                        Console.WriteLine(link);
                        
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }

                sw1.Close();
            }


            if (choose == "2")
            {

                StreamWriter sw = File.CreateText("E:\\działaniamat.txt");

                //dodawanie
                int i = 10;
                int k = rnd.Next(30, 99);

                while (i <20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();
                    
                    classInput.SendKeys("2,3 +" + i +"*"+ k);
                    double wynik = (2.3) + i * k;
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);
                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: "+"2,3 +" + i + "*" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "2,3 +" + i + "*" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }
                

                //dzielenie
                i = 10;
                k = rnd.Next(30, 99);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();

                    classInput.SendKeys(("2,3 /") + i + "*" + k);
                    double wynik = (2.3) / i * k;
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);
                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + ("2,3 /") + i + "*" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + ("2,3 /") + i + "*" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }



                //odejmowanie

                i = 10;
                k = rnd.Next(30, 99);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();

                    classInput.SendKeys("2,3 -" + i + "*" + k);
                    double wynik = (2.3) - i * k;
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);
                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "2,3 -" + i + "*" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "2,3 -" + i + "*" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }


                //mnożenie

                i = 10;
                k = rnd.Next(30, 99);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();

                    classInput.SendKeys("2,3 *" + i + "/" + k);
                    double wynik = (2.3) * i / k;
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);
                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "2,3 *" + i + "/" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "2,3 *" + i + "/" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }

                //silnia


                i = 1;
                k = rnd.Next(30, 99);

                while (i < 10)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();

                    classInput.SendKeys("2,3 +" + i + "!");
                    int wyn_sil = silnia(i);
                    double wynik = (2.3) + wyn_sil;
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);

                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "2,3 +" + i + "!");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "2,3 +" + i + "!");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }

                //log

                i = 10;
                k = rnd.Next(10, 80);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();
                    int z = i + k;
                    classInput.SendKeys("log " + z);

                    double wynik = Math.Log10(i + k);
                    wynik = Math.Round(wynik, 4);
               
                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);

                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "log " + z);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "log " + z);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }

                //pierw

                i = 10;
                k = rnd.Next(10, 80);

                while (i < 20)
                {
                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();

                    int z = i + k;
                    classInput.SendKeys("sqrt" + "(" + z + ")");

                    double wynik = Math.Sqrt(i + k);
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);
                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "sqrt" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "sqrt" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }
                //potega

                i = 10;
                k = rnd.Next(-5, 2);

                while (i < 20)
                {
                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();

                    classInput.SendKeys(i + "^" + k);

                    double wynik = Math.Pow(i, k);
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);

                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + i + "^" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + i + "^" + k);
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 1;
                }

                //tan
                i = 10;
                k = rnd.Next(10, 50);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();
                    int z = i + k;
                    classInput.SendKeys("tan" + "(" + z + ")");

                    double wynik = Math.Tan(i + k);
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);

                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "tan" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "tan" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }

                //sin

                i = 10;
                k = rnd.Next(10, 50);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();
                    int z = i + k;
                    classInput.SendKeys("sin" + "(" + z + ")");

                    double wynik = Math.Sin(i + k);
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);

                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "sin" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "sin" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }
         
                //cos

                i = 10;
                k = rnd.Next(10, 80);

                while (i < 20)
                {

                    IWebElement classInput = driver.FindElement(By.Id("lst-ib"));
                    classInput.Clear();
                    int z = i + k;
                    classInput.SendKeys("cos" + "(" + z + ")");

                    double wynik = Math.Cos(i + k);
                    wynik = Math.Round(wynik, 4);

                    classInput.SendKeys(Keys.Enter);
                    System.Threading.Thread.Sleep(3500);

                    IWebElement spanclass = driver.FindElement(By.Id("cwos"));

                    double wartosc = Double.Parse(spanclass.Text, CultureInfo.InvariantCulture);
                    wartosc = Math.Round(wartosc, 4);

                    if (wartosc == wynik)
                    {
                        sw.WriteLine("Działanie: " + "cos" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("OK");
                        sw.WriteLine("OK");
                        sw.WriteLine("");
                    }
                    else
                    {
                        sw.WriteLine("Działanie: " + "cos" + "(" + z + ")");
                        sw.WriteLine("Wynik google: " + wartosc);
                        System.Console.WriteLine("Error");
                        sw.WriteLine("Error");
                        sw.WriteLine("");
                    }

                    i++;
                    k = k + 2;
                }

                sw.Close();
            }

           
        }
    }
}
