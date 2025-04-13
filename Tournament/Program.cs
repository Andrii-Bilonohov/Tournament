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
                start.Menu();
            }
        }   
    }
}
