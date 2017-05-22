using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Cinema cinema=null;
            for (int i = 0; i < Cinema.cinema_List.Count; i++)
            {
                if (Cinema.cinema_List[i].name == Form1.s)
                {
                    cinema = Cinema.cinema_List[i];
                    cinema.Places(24, 4);
                    for (int j = 0; j < 24; j++)
                    {
                        this.Controls.Add(cinema.myButton[j]);
                    }
                    this.Controls.Add(cinema.myLabel);
                    this.Controls.Add(cinema.Confirm);
                    this.Controls.Add(cinema.Choose);
                    this.Controls.Add(cinema.not_1);
                    this.Controls.Add(cinema.not_2);
                    this.Controls.Add(cinema.not_3);
                    cinema.not_1.Text = cinema.s;
                    if (cinema.placesArrSecond.Count != 0)
                    {
                        for (int j = 0; j < cinema.placesArrSecond.Count; j++)
                        {
                            cinema.myButton[cinema.placesArrSecond[j]-1].BackColor = Color.Red;
                        }
                    }
                    
                }
            }
            
            cinema.check = false;
        }
    }
}
