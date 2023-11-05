using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AFZV31_HFT_2023241
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IRepository<Annual> repo = new AnnualRepostitory(new AnnualDbContext());
            var items = repo.ReadAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
