using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KnowITAssignment
{
    public class Program
    {
        public CartoonData CartoonOverview = new CartoonData();
        public EachCartoonData EachCartoonOverview = new EachCartoonData();
        public CartoonSalesData SalesList = new CartoonSalesData();
        static public void Main()
        {
            Program p = new Program();
            Console.WriteLine("\n\n\n\nHello there! Welcome to Cartoon-Foo Storage software!");
            p.JustSomeData();
            //p.ConsoleMeny(); <--- if you dont want data, activate this and gray out the one above.
        }
        public void JustSomeData()
        {            

            for (int i = 0; i < 5; i++)
            {
                Cartoon temp = new Cartoon
                {
                    CartoonID = i,
                    Theme = "Horror" + i,
                    Tittle = "Popular Comic" + i,
                    StartPrice = 12 + i,
                    ReleaseDate = 0303,
                    LocalStock = 2
                };
                CartoonOverview.CartoonStorage.Add(temp);

                EachCartoon temp2 = new EachCartoon
                {
                    CartoonID = i,
                    Grading = 1,
                    ObtainedDate = 0315,
                    SalesPrice = 14 + i
                };
                EachCartoonOverview.EachCartoonStorage.Add(temp2);
            }          

            ConsoleMeny();
        }
        public void ConsoleMeny()
        {
            Console.WriteLine("\n\n\nWhat do you want to do?" +
                "\nRegister new Comic       -           1" +
                "\nRegister new stock       -           2" +
                "\nUpdate an existing comic -           3" +
                "\nSell a comic             -           4" +
                "\nShow comics for eval     -           5" +
                "\nShow comics for sale     -           6\n");

            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterNewCartoon();
                    break;
                case 2:
                    LocalStock();
                    break;
                case 3:
                    UpDateComic();
                    break;
                case 4:
                    SellComic();
                    break;
                case 5:
                    ShowEvaluateComics();
                    break;
                case 6:
                    ComicsForSale();
                    break;
                default:
                    Console.WriteLine("Your input was not Valid. Try again!");
                    ConsoleMeny();
                    break;
            }
        }

        public void RegisterNewCartoon()
        {
            //variabler: utgivelseID, Theme, tittle, StartPrice, ReleaseDate(mmdd)
            Console.WriteLine("What theme is the new cartoon?");
            String Theme = Console.ReadLine();
            Console.WriteLine("What is the tittle?");
            String Tittle = Console.ReadLine();
            Console.WriteLine("What is the ID?");
            int CartoonID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What start price?");
            int StartPrice = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What is the release date (mmdd)?");
            int ReleaseDate = Int32.Parse(Console.ReadLine());

            Cartoon temp = new Cartoon();
            temp.CartoonID = CartoonID;
            temp.Theme = Theme;
            temp.Tittle = Tittle;
            temp.StartPrice = StartPrice;
            temp.ReleaseDate = ReleaseDate;
            temp.LocalStock = 0;
            CartoonOverview.CartoonStorage.Add(temp);

            ConsoleMeny();
        }

        public void LocalStock()
        {
            Console.WriteLine("What comic arrived, write ID?");
            int CartoonID = Int32.Parse(Console.ReadLine());
            Cartoon temp = CartoonOverview.CartoonStorage.Find(Cartoon => Cartoon.CartoonID == CartoonID);
            int grade = 0;
            Console.WriteLine("What grade is the comic? (number gradiant or 'Til Vurdering')");
            String temp2 = Console.ReadLine();

            if (temp2 == "Til Vurdering")
            {
                grade = 0;
            }
            else
            {               
                grade = Int32.Parse(temp2);
            }

            Console.WriteLine("When did it arrive?(mmdd)");
            int obtainedDate = Int32.Parse(Console.ReadLine());
            Console.WriteLine("What will the sales price be?");
            int setPrice = Int32.Parse(Console.ReadLine());

            EachCartoon ac = new EachCartoon();
            ac.ObtainedDate = obtainedDate;
            ac.CartoonID = CartoonID;
            ac.SalesPrice = setPrice;
            ac.Grading = grade;
            EachCartoonOverview.EachCartoonStorage.Add(ac);

            ConsoleMeny();
        }

        public void UpDateComic()
        {
            int cartoonID = 0;
            int grading = 0;
            int price = 0;

            Console.WriteLine("What comic (ID) do you want to update?");
            cartoonID = Int32.Parse(Console.ReadLine());
            EachCartoon temp = EachCartoonOverview.EachCartoonStorage.Find(EachCartoon => EachCartoon.CartoonID == cartoonID);
            if (temp != null)
            {
                Console.WriteLine("What is the new Grading?");
                grading = Int32.Parse(Console.ReadLine());
                Console.WriteLine("What is the new sales Price?");
                price = Int32.Parse(Console.ReadLine());

                temp.CartoonID = cartoonID;
                temp.SalesPrice = price;
                temp.Grading = grading;

                EachCartoonOverview.EachCartoonStorage[EachCartoonOverview.EachCartoonStorage.IndexOf(temp)] = temp;
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }

            ConsoleMeny();
        }

        public void SellComic()
        {
            Console.WriteLine("What Cartoon was sold? (ID)");
            int cartoonID = Int32.Parse(Console.ReadLine());
            EachCartoon temp = EachCartoonOverview.EachCartoonStorage.Find(EachCartoon => EachCartoon.CartoonID == cartoonID);
            CartoonSales temp2 = new CartoonSales();
            Cartoon temp3 = CartoonOverview.CartoonStorage.Find(Cartoon => Cartoon.CartoonID == cartoonID);

            if (temp != null)
            {
                temp2.CartoonID = cartoonID;
                temp2.SalesPrice = temp.SalesPrice;
                temp2.SalesDate = DateTime.Now;

                SalesList.CartoonSalesList.Add(temp2);
                CartoonOverview.CartoonStorage[CartoonOverview.CartoonStorage.IndexOf(temp3)].LocalStock -= 1;
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }

            ConsoleMeny();
        }
        public void ShowEvaluateComics()
        {
            foreach(EachCartoon ec in EachCartoonOverview.EachCartoonStorage)
            {
                if(ec.Grading == 0)
                {
                    Console.WriteLine("\nCartoonID: " + ec.CartoonID + " needs to be evaluated");
                }
            }
            Console.WriteLine("\n");

            ConsoleMeny();
        }
        public void ComicsForSale()
        {
            //EachCartoonOverview.EachCartoonStorage.Sort();
            EachCartoon temp = new EachCartoon();

            foreach (Cartoon car in CartoonOverview.CartoonStorage)
            {
                temp = EachCartoonOverview.EachCartoonStorage.Find(EachCartoon => EachCartoon.CartoonID == car.CartoonID);
                if ( car.LocalStock > 0)
                {                    
                    Console.WriteLine("\nTittle: " + car.Tittle + " Theme: " + car.Theme +" Price: " + temp.SalesPrice + " Release date: " + car.ReleaseDate + " ID: " + car.CartoonID);
                }
            }
            Console.WriteLine("\n");

            ConsoleMeny();
        }
    }

}
