using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    interface IHeuristik
    {

        int GetHeuristik(Token player); // player -um Auszusuchen für wen die Heuristik bestimmt 
        Token IsGameOver(); //gibt den Gewinner zurück

    }
}
