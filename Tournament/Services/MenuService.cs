using Tournament.DAL.Entities;

namespace Tournament.Services
{
    public class MenuService
    {
        private readonly TournamentOfSpanishService _tournamentOfSpanishService;


        public MenuService()
        {
            _tournamentOfSpanishService = new TournamentOfSpanishService();
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Show all tournaments");
            Console.WriteLine("2. Show tournament by name team");
            Console.WriteLine("3. Show tournaments by name city");
            Console.WriteLine("4. Show team with most wins");
            Console.WriteLine("5. Show team with most defeats");
            Console.WriteLine("6. Show team with most draws");
            Console.WriteLine("7. Show team with most goals");
            Console.WriteLine("8. Show team with most skip goals");
            Console.WriteLine("9. Add tournament");
            Console.WriteLine("10. Update tournament");
            Console.WriteLine("11. Delete tournament");
            Console.WriteLine("12. Exit");
        }

        public void HandleMenuChoice(string? choice)
        {
            Console.Clear();

            switch (choice)
            {
                case "1":
                    ShowAllTournaments();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "2":
                    ShowTournamentByNameTeam();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "3":
                    ShowTournamentsByNameCity();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "4":
                    _tournamentOfSpanishService.ShowTeamWithMostWins();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "5":
                    _tournamentOfSpanishService.ShowTeamWithMostDefeats();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "6":
                    _tournamentOfSpanishService.ShowTeamWithMostDraws();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "7":
                    _tournamentOfSpanishService.ShowTeamWithMostGoals();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "8":
                    _tournamentOfSpanishService.ShowTeamWithMostSkipGoals();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "9":
                    AddTournament();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "10":
                    UpdateTournament();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "11":
                    DeleteTournamentByNameCityAndNameTeam();
                    Console.WriteLine();
                    WaitForUser();
                    break;
                case "12":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    WaitForUser();
                    break;
            }
        }


        private void WaitForUser()
        {
            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }


        private void ShowAllTournaments()
        {
            var tournaments = _tournamentOfSpanishService.GetAllTournaments();

            foreach (var tournament in tournaments)
            {
                Console.WriteLine($"Name Team: {tournament.NameTeam}, \nName City: {tournament.NameCity}, \nCount Win: {tournament.CountWin}, \nCount Defeat: {tournament.CountDefeat}, \nCount Draw: {tournament.CountDraw}, \nCount Goals: {tournament.CountGoals}, \nCount Skip Goals: {tournament.CountSkipGoals}");
                Console.WriteLine("--------------------------------------------------");
            }
        }

        private void ShowTournamentByNameTeam()
        {
            var nameTeam = GetValidString("Enter name city:");

            var tournament = _tournamentOfSpanishService.GetTournamentByNameTeam(nameTeam);
            if (tournament == null)
            {
                Console.WriteLine("Tournament not found.");
                return;
            }
            Console.WriteLine($"Name Team: {tournament.NameTeam}, \nName City: {tournament.NameCity}, \nCount Win: {tournament.CountWin}, \nCount Defeat: {tournament.CountDefeat}, \nCount Draw: {tournament.CountDraw}, \nCount Goals: {tournament.CountGoals}, \nCount Skip Goals: {tournament.CountSkipGoals}");
        }


        private void ShowTournamentsByNameCity()
        {
            var nameCity = GetValidString("Enter name city:");

            var tournaments = _tournamentOfSpanishService.GetTournamentsByNameCity(nameCity);

            if (tournaments == null || tournaments.Count == 0)
            {
                Console.WriteLine("Tournaments not found.");
                return;
            }

            foreach (var tournament in tournaments)
            {
                Console.WriteLine($"Name Team: {tournament.NameTeam}, \nName City: {tournament.NameCity}, \nCount Win: {tournament.CountWin}, \nCount Defeat: {tournament.CountDefeat}, \nCount Draw: {tournament.CountDraw}, \nCount Goals: {tournament.CountGoals}, \nCount Skip Goals: {tournament.CountSkipGoals}");
                Console.WriteLine("--------------------------------------------------");
            }
        }


        private void AddTournament()
        {
            var nameTeam = GetValidString("Enter name team:");
            var nameCity = GetValidString("Enter name city:");
            int countWin = GetValidInt("Enter count win:");
            int countDefeat = GetValidInt("Enter count defeat:");
            int countDraw = GetValidInt("Enter count draw:");
            int countGoals = GetValidInt("Enter count goals:");
            int countSkipGoals = GetValidInt("Enter count skip goals:");


            var tournament = new TournamentOfSpanish
            {
                NameTeam = nameTeam,
                NameCity = nameCity,
                CountWin = countWin,
                CountDefeat = countDefeat,
                CountDraw = countDraw,
                CountGoals = countGoals,
                CountSkipGoals = countSkipGoals
            };
            _tournamentOfSpanishService.AddTournament(tournament);
        }

        private void UpdateTournament()
        {
            var nameTeam = GetValidString("Enter name city:");

            var tournament = _tournamentOfSpanishService.GetTournamentByNameTeam(nameTeam);
            if (tournament == null)
            {
                Console.WriteLine("Tournament not found.");
                return;
            }

            Console.WriteLine($"Current Name Team: {tournament.NameTeam}, \nName City: {tournament.NameCity}, \nCount Win: {tournament.CountWin}, \nCount Defeat: {tournament.CountDefeat}, \nCount Draw: {tournament.CountDraw}, \nCount Goals: {tournament.CountGoals}, \nCount Skip Goals: {tournament.CountSkipGoals}");

            Console.WriteLine();

            Console.WriteLine("What do you want to change?:");
            Console.WriteLine("1. Name Team");
            Console.WriteLine("2. Name City");
            Console.WriteLine("3. Count Win");
            Console.WriteLine("4. Count Defeat");
            Console.WriteLine("5. Count Draw");
            Console.WriteLine("6. Count Goals");
            Console.WriteLine("7. Count Skip Goals");
            Console.WriteLine("8. All");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    UpdateNameTeam(tournament);
                    break;
                case "2":
                    UpdateNameCity(tournament);
                    break;
                case "3":
                    UpdateCountWin(tournament);
                    break;
                case "4":
                    UpdateCountDefeat(tournament);
                    break;
                case "5":
                    UpdateCountDraw(tournament);
                    break;
                case "6":
                    UpdateCountGoals(tournament);
                    break;
                case "7":
                    UpdateCountSkipGoals(tournament);
                    break;
                case "8":
                    UpdateAll(tournament);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine("Please try again.");
                    break;
            }
        }


        private void UpdateNameTeam(TournamentOfSpanish tournament)
        {
            var nameTeam = GetValidString("Enter name city:");

            tournament.NameTeam = nameTeam;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }


        private void UpdateNameCity(TournamentOfSpanish tournament)
        {
            var nameCity = GetValidString("Enter new name city:");

            tournament.NameCity = nameCity;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }


        private void UpdateCountWin(TournamentOfSpanish tournament)
        {
            int countWin = GetValidInt("Enter new count win:");

            tournament.CountWin = countWin;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }


        private void UpdateCountDefeat(TournamentOfSpanish tournament)
        {
            int countDefeat = GetValidInt("Enter new count defeat:");

            tournament.CountDefeat = countDefeat;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }

        private void UpdateCountDraw(TournamentOfSpanish tournament)
        {
            int countDraw = GetValidInt("Enter new count draw:");

            tournament.CountDraw = countDraw;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }

        private void UpdateCountGoals(TournamentOfSpanish tournament)
        {
            int countGoals = GetValidInt("Enter new count goals:");

            tournament.CountGoals = countGoals;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }

        private void UpdateCountSkipGoals(TournamentOfSpanish tournament)
        {
            int countSkipGoals = GetValidInt("Enter new count skip goals:");

            tournament.CountSkipGoals = countSkipGoals;
            _tournamentOfSpanishService.UpdateTournament(tournament);
        }


        private void UpdateAll(TournamentOfSpanish tournament)
        {
            var nameTeam = GetValidString("Enter new name team:");
            var nameCity = GetValidString("Enter new name city:");
            int countWin = GetValidInt("Enter new count win: ");
            int countDefeat = GetValidInt("Enter new count defeat: ");
            int countDraw = GetValidInt("Enter new count draw: ");
            int countGoals = GetValidInt("Enter new count goals: ");
            int countSkipGoals = GetValidInt("Enter new count skip goals: ");

            tournament.NameTeam = nameTeam;
            tournament.NameCity = nameCity;
            tournament.CountWin = countWin;
            tournament.CountDefeat = countDefeat;
            tournament.CountDraw = countDraw;
            tournament.CountGoals = countGoals;
            tournament.CountSkipGoals = countSkipGoals;

            _tournamentOfSpanishService.UpdateTournament(tournament);
        }


        private void DeleteTournamentByNameTeam()
        {
            var nameTeam = GetValidString("Enter name team:");

            var tournament = _tournamentOfSpanishService.GetTournamentByNameTeam(nameTeam);
            if (tournament == null)
            {
                Console.WriteLine("Tournament not found.");
                return;
            }

            if (!ConsentOfDeletion())
            {
                return;
            }

            Console.WriteLine("Team remotely");
            _tournamentOfSpanishService.DeleteTournament(tournament);
        }


        private void DeleteTournamentByNameCity()
        {
            var nameCity = GetValidString("Enter name city:");

            var tournament = _tournamentOfSpanishService.GetTournamentByNameCity(nameCity);
            if (tournament == null)
            {
                Console.WriteLine("Tournaments not found.");
                return;
            }

            if (!ConsentOfDeletion())
            {
                return;
            }

            Console.WriteLine("Team remotely");
            _tournamentOfSpanishService.DeleteTournament(tournament);
        }


        private void DeleteTournamentByNameCityAndNameTeam()
        {
            Console.WriteLine("Why do you want to delete?");
            Console.WriteLine("1. By name team");
            Console.WriteLine("2. By name city");

            Console.WriteLine("Please enter your choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DeleteTournamentByNameTeam();
                    break;
                case "2":
                    DeleteTournamentByNameCity();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine("Please try again.");
                    break;
            }
        }


        private int GetValidInt(string message)
        {
            int result;
            while (true)
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out result) && result >= 0)
                {
                    return result;
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        private string GetValidString(string message)
        {
            string result;
            while (true)
            {
                Console.WriteLine(message);
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.");
            }
        }


        private bool ConsentOfDeletion()
        {
            Console.WriteLine("Are you sure you want to delete? (y/n)");

            var consent = Console.ReadLine();
            switch (consent)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    Console.WriteLine("Invalid choice.");
                    return ConsentOfDeletion();
            }
        }
    }
}
