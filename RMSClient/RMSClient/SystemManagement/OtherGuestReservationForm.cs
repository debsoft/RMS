using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common.ObjectModel;
using RMSClient.DataAccess;

namespace RMS.SystemManagement
{
    public partial class OtherGuestReservationForm : Form
    {
        private PartyReservationDAO aPartyReservationDao = new PartyReservationDAO();
        private int reservationId = 0;
        public OtherGuestReservationForm(int id)
        {
            InitializeComponent();
            reservationId = id;
            LoadItemInformation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void additembutton_Click(object sender, EventArgs e)
        {
            if (reservationId == 0)
            {
                MessageBox.Show("Please check available date");
            }
            else
            {
                if (itemnametextBox.Text.Length == 0 || itemunitpricetextBox.Text.Length == 0 || guestnumbertextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please check input field");
                }
                else
                {
                    ReservationIteminformation aIteminformation = new ReservationIteminformation();
                    aIteminformation.ItemName = itemnametextBox.Text;
                    aIteminformation.UnitPrice = Convert.ToDouble(itemunitpricetextBox.Text);
                    double guest = Convert.ToDouble(guestnumbertextBox.Text);
                    aIteminformation.TotalPrice = guest * aIteminformation.UnitPrice;
                    string sr = aPartyReservationDao.InsertotherGuestItemInformation(aIteminformation, reservationId);
                    MessageBox.Show(sr);
                    if (sr == "ItemInsertSucessfully")
                    {
                        itemnametextBox.Text = "";
                        itemunitpricetextBox.Text = "";
                    }
                   LoadItemInformation();
                }
            }
        }

        private void otherguestdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You sure want to delete it?", "Attention", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int itemid = Convert.ToInt32(otherguestdataGridView.Rows[e.RowIndex].Cells[0].Value);
                        string res = aPartyReservationDao.DeleteItemInfromationForotherGuest(itemid);
                        LoadItemInformation();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadItemInformation()
        {
            List<ReservationIteminformation> aIteminformations = new List<ReservationIteminformation>();
            aIteminformations = aPartyReservationDao.GetotherguestIteminformationByreservationId(reservationId);
            otherguestdataGridView.DataSource = aIteminformations;
            double sum = (from information in aIteminformations select information.TotalPrice).Sum();
            totalamountlabel.Text = sum.ToString("F02");
        }
    }
}
