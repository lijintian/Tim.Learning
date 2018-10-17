using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //local SQL Express
            //LocalDb
            //Db name is fully qualified name of the derived context
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Blogs
                        orderby b.Name
                        select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        /// <summary>
        ///Virtual Navigation Properties,Enable Lazy Loading 
        /// 虚拟导航属性，允许懒加载
        /// </summary>
        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        /// <summary>
        ///Virtual Navigation Properties,Enable Lazy Loading 
        /// 虚拟导航属性，允许懒加载
        /// </summary>
        public virtual Blog Blog { get; set; }
    }


    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
