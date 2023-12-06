

using AFZV31_HFT_2023241.Client;
using System.Collections.Generic;
using System;
using AFZV31_HFT_2023241.Models;
using ConsoleTools;
using System.Linq;
using System.Numerics;

namespace AFZV31_HFT_2023241
{

    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Annual")
            {
                Console.Write("Enter Annual Code: ");
                string code = Console.ReadLine();

                Console.Write("Enter Annual Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter how many pieces want to plant for 1m2: ");
                int pcsm2 = int.Parse(Console.ReadLine());

                rest.Post(new Annual() { AnnualName = name, AnnualCode = code, Pcsm2 = pcsm2 }, "annual");
            }
            else if (entity == "Area")
            {
                Console.Write("Enter Area Size: ");
                int size = int.Parse(Console.ReadLine());
                rest.Post(new Area() { AreaSize = size }, "area");
            }
            else if (entity == "Order")
            {
                Console.Write("Enter Annual Shortname: ");
                string annualCode = Console.ReadLine();

                Console.Write("Enter Company: ");
                string company = Console.ReadLine();

                Console.Write("Enter Package size: ");
                string packaging = Console.ReadLine();

                Console.Write("Enter Order price: ");
                int price = int.Parse(Console.ReadLine());

                rest.Post(new Order() { AnnualCode = annualCode, OrderCompany = company, OrderPackaging = packaging, Price = price }, "order");
            }
        }
        static void List(string entity)
        {
            if (entity == "Annual")
            {
                List<Annual> annuals = rest.Get<Annual>("annual");
                foreach (var item in annuals)
                {
                    Console.WriteLine(item.AnnualId + ": " + item.AnnualName);
                }
            }
            else if (entity == "Area")
            {
                List<Area> areas = rest.Get<Area>("area");
                foreach (var item in areas)
                {
                    Console.WriteLine(item.AreaId + " (id): " + item.AreaSize + "m2");
                }

            }
            else if (entity == "Order")
            {
                List<Order> orders = rest.Get<Order>("order");
                foreach (var item in orders)
                {
                    Console.WriteLine(item.OrderId + ": " + item.AnnualCode + ", " + item.OrderCompany + ", " + item.OrderPackaging);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Annual")
            {
                Console.Write("Enter Annual's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Annual one = rest.Get<Annual>(id, "annual");

                Console.Write($"New code [old: {one.AnnualCode}]: ");
                string code = Console.ReadLine();
                one.AnnualCode = code;
                Console.Write($"New pcsm2 [old: {one.Pcsm2}]: ");
                int pcsm2 = int.Parse(Console.ReadLine());
                one.Pcsm2 = pcsm2;
                rest.Put(one, "annual");



            }
            else if (entity == "Area")
            {
                Console.Write("Enter Area's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Area one = rest.Get<Area>(id, "area");
                Console.Write($"New size [old: {one.AreaSize}]: ");
                int size = int.Parse(Console.ReadLine());
                one.AreaSize = size;
                rest.Put(one, "area");
            }
            else if (entity == "Order")
            {
                Console.Write("Enter Order's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Order one = rest.Get<Order>(id, "order");
                Console.Write($"New company [old: {one.OrderCompany}]: ");
                string comp = Console.ReadLine();
                one.OrderCompany = comp;
                rest.Put(one, "order");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Annual")
            {
                Console.Write("Enter Annual's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "annual");
            }
            else if (entity == "Area")
            {
                Console.Write("Enter Area's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "area");
            }
            else if (entity == "Order")
            {
                Console.Write("Enter Order's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "order");
            }
        }


        //for the 25. commit

    static void Main(string[] args)
        {
            rest = new RestService("http://localhost:6495/", "annual");

            var areaSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Area"))
                .Add("Create", () => Create("Area"))
                .Add("Delete", () => Delete("Area"))
                .Add("Update", () => Update("Area"))
                .Add("Exit", ConsoleMenu.Close);

            var orderSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Order"))
                .Add("Create", () => Create("Order"))
                .Add("Delete", () => Delete("Order"))
                .Add("Update", () => Update("Order"))
                .Add("Exit", ConsoleMenu.Close);


            var annualSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Annual"))
                .Add("Create", () => Create("Annual"))
                .Add("Delete", () => Delete("Annual"))
                .Add("Update", () => Update("Annual"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Annuals", () => annualSubMenu.Show())
                .Add("Areas", () => areaSubMenu.Show())
                .Add("Orders", () => orderSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
