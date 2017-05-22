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


    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        public static string s = null; 
        Cinema old_Boy = new Cinema("Old boy");
        Cinema fury = new Cinema("Fury");
        Cinema What_Happens_in_Vegas = new Cinema("What Happens in Vegas");
        CreateElement create = new CreateElement();
        ComboBox myCombo;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            myCombo = create.createCombo(200, 20, "Film seçin:",this);
            Label myLabel = create.createLabel("İzləmək istədiyiniz film?", myCombo.Left, myCombo.Top-30,150,this);
            Button myButton = create.CreateButton(100, 40, myCombo.Left, myCombo.Top + 30, "Yer seçin",this);
            Controls.Add(myLabel);
            Controls.Add(myCombo);
            Controls.Add(myButton);
            myButton.Click += MyButton_Click;
        }


        private void MyButton_Click(object sender, EventArgs e)
        {
            bool check = false;
            
            s = myCombo.Text;
            try
            {
                for (int i = 0; i < Cinema.cinema_List.Count; i++)
                {
                    if (Cinema.cinema_List[i].name == s)
                    {
                        check = true;
                    }
                }
                if (check == true)
                {
                    Form2 myForm = new Form2();
                    myForm.ShowDialog();
                }
                else
                {
                    throw new Exception("Filmi düzgün seçin!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

            }

        }

       
    }

    
}
