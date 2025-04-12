namespace Tournament.DAL.Entities

{
    public class TournamentOfSpanish
    {
        public int Id { get; set; }
        public string NameTeam { get; set; }
        public string NameCity { get; set; }
        public int CountWin { get; set; }
        public int CountDefeat { get; set; }
        public int CountDraw { get; set; }
        public int CountGoals { get; set; }
        public int CountSkipGoals { get; set; }
    }
}
