using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Managers.GManager;
using RMS.Common.ObjectModel;

namespace RMS.SystemManagement
{
    public partial class EFTManagerForm : Form
    {
        private EFTCardManager eftCardmanager;

        private EFTCard selectedEftCard;
        
        public EFTManagerForm()
        {
            InitializeComponent();
            eftCardmanager = new EFTCardManager();
            lodaData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EFTCard eftCard=new EFTCard();
            eftCard.CardName=txtBoxItem.Text;

            List<EFTCard> eftcards = eftCardmanager.GetEftCards();

            var existingEftCard = from card in eftcards
                                  where card.CardName == eftCard.CardName
                                  select card;

            if (existingEftCard.ToList().Count > 0)
            {
                MessageBox.Show("Item name already exists. Please try with another.");
            }
            else if (button1.Text=="Add")
            {
                eftCardmanager.InsertEftCard(eftCard);
                lodaData();
                txtBoxItem.Clear();
            }
            else if (button1.Text == "Update")
            {
                eftCard.Id = selectedEftCard.Id;
                eftCardmanager.UpdateEftCard(eftCard);
                lodaData();
                txtBoxItem.Clear();
            }

            button1.Text = "Add";
            btnEdit.Text = "Edit";
          
        }

        private void lodaData()
        {
            List<EFTCard> eftcards = eftCardmanager.GetEftCards();
            listBox1.DataSource = eftcards;
            listBox1.DisplayMember = "CardName";
        }

        private enum ActionType
        { 
            EDIT,
            DELETE,
            INSERT,
            UPDATE
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEftCard = (EFTCard)listBox1.SelectedItem;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr=  MessageBox.Show("Are you sure to delete the item '" + selectedEftCard.CardName + "'?", "Deleting Items", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                eftCardmanager.DeteleEftcard(selectedEftCard);
                lodaData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtBoxItem.Text = ((EFTCard)listBox1.SelectedItem).CardName;
            txtBoxItem.Select();
           

            if (btnEdit.Text == "Add New")
            {
                button1.Text = "Add";
                btnEdit.Text = "Edit";
                txtBoxItem.Clear();
            }
            else 
            {
                button1.Text = "Update";
                btnEdit.Text = "Add New";
            }
        }
    }
}
