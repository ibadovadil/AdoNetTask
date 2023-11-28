using AdoNetTask.Models;
using AdoNetTask.Services;

namespace AdoNetTask
{
    internal class Program
    {
        private static bool isLoggedIn = false;
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");

                if (isLoggedIn)
                {
                    Console.WriteLine("3. GetAllBlogs");
                    Console.WriteLine("4. GetBlogById");
                    Console.WriteLine("5. CreateBlog");
                    Console.WriteLine("6. EditUser");
                    Console.WriteLine("7. DeleteUser");
                    Console.WriteLine("8. Logout");
                }

                Console.WriteLine("9. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UserService.Login();
                        break;

                    case "2":
                        UserService.Register();
                        break;

                    case "3" when isLoggedIn:
                        BlogService.GetAll();
                        break;

                    case "4" when isLoggedIn:
                        Console.Write("Enter Blog Id: ");
                        int blogId = int.Parse(Console.ReadLine());
                        BlogService.GetById(blogId);
                        break;

                    case "5" when isLoggedIn:

                        Blog a = new Blog
                        {
                            Title = Console.ReadLine(),
                            Description = Console.ReadLine(),
                            UserId = Convert.ToInt32(Console.ReadLine()),

                        };
                        BlogService.Create(a);
                        foreach (var blog in BlogService.GetAll())
                        {
                            Console.WriteLine($"{blog.Id} {blog.Title} {blog.Description} {blog.UserId}");
                        }
                        break;

                    case "6" when isLoggedIn:
                        UserService.Edit();
                        break;

                    case "7" when isLoggedIn:
                        UserService.Delete();
                        break;

                    case "9":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }
            }
        }
    }
}