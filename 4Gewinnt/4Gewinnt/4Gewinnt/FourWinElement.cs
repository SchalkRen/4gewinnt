using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{
    public class FourWinElement : ITreeElement<FourWinElement>
    {
        public Playfield playfield;
        
        public int heuristik;
        public Token currentPlayer;

        public FourWinElement(Playfield playfield, int heuristik, Token currentPlayer)
        {
            this.playfield = playfield;
            this.heuristik = playfield.GetHeuristik(Token.CPU);
            //this.heuristik = heuristik;
            this.currentPlayer = currentPlayer;
        }

        public FourWinElement[] GetAllPossibilities()
        {
            if(heuristik>=10000)
            {
                return new FourWinElement[0];
            }
            Playfield[] playfields = playfield.GetAllPossibleMoves(playfield,currentPlayer);
            List<FourWinElement> fourWinElements = new List<FourWinElement>();
            for(int i=0;i<playfields.Length;i++)
            {
                if (playfields[i].numberofplayers != -1)//Check ob das playfield auch möglich ist
                {
                    Token nextPlayer = Token.CPU;
                    if (currentPlayer == Token.CPU)
                    {
                        nextPlayer = Token.User;
                    }
                    

                    FourWinElement element = new FourWinElement(playfields[i], int.MaxValue, nextPlayer); //int. Max =Platzhalter, später wird das errechnet
                    fourWinElements.Add(element);
                }
            }

            return fourWinElements.ToArray();

        }
        public static int number=0;

        public int GetHeuristik()
        {
            int cheuristik;

            if(heuristik==int.MaxValue)
            {
                cheuristik = playfield.GetHeuristik(currentPlayer);
                heuristik = cheuristik;
            }
            else
            {
                cheuristik = heuristik;
            }
            return cheuristik;
        }
        public override string ToString()
        {
            return heuristik.ToString();
        }

        public void SetHeuristik(int Heuristik)
        {
            heuristik = Heuristik;
        }
    }
}
