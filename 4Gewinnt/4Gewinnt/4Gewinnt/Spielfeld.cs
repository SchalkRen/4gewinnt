using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    public enum Token{
        empty,
        User,
        CPU
    }
    public class Playfield : IHeuristik
    {
        public Token[,] spielfeld ;

        public int numberofplayers;

        public int[] numberoftoken;

        public bool IsMainBoard;

        public lastturn lastmove;

        public int length, width;

        private bool gamerrunning = true;

        private int  wincounterw = 0, wincounters = 0, wincounterdauf = 0, wincounterddown = 0;

        private bool left = false, right = false, up = false, down = false, diagupright = false, diagdownright = false, diagdownleft = false, diagupleft = false;

        private bool emleft, emright, emup, emdown, emupleft, emdownright, emdownleft, emupright;
        public int turns = 0;


        public class lastturn
        {

            public int coloumn, row;
        }

        public void Init(int lenght,int width)
        {

            spielfeld = new Token[lenght, width];
            numberoftoken = new int[lenght];
            lastmove = new lastturn();
            this.length = lenght;
            this.width = width;
        }

        public bool AddToken(Token t,int column)
        {
            if(numberoftoken[column]<width)
            {
            spielfeld[column, numberoftoken[column]] = t;

            this.lastmove.coloumn = column;
            this.lastmove.row = numberoftoken[column];

            numberoftoken[column]++;
                return true;
            }
            turns++;
            return false;
        }

        public int GetHeuristik(Token player)
        {

            int heuristik = 0;

            heuristik = Heuristik(player);

            if(player == Token.User)
            {

                heuristik = heuristik - Heuristik(Token.CPU);
            }
            else
            {
                
                heuristik = heuristik - Heuristik(Token.User) * 2;
               
            }

            return heuristik;
        }

        public void IsGameOver(Token winner)
        {

            
            if(winner == Token.User)
            {

                Winnerp1 winscreen = new Winnerp1();
                winscreen.Show();
            }
            else
            {

                Winnerp2 winscreen = new Winnerp2();
                winscreen.Show();
            }

            
        }
        /// <summary>
        /// This function returns all possible next moves for the current playfield
        /// 
        /// </summary>
        /// <param name="playfield"></param>
        /// <param name="nextPlayer"></param>
        /// <returns></returns>
        public Playfield[] GetAllPossibleMoves(Playfield playfield,Token nextPlayer)
        {
            Playfield[] allPlayfields = new Playfield[width];

            for(int i=0;i<width;i++)
            {
                Playfield cplayfield = playfield.ClonePlayfield();

                    
                if(cplayfield.AddToken(nextPlayer,i))
                {
                  
                }
                else
                {
                    cplayfield.numberofplayers = -1;//Setzen auf -1 um zu wissen, dass dies nicht möglich ist!

                }
                allPlayfields[i] = cplayfield;
            }
            return allPlayfields;
        }

        public Playfield ClonePlayfield()
        {
            Playfield cplayfield = new Playfield();
            cplayfield.spielfeld = (Token[,])spielfeld.Clone();
            cplayfield.numberofplayers = numberofplayers;
            cplayfield.numberoftoken = (int[])numberoftoken.Clone();
            cplayfield.width = width;
            cplayfield.length =length;
            Playfield.lastturn lastturn = new Playfield.lastturn();
            lastturn.coloumn = lastmove.coloumn;
            lastturn.row = lastmove.row;
            cplayfield.lastmove = lastturn;
            cplayfield.IsMainBoard = false;
            return cplayfield;
        }

        public Token IsGameOver()
        {
            throw new NotImplementedException();
        }

        private int Heuristik( Token player)
        {
            int heuristik = 0;
            for (int i = 0; i < this.length; i++)
            {

                for (int k = 0; k < numberoftoken[i]; k++)
                {

                    right = false;
                    left = false;
                    up = false;
                    down = false;
                    diagdownleft = false;
                    diagdownright = false;
                    diagupleft = false;
                    diagupright = false;

                    wincounterw = 0;
                    wincounters = 0;
                    wincounterdauf = 0;
                    wincounterddown = 0;

                    emleft = false;
                    emright = false;
                    emup = false;
                    emdown = false;

                    emupleft = false;
                    emdownleft = false;
                    emdownright = false;
                    emupright = false;

                    for (int n = 0; n < 4; n++)
                    {

                        if (i + n < this.length && right == false && emright == false)
                        {

                            if (spielfeld[i + n, k] == player)
                            {

                                heuristik++;
                                wincounterw++;
                            }
                            else
                            {

                                if (spielfeld[i + n, k] != Token.empty)
                                {

                                    // heuristik--;
                                    right = true;
                                }
                                else
                                {

                                    emright = true;
                                }
                            }
                        }
                        else
                        {

                            right = true;
                        }

                        if (i - n >= 0 && left == false && emleft == false)
                        {

                            if (spielfeld[i - n, k] == player)
                            {

                                heuristik++;
                                wincounterw++;
                            }
                            else
                            {

                                if (spielfeld[i - n, k] != Token.empty)
                                {

                                    // heuristik--;
                                    left = true;
                                }
                                else
                                {

                                    emleft = true;
                                }
                            }
                        }
                        else
                        {

                            left = true;
                        }

                        // luuuuuuuuul

                        if (k + n < numberoftoken[i] && up == false && emup == false)
                        {

                            if (spielfeld[i, k + n] == player)
                            {

                                heuristik++;
                                wincounters++;
                            }
                            else
                            {

                                if (spielfeld[i, k + n] != Token.empty)
                                {

                                    //heuristik--;
                                    up = true;
                                }
                                else
                                {

                                    emup = true;
                                }
                            }
                        }
                        else
                        {

                            up = true;
                        }

                        if (k - n >= 0 && down == false && emdown == false)
                        {

                            if (spielfeld[i, k - n] == player)
                            {

                                heuristik++;
                                wincounters++;
                            }
                            else
                            {

                                if (spielfeld[i, k - n] != Token.empty)
                                {

                                    heuristik--;
                                    down = true;
                                }
                                else
                                {

                                    emdown = true;
                                }
                            }
                        }
                        else
                        {

                            down = true;
                        }

                        // leeeeeeel

                        if (i - n >= 0 && k - n >= 0 && diagdownleft == false && emdownleft == false)
                        {

                            if (spielfeld[i - n, k - n] == player)
                            {

                                heuristik++;
                                wincounterdauf++;
                            }
                            else
                            {

                                if (spielfeld[i - n, k - n] != Token.empty)
                                {

                                    //heuristik--;
                                    diagdownleft = true;
                                }
                                else
                                {

                                    emdownleft = true;
                                }
                            }
                        }
                        else
                        {

                            diagdownleft = true;
                        }

                        if (i + n < this.length && k + n < numberoftoken[i + n] && diagupright == false && emupright == false)
                        {

                            if (spielfeld[i + n, k + n] == player)
                            {

                                heuristik++;
                                wincounterdauf++;
                            }
                            else
                            {

                                if (spielfeld[i + n, k + n] != Token.empty)
                                {

                                    //heuristik--;
                                    diagupright = true;
                                }
                                else
                                {

                                    emupright = true;
                                }
                            }
                        }
                        else
                        {

                            diagupright = true;
                        }


                        // laaaaal


                        if (i - n >= 0 && k + n < numberoftoken[i - n] && diagupleft == false && emupleft == false)
                        {

                            if (spielfeld[i - n, k + n] == player)
                            {

                                heuristik++;
                                wincounterddown++;
                            }
                            else
                            {

                                if (spielfeld[i - n, k + n] != Token.empty)
                                {

                                    //heuristik--;
                                    diagupleft = true;
                                }
                                else
                                {

                                    emupleft = true;
                                }
                            }
                        }
                        else
                        {

                            diagupleft = true;
                        }


                        if (i + n < this.length && k - n >= 0 && diagdownright == false && emdownright == false)
                        {

                            if (spielfeld[i + n, k - n] == player)
                            {

                                heuristik++;
                                wincounterddown++;
                            }
                            else
                            {

                                if (spielfeld[i + n, k - n] != Token.empty)
                                {

                                    heuristik--;
                                    diagdownright = true;
                                }
                                else
                                {

                                    emdownright = true;
                                }
                            }
                        }
                        else
                        {

                            diagdownright = true;
                        }

                       
                        if ((wincounterdauf > 3 || wincounterddown > 3 || wincounters > 3 || wincounterw > 3) && gamerrunning == true)
                        {

                            heuristik += 150;
                        }
                        else if ((wincounterdauf > 2 || wincounterddown > 2 || wincounters > 2 || wincounterw > 2) && gamerrunning == true)
                        {

                            heuristik += 50;
                        }
                        if ((wincounterdauf > 4 || wincounterddown > 4 || wincounters > 4 || wincounterw > 4) && gamerrunning == true)
                        {

                            heuristik = 10000;
                            if (IsMainBoard)
                            {
                                IsGameOver(player);
                                gamerrunning = false;
                            }


                        }
                    }
                }
            }

            return heuristik;
        }
    }
}
