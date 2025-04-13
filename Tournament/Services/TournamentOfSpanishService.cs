using Tournament.DAL.Entities;
using Tournament.DAL.Repositories;

namespace Tournament.Services
{
    public class TournamentOfSpanishService
    {
        private readonly TournamentOfSpanishRepository _repository;

        public TournamentOfSpanishService()
        {
            _repository = new TournamentOfSpanishRepository();
        }

        public IEnumerable<TournamentOfSpanish> GetAllTournaments()
        {
            return _repository.GetAllTournaments();
        }


        public TournamentOfSpanish? GetTournamentByNameTeam(string name)
        {
            return _repository.GetAllTournaments()
                              .FirstOrDefault(t => t.NameTeam == name);
        }

        public TournamentOfSpanish? GetTournamentByNameCity(string name)
        {
            return _repository.GetAllTournaments()
                              .FirstOrDefault(t => t.NameCity == name);
        }

        public List<TournamentOfSpanish> GetTournamentsByNameCity(string name)
        {
            return _repository.GetAllTournaments()
                              .Where(t => t.NameCity == name)
                              .ToList();
        }


        public TournamentOfSpanish? GetTournamentByNameCityAndNameTeam(string nameCity, string nameTeam)
        {
            return _repository.GetAllTournaments()
                              .FirstOrDefault(t => t.NameCity == nameCity && t.NameTeam == nameTeam);
        }


        public void ShowTeamWithMostWins()
        {
            var tournaments = _repository.GetAllTournaments();
            var teamWithMostWins = tournaments.OrderByDescending(t => t.CountWin).FirstOrDefault();
            
            if (teamWithMostWins == null)
            {
                Console.WriteLine("No tournaments found.");
            }

            Console.WriteLine($"Team with most wins: {teamWithMostWins?.NameTeam} with {teamWithMostWins?.CountWin} wins.");
        }

        public void ShowTeamWithMostDefeats()
        {
            var tournaments = _repository.GetAllTournaments();
            var teamWithMostDefeats = tournaments.OrderByDescending(t => t.CountDefeat).FirstOrDefault();
            if (teamWithMostDefeats == null)
            {
                Console.WriteLine("No tournaments found.");
            }
            Console.WriteLine($"Team with most defeats: {teamWithMostDefeats.NameTeam} with {teamWithMostDefeats.CountDefeat} defeats.");
        }


        public void ShowTeamWithMostDraws()
        {
            var tournaments = _repository.GetAllTournaments();
            var teamWithMostDraws = tournaments.OrderByDescending(t => t.CountDraw).FirstOrDefault();
            if (teamWithMostDraws == null)
            {
                Console.WriteLine("No tournaments found.");
            }
            Console.WriteLine($"Team with most draws: {teamWithMostDraws?.NameTeam} with {teamWithMostDraws?.CountDraw} draws.");
        }


        public void ShowTeamWithMostGoals()
        {
            var tournaments = _repository.GetAllTournaments();
            var teamWithMostGoals = tournaments.OrderByDescending(t => t.CountGoals).FirstOrDefault();
            if (teamWithMostGoals == null)
            {
                Console.WriteLine("No tournaments found.");
            }
            Console.WriteLine($"Team with most goals: {teamWithMostGoals?.NameTeam} with {teamWithMostGoals?.CountGoals} goals.");
        }


        public void ShowTeamWithMostSkipGoals()
        {
            var tournaments = _repository.GetAllTournaments();
            var teamWithMostSkipGoals = tournaments.OrderByDescending(t => t.CountSkipGoals).FirstOrDefault();
            if (teamWithMostSkipGoals == null)
            {
                Console.WriteLine("No tournaments found.");
            }
            Console.WriteLine($"Team with most skip goals: {teamWithMostSkipGoals?.NameTeam} with {teamWithMostSkipGoals?.CountSkipGoals} skip goals.");
        }


        public void AddTournament(TournamentOfSpanish tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentNullException(nameof(tournament), "Tournament cannot be null");
            }
            _repository.AddTournament(tournament);
        }


        public void AddTournaments(IEnumerable<TournamentOfSpanish> tournaments)
        {
            if (tournaments == null)
            {
                throw new ArgumentNullException(nameof(tournaments), "Tournaments cannot be null or empty");
            }
            _repository.AddTournaments(tournaments);
        }

        public void UpdateTournament(TournamentOfSpanish tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentNullException(nameof(tournament), "Tournament cannot be null");
            }
            _repository.UpdateTournament(tournament);
        }


        public void DeleteTournament(TournamentOfSpanish tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentNullException(nameof(tournament), "Tournament cannot be null");
            }
            _repository.DeleteTournament(tournament);
        }


        public void DeleteTournaments(IEnumerable<TournamentOfSpanish> tournaments)
        {
            if (tournaments == null)
            {
                throw new ArgumentNullException(nameof(tournaments), "Tournaments cannot be null or empty");
            }
            _repository.DeleteTournaments(tournaments);
        }


        public void DeleteByNameTeamAndNameCity(string nameTeam, string nameCity)
        {
            var tournament = _repository.GetAllTournaments()
                                        .FirstOrDefault(t => t.NameTeam == nameTeam && t.NameCity == nameCity);
            if (tournament == null)
            {
                throw new ArgumentNullException(nameof(tournament), "Tournaments cannot be null or empty");
            }
            _repository.DeleteTournament(tournament);
        }
    }
}
