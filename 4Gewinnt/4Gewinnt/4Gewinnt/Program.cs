using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{

    public static class globals
    {

        public static int rows, coloumns;
    }
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //FourWinElement fourWinElement = new FourWinElement(new Playfield(), 0, Token.empty);
            //Tree<FourWinElement> fullTree = new Tree<FourWinElement>(5, fourWinElement);
            //fullTree.PrintTree();
            //Debug.WriteLine(fullTree.MinMaxAlgorithmus());



            /*int turn = KI.GetKITurn(new Playfield(), 3, 2);
            Debug.WriteLine(turn);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);*/

            Application.Run(new Playertokenlist());
        }
        //static void Main()
        //{
        //    Console.WriteLine("HI");
        //    Console.ReadLine();

        //}
    }
}
