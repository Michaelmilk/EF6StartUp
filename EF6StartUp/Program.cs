using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFOperation;
using EFOperation.DbModels;

namespace EF6StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataContxt = new DataContext();
            dataContxt.DbData.Add(new DbData("a", "aaaaaaa"));
            dataContxt.SaveChanges();
            Console.WriteLine("db operation done!");
        }
    }
}
