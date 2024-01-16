using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    public class KI
    {
        public static Tree<FourWinElement>.MinMaxResult minMaxResult;

        public static int GetKITurn(Playfield spielfeld, int OldPlayerTurn, int depth)
        {

                FourWinElement StartElement = new FourWinElement(spielfeld.ClonePlayfield(), 0, Token.CPU);
                Tree<FourWinElement> currenttree = new Tree<FourWinElement>(depth, StartElement);
                minMaxResult = currenttree.MinMaxAlgorithmus(true);
                if(minMaxResult.nextItem!=null)
                {
                    minMaxResult.nextNumber = minMaxResult.nextItem.playfield.lastmove.coloumn;
                }
               
                return minMaxResult.nextNumber;


        }
    }
}
