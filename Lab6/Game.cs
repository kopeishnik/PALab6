using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Game
    {
        public GameData Data;
        public int CurrentPlayer;
        public Game(int playerCount, int bucks)
        {
            Data = new(playerCount, bucks);
            CurrentPlayer = 0;
        }
        public int GetNext(int prev)
        {
            int next = prev + 1;
            while (next != prev)
            {
                if (next >= Data.PlayerCount)
                {
                    next = 0;
                }
                if (Data.PlayersScores[next] < 15)
                {
                    return next;
                }
            }
            return -1;
        }
        public void TurnProcessing(int d1, int d2, int d3)
        {
            if (d1 == d2 && d2 == d3 && d1 == Data.Bucks)
            {
                Data.PlayersScores[CurrentPlayer] = 15;
                Data.FinishedPlayers.Add(CurrentPlayer);
                Data.NumberOfPlayersFinished++;

                CurrentPlayer = GetNext(CurrentPlayer);
            }
            else if (d1 == d2 && d2 == d3 && d1 != Data.Bucks)
            {
                if (Data.PlayersScores[CurrentPlayer] + 5 <= 15)
                {
                    Data.PlayersScores[CurrentPlayer] += 5;
                }
                if (Data.PlayersScores[CurrentPlayer] == 15)
                {
                    Data.FinishedPlayers.Add(CurrentPlayer);
                    Data.NumberOfPlayersFinished++;
                }
                CurrentPlayer = GetNext(CurrentPlayer);
            }
            else if (d1 == Data.Bucks || d2 == Data.Bucks || d3 == Data.Bucks)
            {
                Data.PlayersScores[CurrentPlayer]++;
                if (Data.PlayersScores[CurrentPlayer] == 15)
                {
                    Data.FinishedPlayers.Add(CurrentPlayer);
                    Data.NumberOfPlayersFinished++;
                    CurrentPlayer = GetNext(CurrentPlayer);
                }
            }
            else
            {
                CurrentPlayer = GetNext(CurrentPlayer);
            }
        }
        public int ReturnResultOfTurn(int d1, int d2, int d3)
        {
            if (d1 == d2 && d2 == d3 && d1 == Data.Bucks)
            {
                return 15;
            }
            else if (d1 == d2 && d2 == d3 && d1 != Data.Bucks)
            {
                if (Data.PlayersScores[CurrentPlayer] + 5 < 15)
                {
                    return 5;
                }
                else if (Data.PlayersScores[CurrentPlayer] + 5 == 15)
                {
                    return 515;
                }
                else
                {
                    return -5;
                }
            }
            else if (d1 == Data.Bucks || d2 == Data.Bucks || d3 == Data.Bucks)
            {
                if (Data.PlayersScores[CurrentPlayer] + 1 < 15)
                {
                    return 1;
                }
                else
                {
                    return 115;
                }
            }
            else return 0;
        }
    }
}
