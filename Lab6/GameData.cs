using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class GameData
    {
        public int Bucks { get; set; }
        public int PlayerCount { get; set; }
        public int[] PlayersScores { get; set; }
        public bool[] IsPlayerFinished { get; set; } 
        public int NumberOfPlayersFinished { get; set; }
        public List<int> FinishedPlayers { get; set; }
        public int LostPlayer = -1;

        public GameData(int playersNumber, int bucks)
        {
            Bucks = bucks;
            NumberOfPlayersFinished = 0;
            FinishedPlayers = new List<int>();
            if (playersNumber <= 0)
            {
                PlayersScores = Array.Empty<int>();
                IsPlayerFinished = Array.Empty<bool>();
                return;
            }
            else
            {
                PlayerCount = playersNumber;
                PlayersScores = new int[playersNumber];
                IsPlayerFinished = new bool[playersNumber];
            }
        }
    }
}
