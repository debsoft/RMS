using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMSUI;
using RMSUI.Interfaces;

namespace RMSUITest
{
    public partial class Form1 : Form
    {
       Int64 i=1;
        
        public Form1()
        {
            InitializeComponent();
            lobbyItemButton1.ItemType = RMSUIConstants.ItemType.Ordered;
            lobbyItemButton1.TableNumber = 15;
            lobbyItemButton1.User = "mehe sdf dfg";
            lobbyItemButton1.TableName = "sdsd";
            lobbyItemButton1.GuestCount = "5";
    
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm LoginForm = new LoginForm();
            LoginForm.ScreenTitle = "Login Form";
            LoginForm.Show();
           

           
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            Pop pop = new Pop();
            
        
          //  pop.setTitle = "my pop fdgdfgfd";
          
             dr= pop.ShowDialog();
            if (dr == DialogResult.OK)
                MessageBox.Show("User clicked OK button");
            else if (dr == DialogResult.Cancel)
                MessageBox.Show("User clicked Cancel button");


        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult dr = new DialogResult();
            Form2 form2 = new Form2();


            form2.SetTitle = "my pop fdgdfgfd";


            form2.ActionMethod = new action();
            
            dr = form2.ShowDialog();



            MessageBox.Show(dr.ToString());

            if (dr == DialogResult.Abort)
                MessageBox.Show("User clicked abort button----");
            else if (dr == DialogResult.Cancel)
                MessageBox.Show("User clicked Cancel button-----");
        }


        private class action : DialogueFormInterface
        {
            #region DialogueFormInterface Members

            public DialogResult OnEnterPress()
            {
                return DialogResult.Ignore;
            }

            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lobbyItemButton1.TableNumber = i++;
            lobbyItemButton2.TableNumber = i++;
        }

        private void numericKeyPad1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            keyButton1.AlterState();
        }


        private void del_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string stRemove = textBox2.Text.ToString();
                
                string aa = stRemove.Remove(stRemove.Length - 1, 1);

                textBox2.Text = aa;

                
            }

            else
            {
                textBox2.Text = "";
            }

            
            
        }

        

       



      

        
    }
}
