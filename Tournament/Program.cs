using Tournament.Services;

namespace Tournament
{
    public class Program
    {
        static void Main(string[] args)
        {
            var start = new MenuService();
            while (true)
            {
                start.ShowMenu();

                Console.Write("Please enter your choice: ");
                string input = Console.ReadLine(); 
                start.HandleMenuChoice(input);
            }
        }
    }
}
