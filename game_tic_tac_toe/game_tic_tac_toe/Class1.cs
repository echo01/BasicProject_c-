using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_tic_tac_toe
{
    internal class Class1
    {
    }

    public class player
    {
        public char psymbol;
        public int choose;   // choose = number
        public int[] space;
        public bool run;
        public player(char sym)
        {
            space = new int[9];
            choose = 0;
            psymbol = sym;
            run = true;
        }

        public void reload(char sym)
        {
            space = new int[9];
            choose = 0;
            psymbol = sym;
            run = true;
        }

    }

    public class boardtable
    {
        public char[] space;
        public bool playing;
        public char winner;

        public boardtable(bool playstatus)
        {
            playing = playstatus;
            space = new char[9];
            winner = ' ';
            for (int i = 0; i < 9; i++)
            {
                space[i] = ' ';
            }
        }

        public void reload(bool playstatus)
        {
            playing = playstatus;
            space = new char[9];
            winner = ' ';
            for (int i = 0; i < 9; i++)
            {
                space[i] = ' ';
            }
        }

    }
}
