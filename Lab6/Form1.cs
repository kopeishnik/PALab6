using Lab6.Properties;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public bool Active = false;
        Game CurrentGame = new(0, 0);
        public Random Rand = new();
        public int CurrentPlayer = -1;
        public bool botmatch = false;
        private int d1, d2, d3;
        public Form1()
        {
            InitializeComponent();
        }
        private int n1 = 0, m1 = 0;
        private int n2 = 0, m2 = 0;
        private int n3 = 0, m3 = 0;
        public void ChangePicture1(int num)
        {
            num = num % 6 + 1;
            if (num == 1)
            {
                pictureBox1.Image = Resources._1;
            }
            else if (num == 2)
            {
                pictureBox1.Image= Resources._2;
            }
            else if (num == 3)
            {
                pictureBox1.Image=(Resources._3);
            }
            else if (num == 4)
            {
                pictureBox1.Image = (Resources._4);
            }
            else if (num == 5)
            {
                pictureBox1.Image = (Resources._5);
            }
            else
            {
                pictureBox1.Image = (Resources._6);
            }
        }
        public void ChangePicture2(int num)
        {
            num = num % 6 + 1;
            if (num == 1)
            {
                pictureBox2.Image = Resources._1;
            }
            else if (num == 2)
            {
                pictureBox2.Image = Resources._2;
            }
            else if (num == 3)
            {
                pictureBox2.Image = (Resources._3);
            }
            else if (num == 4)
            {
                pictureBox2.Image = (Resources._4);
            }
            else if (num == 5)
            {
                pictureBox2.Image = (Resources._5);
            }
            else
            {
                pictureBox2.Image = (Resources._6);
            }
        }
        public void ChangePicture3(int num)
        {
            num = num % 6 + 1;
            if (num == 1)
            {
                pictureBox3.Image = Resources._1;
            }
            else if (num == 2)
            {
                pictureBox3.Image = Resources._2;
            }
            else if (num == 3)
            {
                pictureBox3.Image = (Resources._3);
            }
            else if (num == 4)
            {
                pictureBox3.Image = (Resources._4);
            }
            else if (num == 5)
            {
                pictureBox3.Image = (Resources._5);
            }
            else
            {
                pictureBox3.Image = (Resources._6);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int playersCount = (int)playersNumberUpDown.Value;
            MainTextBox.Text = $"Rolling the dice to decide what number will be 'bucks' in this game...";
            if (botsCheckBox1.Checked)
            {
                botmatch = true;
            }
            else
            {
                botmatch = false;
            }
            int bucks = Rand.Next() % 6;
            CurrentGame = new(playersCount, bucks);
            n2 = 6 + bucks;
            m2 = 0;
            timer2.Enabled = true;
            //ChangePicture2(bucks);
            MainTextBox.Text = $"Todays bucks is number {bucks + 1}";
            labelBucks.Text = $"Bucks: {bucks + 1}";
            MainTextBox.Text += $"\nNow player {CurrentGame.CurrentPlayer + 1}'s turn.";
            labelPlayerNumber.Text = $"Player {CurrentGame.CurrentPlayer + 1}, your turn:";

            startButton.Enabled = false;
            botsCheckBox1.Enabled = false;
            playersNumberUpDown.Enabled = false;
            DiceRollButton.Enabled = true;
        }

        private void DiceRollButton_Click(object sender, EventArgs e)
        {
            DiceRollButton.Enabled = false;
            d1 = Rand.Next();
            do
            {
                d2 = Rand.Next();
            } while (d1 == d2);
            do
            {
                d3 = Rand.Next();
            } while (d2 == d3);
            d1 %= 6;
            d2 %= 6;
            d3 %= 6;
            n1 = 18 + d1;
            m1 = 0;
            n2 = 18 + d2;
            m2 = 0;
            n3 = 18 + d3;
            m3 = 0;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            //while (timer1.Enabled || timer2.Enabled || timer3.Enabled)
            //{
            //    continue;
            //}
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (!timer1.Enabled && !timer2.Enabled && !timer3.Enabled)
            {
                timer4.Enabled = false;
                int prev = CurrentGame.CurrentPlayer;
                int x = CurrentGame.ReturnResultOfTurn(d1, d2, d3);
                CurrentGame.TurnProcessing(d1, d2, d3);
                if (x == 0)
                {
                    MainTextBox.Text = $"You've got no bucks. You have {CurrentGame.Data.PlayersScores[prev]} points.";
                }
                else if (x == 1)
                {
                    MainTextBox.Text = $"You've got a bucks, now you have {CurrentGame.Data.PlayersScores[prev]} points.";
                }
                else if (x == 115)
                {
                    MainTextBox.Text = $"You've got a bucks, and you win with {CurrentGame.Data.PlayersScores[prev]} points.";
                }
                else if (x == 5)
                {
                    MainTextBox.Text = $"You've got a Smol Bucks, now you have {CurrentGame.Data.PlayersScores[prev]} points.";
                }
                else if (x == 515)
                {
                    MainTextBox.Text = $"You've got a Smol Bucks, and now you win with {CurrentGame.Data.PlayersScores[prev]} points.";
                }
                else if (x == -5)
                {
                    MainTextBox.Text = $"You've got a Smol Bucks, but you have {CurrentGame.Data.PlayersScores[prev]} points, so small bucks didnt count.";
                }
                else if (x == 15)
                {
                    MainTextBox.Text = $"You've got a Big Bucks, so you instantly win with 15 points.";
                }
                if (prev == CurrentGame.CurrentPlayer)
                {
                    MainTextBox.Text += "\nContinue rolling!";
                }
                else if (CurrentGame.CurrentPlayer == -1)
                {
                    GameEnded();
                }
                else if (CurrentGame.Data.NumberOfPlayersFinished == CurrentGame.Data.PlayerCount - 1)
                {
                    GameEnded();
                }
                else
                {
                    MainTextBox.Text += $"\nNow player {CurrentGame.CurrentPlayer + 1}'s turn.";
                    labelPlayerNumber.Text = $"Player {CurrentGame.CurrentPlayer + 1}, your turn:";
                }
                timer5.Enabled = true;
                timer4.Enabled = false;
            }
        }

        public void GameEnded()
        {
            MainTextBox.Text = "Game ended.\n";
            timer5.Enabled = false;
            if (CurrentGame.Data.PlayerCount == 2)
            {
                MainTextBox.Text += $"Todays winner is player {CurrentGame.Data.FinishedPlayers[0] + 1}";
            }
            else if (CurrentGame.Data.PlayerCount == 3)
            {
                MainTextBox.Text += $"Todays winner is player {CurrentGame.Data.FinishedPlayers[0] + 1}\nLoser is player {CurrentGame.Data.LostPlayer + 1}";
            }
            else
            {
                MainTextBox.Text += $"Todays top 3 players are: {CurrentGame.Data.FinishedPlayers[0] + 1}, {CurrentGame.Data.FinishedPlayers[1] + 1}, {CurrentGame.Data.FinishedPlayers[2] + 1}.\nLoser is player {CurrentGame.Data.LostPlayer + 1}.";

            }
            labelBucks.Text = "<- Start the game";
            startButton.Enabled = true;
            playersNumberUpDown.Enabled = true;
            botsCheckBox1.Enabled = true;
            DiceRollButton.Enabled = false;
            Active = false;
            labelPlayerNumber.Text = "";
        }
        private void stopGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            w = 0;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            labelBucks.Text = "<- Start the game";
            startButton.Enabled = true;
            playersNumberUpDown.Enabled = true;
            botsCheckBox1.Enabled = true;
            DiceRollButton.Enabled = false;
            Active = false;
            labelPlayerNumber.Text = "";
            MainTextBox.Text = "Press start to start the game.";
        }
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string message = "Ця програма була створена Зеленським Олександром.\nLicensed under the terms of the GNU Lesser General Public License v3 or later (LGPLv3+)";
            string caption = "Про програму";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            _ = MessageBox.Show(message, caption, buttons);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int w = 0;

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (w < 50)
            {
                w++;
            }
            else
            {
                if (botmatch && CurrentGame.CurrentPlayer > 0)
                {
                    DiceRollButton_Click(sender, e);
                }
                else
                {
                    DiceRollButton.Enabled = true;
                }
                w = 0;
                timer5.Enabled = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m1 <= n1)
            {
                ChangePicture1(m1);
                m1++;
            }
            else
            {
                timer1.Enabled = false;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (m2 <= n2)
            {
                ChangePicture2(m2);
                m2++;
            }
            else
            {
                timer2.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (m3 <= n3)
            {
                ChangePicture3(m3);
                m3++;
            }
            else
            {
                timer3.Enabled = false;
            }
        }
    }
}