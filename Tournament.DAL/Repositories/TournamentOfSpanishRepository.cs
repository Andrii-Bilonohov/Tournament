using Tournament.DAL.Data;
using Tournament.DAL.Entities;

namespace Tournament.DAL.Repositories
{
    public class TournamentOfSpanishRepository
    {
        private readonly AppDbContext _context;


        public TournamentOfSpanishRepository()
        {
            _context = new AppDbContext();
        }


        public IEnumerable<TournamentOfSpanish> GetAllTournaments()
        {
            return _context.TournamentsOfSpanish.ToList();
        }


        public void AddTournament(TournamentOfSpanish tournament)
        {
            _context.TournamentsOfSpanish.Add(tournament);
            _context.SaveChanges();
        }


        public void AddTournaments(IEnumerable<TournamentOfSpanish> tournaments)
        {
            _context.TournamentsOfSpanish.AddRange(tournaments);
            _context.SaveChanges();
        }


        public void UpdateTournament(TournamentOfSpanish tournament)
        {
            _context.TournamentsOfSpanish.Update(tournament);
            _context.SaveChanges();
        }


        public void DeleteTournament(TournamentOfSpanish tournament)
        {
            _context.TournamentsOfSpanish.Remove(tournament);
            _context.SaveChanges();
        }


        public void DeleteTournaments(IEnumerable<TournamentOfSpanish> tournaments)
        {
            _context.TournamentsOfSpanish.RemoveRange(tournaments);
            _context.SaveChanges();
        }
    }
}
