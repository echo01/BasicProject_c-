using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_tic_tac_toe
{
    public partial class Form1 : Form
    {
        player human = new player('X');
        player bot = new player('O');
        boardtable board = new boardtable(true);
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Image = null;
            button2.Image = null;
            button3.Image = null;
            button4.Image = null;
            button5.Image = null;
            button6.Image = null;
            button7.Image = null;
            button8.Image = null;
            button9.Image = null;
            label1.Text = "";
            human.reload('X');
            bot.reload('O');
            board.reload(true);
        }

        public bool Check_winner(player phuman,player pbot)
        {
            int score_row1 = 0, score_row2 = 0, score_row3 = 0;
            int score_col1 = 0, score_col2 = 0, score_col3 = 0;
            int score_crossR = 0, score_crossL = 0;

            score_row1 = human.space[0] + human.space[1] + human.space[2];
            score_row2 = human.space[3] + human.space[4] + human.space[5];
            score_row3 = human.space[6] + human.space[7] + human.space[8];

            score_col1 = human.space[0] + human.space[3] + human.space[6];
            score_col2 = human.space[1] + human.space[4] + human.space[7];
            score_col3 = human.space[2] + human.space[5] + human.space[8];

            score_crossR = human.space[0] + human.space[4] + human.space[8];
            score_crossL = human.space[2] + human.space[4] + human.space[6];

            score_row1 /= 3;
            score_row2 /= 3;
            score_row3 /= 3;

            score_col1 /= 3;
            score_col2 /= 3;
            score_col3 /= 3;

            score_crossL /= 3;
            score_crossR /= 3;

            if ((score_row1 > 0) || (score_row2 > 0) || (score_row3 > 0) || (score_col1 > 0) || (score_col2 > 0) || (score_col3 > 0) || (score_crossL > 0) || (score_crossR > 0))
            {
                board.winner = human.psymbol;
                //pboard->playing = false;
                label1.Text = "You WIN";
                return (true);
            }

            score_row1 = bot.space[0] + bot.space[1] + bot.space[2];
            score_row2 = bot.space[3] + bot.space[4] + bot.space[5];
            score_row3 = bot.space[6] + bot.space[7] + bot.space[8];

            score_col1 = bot.space[0] + bot.space[3] + bot.space[6];
            score_col2 = bot.space[1] + bot.space[4] + bot.space[7];
            score_col3 = bot.space[2] + bot.space[5] + bot.space[8];

            score_crossR = bot.space[0] + bot.space[4] + bot.space[8];
            score_crossL = bot.space[2] + bot.space[4] + bot.space[6];

            score_row1 /= 3;
            score_row2 /= 3;
            score_row3 /= 3;

            score_col1 /= 3;
            score_col2 /= 3;
            score_col3 /= 3;

            score_crossL /= 3;
            score_crossR /= 3;

            if ((score_row1 > 0) || (score_row2 > 0) || (score_row3 > 0) || (score_col1 > 0) || (score_col2 > 0) || (score_col3 > 0) || (score_crossL > 0) || (score_crossR > 0))
            {
                board.winner = bot.psymbol;
                //pboard->playing = false;
                label1.Text = "Robot WIN";
                return (true);
            }

            return (false);
        }

        public bool chek_board_Is_full(boardtable t)
        {
            int empety_space = 0;
            for (int i = 0; i < 9; i++)
            {
                if (t.space[i] == ' ')
                    empety_space += 1;
            }
            if (empety_space == 0)
                return true;
            return false;
        }

        public void bot_turn()
        {
            bot.run = true;
            while (bot.run)
            {
                if (chek_board_Is_full(board))
                    return;
                bot.choose = random.Next(1, 10);
                switch (bot.choose)
                {
                    case 1:
                        if (board.space[0] == ' ')
                        {
                            board.space[0] = bot.psymbol;
                            bot.space[0] = 1;
                            button1.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 2:
                        if (board.space[1] == ' ')
                        {
                            board.space[1] = bot.psymbol;
                            bot.space[1] = 1;
                            button2.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 3:
                        if (board.space[2] == ' ')
                        {
                            board.space[2] = bot.psymbol;
                            bot.space[2] = 1;
                            button3.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 4:
                        if (board.space[3] == ' ')
                        {
                            board.space[3] = bot.psymbol;
                            bot.space[3] = 1;
                            button6.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 5:
                        if (board.space[4] == ' ')
                        {
                            board.space[4] = bot.psymbol;
                            bot.space[4] = 1;
                            button5.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 6:
                        if (board.space[5] == ' ')
                        {
                            board.space[5] = bot.psymbol;
                            bot.space[5] = 1;
                            button4.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 7:
                        if (board.space[6] == ' ')
                        {
                            board.space[6] = bot.psymbol;
                            bot.space[6] = 1;
                            button9.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 8:
                        if (board.space[7] == ' ')
                        {
                            board.space[7] = bot.psymbol;
                            bot.space[7] = 1;
                            button8.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                    case 9:
                        if (board.space[8] == ' ')
                        {
                            board.space[8] = bot.psymbol;
                            bot.space[8] = 1;
                            button7.Image = Properties.Resources.O_small;
                            bot.run = false;
                        }
                        break;
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (board.space[0] == ' ')
            {
                board.space[0] = human.psymbol;
                human.space[0] = 1;
                button1.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (board.space[1] == ' ')
            {
                board.space[1] = human.psymbol;
                human.space[1] = 1;
                button2.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (board.space[2] == ' ')
            {
                board.space[2] = human.psymbol;
                human.space[2] = 1;
                button3.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (board.space[3] == ' ')
            {
                board.space[3] = human.psymbol;
                human.space[3] = 1;
                button6.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (board.space[4] == ' ')
            {
                board.space[4] = human.psymbol;
                human.space[4] = 1;
                button5.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (board.space[5] == ' ')
            {
                board.space[5] = human.psymbol;
                human.space[5] = 1;
                button4.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (board.space[6] == ' ')
            {
                board.space[6] = human.psymbol;
                human.space[6] = 1;
                button9.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (board.space[7] == ' ')
            {
                board.space[7] = human.psymbol;
                human.space[7] = 1;
                button8.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (board.space[8] == ' ')
            {
                board.space[8] = human.psymbol;
                human.space[8] = 1;
                button7.Image = Properties.Resources.x_small;
                bot_turn();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Check_winner(human,bot);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1_Load(sender,e);
        }
    }
}
