using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema
{
    class CreateElement
    {
        public ComboBox createCombo(int width, int height,string text,Form f)
        {
            ComboBox combo = new ComboBox();
            combo.Text = text;
            combo.Width = width;
            combo.Height = height;
            combo.Left = (f.ClientSize.Width - width) / 2;
            combo.Top = (f.ClientSize.Height - height) / 2;
            for (int i = 0; i < Cinema.cinema_List.Count; i++)
            {
                combo.Items.Add(Cinema.cinema_List[i].name);
            }
                return combo;
        }

        public ComboBox createCombo(int width, int height, string text, int left, int top, Form f)
        {
            ComboBox combo = new ComboBox();
            combo.Text = text;
            combo.Width = width;
            combo.Height = height;
            combo.Left = left;
            combo.Top = top;
            for (int i = 0; i < Cinema.cinema_List.Count; i++)
            {
                combo.Items.Add(Cinema.cinema_List[i].name);
            }
            return combo;
        }

        public Label createLabel(string text, int left, int top, int width, Form f)
        {
            Label myLabel = new Label();
            myLabel.Text = text;
            myLabel.Width = width;
            myLabel.Left = left;
            myLabel.Top = top;
            
            return myLabel;

        }

        public Label createLabel(string text, int width, Form f)
        {
            Label myLabel = new Label();
            myLabel.Text = text;
            myLabel.Width = width;
            myLabel.Left = (f.ClientSize.Width - myLabel.Width) / 2; ;
            myLabel.Top = (f.ClientSize.Height - myLabel.Height) / 2; ;

            return myLabel;

        }

        public Button CreateButton(int width, int height,string text, Form f)
        {

            Button button = new Button();
            button.Text = text;
            button.Width = width;
            button.Height = height;
            button.Left = (f.ClientSize.Width - width) / 2;
            button.Top = (f.ClientSize.Height - height) / 2;
            return button;
        }

        

        public Button CreateButton( int width,int height, int left, int top, string text, Form f)
        {
            Button button = new Button();
            button.Text = text;
            button.Width = width;
            button.Height = height;
            button.Left = left;
            button.Top = top;
            return button;
        }

        public Button[] CreateButtons(int space, int width, int height, int left, int top, int count, int rowCount,Form f)
        {
            Button[] myButton = new Button[count]; int a = left;
            for (int i = 0; i < count; i++)
            {
                myButton[i] = new Button();
                myButton[i].Text = (i + 1).ToString();
                myButton[i].Left = left;
                myButton[i].Top = top;
                myButton[i].Width = width;
                myButton[i].Height = height;
                left += space+width;
                if (i % rowCount == rowCount - 1)
                {
                    left = a;
                    top += space+height;
                }
            }

            return myButton;
        }

        public Button[] CreateButtons(int space, int width, int height, int count, int rowCount, Form f)
        {
            Button[] myButton = new Button[count];
            int left = 0, top = 0; int a = count / rowCount;
            for (int i = 0; i < count; i++)
            {
                myButton[i] = new Button();
                myButton[i].Text = (i + 1).ToString();
                myButton[i].Left = left + f.ClientSize.Width / 2 - a*width/2-(a/2-1)*space-space/2; 
                myButton[i].Top = top + f.ClientSize.Height / 2 - rowCount*height/2-(rowCount/2-1)*space-space/2;
                myButton[i].Width = width;
                myButton[i].Height = height;
                left += width+space;
                if (i % a == a - 1)
                {
                    left = 0;
                    top += height+space;
                }
            }

            return myButton;
        }
    }

    }
