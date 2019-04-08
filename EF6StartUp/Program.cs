using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using EFOperation;
using EFOperation.DbModels;

namespace EF6StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => ThreadInsert("vm1"));
            t1.Start();

            Thread t2 = new Thread(() => ThreadInsert("vm2"));
            t2.Start();
        }

        public static void test()
        {
            var dataContxt = new DataContext();
            //dataContxt.DbData.Add(new DbData("a", "aaaaaaa"));
            //dataContxt.DbData.Add(new DbData("b", "bbbbbbb"));
            //dataContxt.DbData.Add(new DbData("c", "ccccccc"));
            //dataContxt.DbData.Add(new DbData("d", "ddddddd"));
            //dataContxt.DbData.Add(new DbData("e", "eeeeeee"));
            //dataContxt.DbData.Add(new DbData("f", "fffffff"));
            //dataContxt.SaveChanges();

            var ops = dataContxt.DbData.Where(t => t.Id < 4).ToList();
            ops.ForEach(t => t.Desc = $"4{t.Desc}");
            dataContxt.SaveChanges();

            ops.ForEach(t => t.Name = $"31{t.Name}");
            dataContxt.SaveChanges();

            Console.WriteLine("db operation done!");
        }

        public static void ThreadInsert(string tag)
        {
            using (var context = new DataContext())
            {
                //using (var dbContextTransaction = context.Database.BeginTransaction())
                //{
                //    try
                //    {
                //        var cmdStr = @"create trigger trig_insteadOf
                //                        on student 
                //                        instead of insert
                //                        as 
                //                        begin
                //                            declare @stuAge int;
                //                            select @stuAge=(select stu_age from inserted)
                //                        if(@stuAge >120)
                //                            select '插入年龄错误' as '失败原因'
                //                        end";
                //        context.Database.ExecuteSqlCommand(cmdStr);

                //        context.SaveChanges();

                //        dbContextTransaction.Commit();
                //    }
                //    catch (Exception)
                //    {
                //        dbContextTransaction.Rollback();
                //    }
                //}

                for (int i = 1; i < 10; i++)
                {
                    try
                    {
                        context.DbData.Add(new DbData(i.ToString(), i.ToString()));
                        context.SaveChanges();
                        Console.WriteLine("instance: {0},  item: {1}", tag, i);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}
