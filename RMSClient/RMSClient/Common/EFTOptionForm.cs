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

namespace RMS.Common
{
    public partial class EFTOptionForm : Form
    {
        private EFTCardManager eftCardManager;
        public static EFTCard seletedEFTCard=new EFTCard();
        public EFTOptionForm()
        {
            InitializeComponent();
            eftCardManager = new EFTCardManager();

            List<EFTCard> cards = eftCardManager.GetEftCards();

            foreach (EFTCard card in cards)
            {
                EFTCardButton cardButton = new EFTCardButton();
                cardButton.CardID = card.Id;
                cardButton.Text = card.CardName;
                cardButton.DialogResult = DialogResult.OK;
                cardButton.Click += new EventHandler(eftCardButton_Click);
                flowLayoutPanel1.Controls.Add(cardButton);
            }


        }

        private void eftCardButton_Click(object sender, EventArgs e)
        {
          
            seletedEFTCard.CardName = ((EFTCardButton)sender).Text;
            seletedEFTCard.Id = ((EFTCardButton)sender).CardID;
        }

        
    }
}
