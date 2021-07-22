using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerStarAssessment
{
    public class FixtureStatus
    {
        public bool displayed { get; set; }
        public bool suspended { get; set; }
    }

    public class Goal
    {
        public int clockTime { get; set; }
        public bool confirmed { get; set; }
        public int id { get; set; }
        public bool ownGoal { get; set; }
        public bool penalty { get; set; }
        public string period { get; set; }
        public int playerId { get; set; }
        public string teamId { get; set; }
    }

    public class Team
    {
        public string association { get; set; }
        public string name { get; set; }
        public string teamId { get; set; }
    }

    public class FootballFullState
    {
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
        public bool finished { get; set; }
        public int gameTimeInSeconds { get; set; }
        public List<Goal> goals { get; set; }
        public string period { get; set; }
        public List<object> possibles { get; set; }
        public List<object> corners { get; set; }
        public List<object> redCards { get; set; }
        public List<object> yellowCards { get; set; }
        public DateTime startDateTime { get; set; }
        public bool started { get; set; }
        public List<Team> teams { get; set; }
    }

    public class Root
    {
        public string fixtureId { get; set; }
        public FixtureStatus fixtureStatus { get; set; }
        public FootballFullState footballFullState { get; set; }
    }
}
