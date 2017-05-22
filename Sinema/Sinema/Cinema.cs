using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema
{
    class Cinema
    {
        Form2 myForm = new Form2();
        public string name { get; set; }
        public static List<Cinema> cinema_List = new List<Cinema>();
        public bool check { get; set; }
        public bool confirm_Check { get; set; }
        public bool buttons_Check { get; set; }
        private List<int> placesArr = new List<int>();
        public List<int> placesArrSecond = new List<int>();
        public Button[] myButton { get; set; }
        public Label myLabel { get; set; }
        public Label not_1 { get; set; }
        public Label not_2 { get; set; }
        public Label not_3 { get; set; }
        public Button Confirm { get; set; }
        public Button Choose { get; set; }
        public int count { get; set; }
        public string s { get; set; }
        CreateElement create = new CreateElement();
        public Cinema(string name)
        {
            this.name = name;
            cinema_List.Add(this);
            count = 0;
            check = false;
            confirm_Check = false;
            buttons_Check = false;
        }
        public void Places(int count, int rowCount)
        {
            myButton = create.CreateButtons(20, 80, 40, count, rowCount, myForm);
            myLabel = create.createLabel(this.name+" filmi üçün yerlər",myButton[0].Left,myButton[0].Top-40,300, myForm);
            int right = myButton[0].Left + (count / rowCount-1) * 80 + (count / rowCount-1) * 20;
            Confirm = create.CreateButton(80, 50, right, myButton[myButton.Length - 1].Top + 50, "Təsdiqlə", myForm);
            Confirm.Click += Confirm_Click;
            Choose = create.CreateButton(80, 50, myButton[0].Left, myButton[myButton.Length - 1].Top + 50, "Yer seçin", myForm);
            Choose.Click += Choose_Click;
            not_1 = create.createLabel(null, Choose.Left, Choose.Top + 60, 500, myForm);
            not_2 = create.createLabel(null, not_1.Left, not_1.Top + 30, 300, myForm);
            not_3 = create.createLabel(null, not_1.Left, not_2.Top + 30, 300, myForm);

            for (int i = 0; i < count; i++)
            {
                myButton[i].Click += CinemaButtons_Click;
            }
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            Button myButton = sender as Button;
            myButton.BackColor = System.Drawing.Color.Silver;
            check = true;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            Button myButton = sender as Button; bool second_Time = false; List<int> places_ = new List<int>();
            not_3.Text = null; 
            Choose.BackColor = System.Drawing.Color.Transparent;
            if (count != 0 && check==true)
            {
                
                for (int i = 0; i < placesArr.Count; i++)
                {
                    if (placesArrSecond.Contains(placesArr[i]))
                    {
                        places_.Add(placesArr[i]);
                    }
                }

                places_.Sort();

                for (int i = 0; i < places_.Count; i++)
                {
                    if (i < places_.Count - 1)
                    {
                        not_3.Text += places_[i]+"-ci, ";
                    }

                    else
                    {
                            not_3.Text += places_[i] + "-ci yerlər artıq tutulub!";
                    }
                }
            }

            if (count > 0 && confirm_Check == true && check==true)
            {
                not_2.Text = "Siz artıq seçim etmisiniz. Yenidən seçim edə bilməzsiniz!";
               
                for (int i = 0; i < placesArr.Count; i++)
                {
                    if (!placesArrSecond.Contains(placesArr[i]))
                    {
                        this.myButton[placesArr[i] - 1].BackColor = System.Drawing.Color.Transparent;
                    }
                }
                second_Time = true;
            }

            if (count >= 0)
            {
                if (check == true && buttons_Check == true && confirm_Check==false)
                {

                    for (int i = 0; i < placesArr.Count; i++)
                    {
                        placesArrSecond.Add(placesArr[i]);

                    }
                    placesArrSecond.Sort();

                    for (int i = 0; i < placesArrSecond.Count; i++)
                    {
                        if (i < placesArrSecond.Count - 1)
                        {
                            s += placesArrSecond[i].ToString() + "-ci, ";
                        }
                       
                        else
                        {
                            s += placesArrSecond[i].ToString() + "-ci";
                        }
                        myButton.BackColor = System.Drawing.Color.Red;
                    }

                    s += " yerlər tutulub. Ödəniləcək məbləğ " + placesArrSecond.Count * 7.5 + " AZN-dir";
                    not_1.Text = s;
                    confirm_Check = true;
                }

                else if(second_Time != true || buttons_Check==false)
                {
                    
                    MessageBox.Show("Yer seçin!");
                }
            }

            placesArr.Clear();
            places_.Clear();
            check = false;
            buttons_Check = false;
            second_Time = false;
            count++;
            
        }

        private void CinemaButtons_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            buttons_Check = true;
            if (check == true)
            {
                button.BackColor = System.Drawing.Color.Red;
                placesArr.Add(int.Parse(button.Text));
                
            }
            else
            {
                MessageBox.Show("Yer seçməmişdən əvvəl 'Yer seçin' düyməsinə basın!");
            }

        }
    }
}
