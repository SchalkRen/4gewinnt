using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt
{

    public partial class Playertokenlist : Form
    {

        public Playfield Spielfeld;

        private PictureBox[,] Field;
        private Button[] RowbuttonArray;

        private Token playerturn = Token.User;

        bool gamerunning = false;

        public Playertokenlist()
        {

            InitializeComponent();

            Field = new PictureBox[,]
            {
                
                { Field00, Field10, Field20, Field30, Field40, Field50, Field60, Field70, Field80, Field90 },
                { Field01, Field11, Field21, Field31, Field41, Field51, Field61, Field71, Field81, Field91 },
                { Field02, Field12, Field22, Field32, Field42, Field52, Field62, Field72, Field82, Field92 },
                { Field03, Field13, Field23, Field33, Field43, Field53, Field63, Field73, Field83, Field93 },
                { Field04, Field14, Field24, Field34, Field44, Field54, Field64, Field74, Field84, Field94 },
                { Field05, Field15, Field25, Field35, Field45, Field55, Field65, Field75, Field85, Field95 },
                { Field06, Field16, Field26, Field36, Field46, Field56, Field66, Field76, Field86, Field96 }
            };

            RowbuttonArray = new Button[]
            {

                ButtonRow0, ButtonRow1, ButtonRow2, ButtonRow3, ButtonRow4, ButtonRow5, ButtonRow6, ButtonRow7, ButtonRow8, ButtonRow9
            };
        }

        private void Testbutton_Click(object sender, EventArgs e)
        {

            Spielfeld = new Playfield();
            Spielfeld.IsMainBoard = true;

            Spielfeld.Init((Int16)Coloumns.Value, (Int16)Rows.Value);

            Spielfeld.numberofplayers = (Int16) NumberofPlayers.Value;

            for(int i = 0; i < (Int16)Rows.Value; i++)
            {

                Spielfeld.numberoftoken[i] = 0;
            }

            for(int i = 0; i<(Int16)Coloumns.Value; i++)
            {

                for (int k = 0; k < (Int16)Rows.Value; k++)
                {

                    Field[k, i].Image = PlayertokenImages.Images[0];
                    Field[k, i].Visible = true;
                }

                RowbuttonArray[i].Visible = true;
            }
            
            gamerunning = true;
            if(playerturn == Token.CPU)
            {

                KI.GetKITurn(Spielfeld, 3, 3);
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void Playertokenlist_Load(object sender, EventArgs e)
        {

            PlayertokenImages.Images.Add(Properties.Resources.emptytoken);
            PlayertokenImages.Images.Add(Properties.Resources.Player1);
            PlayertokenImages.Images.Add(Properties.Resources.Player2);
        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {

        }

        private void Field01_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void ButtonClick(int RowNumber)
        {

            if (playerturn == Token.User || Spielfeld.numberofplayers == 2 && Spielfeld.turns<Spielfeld.length*Spielfeld.width)
            {

                if (playerturn == Token.User)
                {

                    
                    bool success = Spielfeld.AddToken(Token.User, RowNumber);
                    label1.Text = Spielfeld.GetHeuristik(Token.User).ToString();
                    if (success)
                    {
                        Field[Spielfeld.numberoftoken[RowNumber]-1, RowNumber].Image = PlayertokenImages.Images[1];
                        playerturn = Token.CPU;
                        if (Spielfeld.numberofplayers==1 && Spielfeld.turns<((Spielfeld.length - 1) *(Spielfeld.width - 1))-1)
                        {
                            int Kiturn= KI.GetKITurn(Spielfeld, RowNumber, 6);
                           
                            if(Spielfeld.AddToken(Token.CPU, Kiturn))
                            {
                                Field[Spielfeld.numberoftoken[Kiturn]-1, Kiturn].Image = PlayertokenImages.Images[2];
                            }
                            playerturn = Token.User;
                        }
                       
                    }
                }
                else
                {
                    Field[Spielfeld.numberoftoken[RowNumber], RowNumber].Image = PlayertokenImages.Images[2];
                    Spielfeld.AddToken(Token.CPU, RowNumber);
                    playerturn = Token.User;
                }
            }

            if (playerturn == Token.User)
            {

                label1.Text = Spielfeld.GetHeuristik(Token.CPU).ToString();
            }
            else
            {
                label1.Text = Spielfeld.GetHeuristik(Token.User).ToString();
            }

        }

        private void ButtonRow1_Click(object sender, EventArgs e)
        {
            ButtonClick(0);
        }

        private void ButtonRow1_Click_1(object sender, EventArgs e)
        {

            ButtonClick(1);
        }

        private void ButtonRow2_Click(object sender, EventArgs e)
        {
            ButtonClick(2);
        }

        private void ButtonRow3_Click(object sender, EventArgs e)
        {
            ButtonClick(3);
        }

        private void ButtonRow4_Click(object sender, EventArgs e)
        {
            ButtonClick(4);
        }

        private void ButtonRow5_Click(object sender, EventArgs e)
        {
            ButtonClick(5);
        }

        private void ButtonRow6_Click(object sender, EventArgs e)
        {
            ButtonClick(6);
        }

        private void ButtonRow7_Click(object sender, EventArgs e)
        {
            ButtonClick(7);
        }

        private void ButtonRow8_Click(object sender, EventArgs e)
        {
            ButtonClick(8);
        }

        private void ButtonRow9_Click(object sender, EventArgs e)
        {

            ButtonClick(9);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Coloumns_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
