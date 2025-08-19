namespace R_EFcore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 3
            //var res = ListGenerator.ProductsList.Any();//is contain any data?
            //Console.WriteLine(res);
            //Console.WriteLine(ListGenerator.ProductsList.Any(p => p.UnitsInStock == 0));

            //var res = ListGenerator.ProductsList.All(p => p.UnitsInStock == 0);
            //Console.WriteLine(res);

            //var seq1 = Enumerable.Range(0, 100);
            //var seq2 = Enumerable.Range(0, 100);
            //var seq3 = Enumerable.Range(50, 100);
            //Console.WriteLine(seq1.SequenceEqual(seq2));
            //Console.WriteLine(seq1.SequenceEqual(seq3));


            //string[] names = { "omar", "rana", "dalia", "ali" };
            //int[] numbers = Enumerable.Range(1, 10).ToArray();
            //char[] chars = { 'a', 'b', 'c', 'd', 'e' };

            ////var res = names.Zip(chars);
            ////var res = names.Zip(numbers, (name, num) => new { index = num, name = name });
            ////var res = names.Zip(chars, numbers);

            //foreach (var x in res) Console.WriteLine(x);


            /*--------------------------------------------Grouping operator [query is better than fluent]-----------------------------------------------*/
            #region get products grouped by category
            //var res = ListGenerator.ProductsList.GroupBy(p => p.Category);

            //var res = from p in ListGenerator.ProductsList
            //          group p by p.Category;
            #endregion
            #region Get products in stock grouped by category
            //var res = ListGenerator.ProductsList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category);

            //var res = from p in ListGenerator.ProductsList
            //          where p.UnitsInStock > 0
            //          group p by p.Category;
            #endregion
            #region Get products in stock grouped by category that contains more than 10 products
            //var res = ListGenerator.ProductsList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category).Where(p => p.Count() > 10);

            //var res = from p in ListGenerator.ProductsList
            //          where p.UnitsInStock > 0
            //          group p by p.Category
            //          into x
            //          where x.Count() > 10
            //          select x;
            #endregion
            //foreach (var c in res)
            //{
            //    Console.WriteLine(c.Key);
            //    foreach (var p in c) Console.WriteLine("                           " + p.ProductName);
            //}
            #region get category name of products in stock that contains more than 10 products and number of product in each category
            //var res = ListGenerator.ProductsList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category).Where(x => x.Count() > 10).Select(c => new
            //{
            //    name = c.Key,
            //    count = c.Count()
            //});

            //var res = from p in ListGenerator.ProductsList
            //          where p.UnitsInStock > 0
            //          group p by p.Category
            //          into g
            //          where g.Count() > 10
            //          select new { name = g.Key, count = g.Count() };

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion


            #region partitioning operators
            //Console.WriteLine(ListGenerator.ProductsList.Take(3));
            //Console.WriteLine(ListGenerator.ProductsList.Skip(5));
            //Console.WriteLine(ListGenerator.ProductsList.TakeLast(5));
            //Console.WriteLine(ListGenerator.ProductsList.SkipLast(5));

            //int[] numbers = { 5, 1, 6, 8, 2, 7, 9, 3, 4 };
            ////var res = numbers.TakeWhile(n => n < 9);
            ////var res = numbers.TakeWhile((n, i) => n > i);
            //var res = numbers.SkipWhile(n => n % 3 != 0);
            //foreach (var n in res) Console.WriteLine(n);
            #endregion
            #endregion


            //using CompanyDbContext dbContext = new CompanyDbContext();
            //var employee = dbContext.Employees.Where(e => e.age > 20);


            //dbContext.Database.Migrate();
            //CompanyDbContext dbContext = new CompanyDbContext();
            //try
            //{

            //}
            //finally
            //{
            //    dbContext.Dispose();
            //}

        }
    }
}

/*
 * to add migration: Add-Migration "migration_name"
 * to apply migration: update-database
 * to remove migration: Remove-Migration [must not be applied]
 * to rollback migration: update-database -Migration "previous_migration"
 * to rollback first migration: update-database 0
 * 
 */ 