using GameLib;
using GameLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTT_WinForms
{
    public partial class Form1 : Form
    {
        Game ActGame = new Game();
        public Form1()
        {
            InitializeComponent();
        }

        private void GameBtnClick_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var name = btn.Name;
            // get coordinate string from button name
            var cords= name.Remove(0, 3);

            // TODO do someting with the cords
            ActGame.Gameboard['a'][0] = GameStoneState.PlayerOne;
            ActGame.Gameboard['a'][1] = GameStoneState.PlayerTwo;
            // reprint field
            ShowField();
        }

        private void ShowField()
        {             
                 SetOneField("A0", ActGame.Gameboard['a'][0]);
                 SetOneField("A1", ActGame.Gameboard['a'][1]);
                 SetOneField("A2", ActGame.Gameboard['a'][2]);

                 SetOneField("B0", ActGame.Gameboard['b'][0]);
                 SetOneField("B1", ActGame.Gameboard['b'][1]);
                 SetOneField("B2", ActGame.Gameboard['b'][2]);

                 SetOneField("C0", ActGame.Gameboard['c'][0]);
                 SetOneField("C1", ActGame.Gameboard['c'][1]);
                 SetOneField("C2", ActGame.Gameboard['c'][2]);
                    }

        private void SetOneField(string cords, GameStoneState value)
        {
            foreach(Control c in this.Controls)
            {
                if(c.Name.Contains(cords))
                {
                    if(c.Name=="lbl"+cords)
                    {
                        var lbl = (Label)c;
                        switch(value)
                        {
                            case GameStoneState.Free:
                                lbl.Text = "";
                                break;
                            case GameStoneState.PlayerOne:
                                lbl.Text = "X";
                                break;
                            case GameStoneState.PlayerTwo:
                                lbl.Text = "O";
                                break;
                        }
                    }
                    if (c.Name == "btn" + cords)
                    {
                        var btn = (Button)c;
                        switch (value)
                        {
                            case GameStoneState.Free:
                                btn.Visible=true;
                                break;
                            case GameStoneState.PlayerOne:                               
                            case GameStoneState.PlayerTwo:
                                btn.Visible = false;
                                break;
                        }
                    }    
                }
            }
        }
    }
}
