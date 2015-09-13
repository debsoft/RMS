using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RMS.Common;
using RMS.Common.ObjectModel;
using RMS.DataAccess;
using RMS.Reports;
using RMS.TableOrder;
using RMSClient.DataAccess;

namespace RMS.SystemManagement
{
    public partial class PartyReservationForm : Form
    {
        private Reservation PartyReservation=new Reservation();
       private PartyReservationDAO aPartyReservationDao = new PartyReservationDAO();
       private int reservationId = 0;
       private Decimal m_dDiscountAmount = 0;
       private string m_sDiscountType = "Fixed";
       private double m_chargeAmount = 0.0;
       private string m_chargeType = "Fixed";
       int printReportLogoType = 1;
        public PartyReservationForm()
        {
            InitializeComponent();
            AddValueIntoTimeCombobox();
        }

        private void AddValueIntoTimeCombobox()
        {
            toMinutecomboBox.Items.Clear();
            toTimeFormatcomboBox.Items.Clear();
            toHourcomboBox.Items.Clear();
            fromHourcomboBox.Items.Clear();
            fromMinutecomboBox.Items.Clear();
            fromTimeFormatcomboBox.Items.Clear();
            List<string> aList=new List<string>();
            List<string> aaList = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                string sr = String.Empty;
                 if (i < 10) sr += "0";
                sr += i.ToString();
                aList.Add(sr);
                aaList.Add(sr);
              

            }
            fromHourcomboBox.DataSource=(aList);
            toHourcomboBox.DataSource=(aaList);
            aList=new List<string>();
            aaList = new List<string>();
            for (int i = 0; i < 60; i++)
            {
                string sr = String.Empty;
                if (i < 10) sr += "0";
                sr += i.ToString();
                aList.Add(sr);
                aaList.Add(sr);
               

            }
            toMinutecomboBox.DataSource=aaList;
            fromMinutecomboBox.DataSource=aList;
            aList=new List<string>();
            aaList = new List<string>();
            aList.Add("AM");
            aList.Add("PM");
            aaList.Add("AM");
            aaList.Add("PM");
            toTimeFormatcomboBox.DataSource=aaList;
            fromTimeFormatcomboBox.DataSource = aList;
        } 

        private void otherguestinfobutton_Click(object sender, EventArgs e)
        {
            OtherGuestReservationForm aGuestReservationForm=new OtherGuestReservationForm(reservationId);
            aGuestReservationForm.ShowDialog();
            List<ReservationIteminformation> aIteminformations = new List<ReservationIteminformation>();
            aIteminformations = aPartyReservationDao.GetotherguestIteminformationByreservationId(reservationId);

            if(aIteminformations.Count!=0)
            {
                double amount = aIteminformations[0].TotalPrice;
                double unitprice = aIteminformations[0].UnitPrice;
                if(unitprice!=0)
                {
                    int person = (int)(amount/unitprice);
                    PartyReservation.NumberofOtherGuest = person;
                }
               
            }
            double sum = (from information in aIteminformations select information.TotalPrice).Sum();
            PartyReservation.OtherGuestAmount = sum;
            LoadTotalPayable();
            otherguestamountlabel.Text = sum.ToString("F02");
        
            
        }

        private void utilityinfobutton_Click(object sender, EventArgs e)
        {
            ReservationUtilityCostForm aReservationUtilityCostForm=new ReservationUtilityCostForm(reservationId);
            aReservationUtilityCostForm.ShowDialog();
            List<ReservationIteminformation> aIteminformations = new List<ReservationIteminformation>();
            aIteminformations = aPartyReservationDao.GetUtilityIteminformationByreservationId(reservationId);
            double sum = (from information in aIteminformations select information.TotalPrice).Sum();
            PartyReservation.UtilityCostAmount = sum;
            LoadTotalPayable();
            utilityamountlabel.Text = sum.ToString("F02");
         
            
        }

        private void reservationconfirmbutton_Click(object sender, EventArgs e)
        {
       
            LoadPartyReservation();
            try
            {
                PrintDocument(PartyReservation, "Confirm");
            }
            catch (Exception)
            {
            }

           
            string res = aPartyReservationDao.UpdatePartyReservation(PartyReservation);
            MessageBox.Show(res);
            if(res=="Reservation Update Sucessfully")
            {
                this.Close();
            }

        }

        private void LoadPartyReservation()
        {
            PartyReservation.BookingDate = new DateTime(bookingdateTimePicker.Value.Year,
                                                     bookingdateTimePicker.Value.Month,
                                                     bookingdateTimePicker.Value.Day, 0, 0, 0);
            PartyReservation.LoginPerson = bookingpersontextBox.Text;
            PartyReservation.BookingArea = bookingareatextBox.Text;
            PartyReservation.BookingType = bookingtypetextBox.Text;
            PartyReservation.PartyDate = new DateTime(partydatedateTimePicker.Value.Year,
                                                        partydatedateTimePicker.Value.Month,
                                                        partydatedateTimePicker.Value.Day, 0, 0, 0);
            PartyReservation.FromTime = fromHourcomboBox.Text + ":" + fromMinutecomboBox.Text + ":" +
                                        fromTimeFormatcomboBox.Text;
            PartyReservation.ToTime = toHourcomboBox.Text + ":" + toMinutecomboBox.Text + ":" + toTimeFormatcomboBox.Text;
            PartyReservation.NumberOfGuest = Convert.ToInt32(numberofguesttextBox.Text);
            PartyReservation.DepositeAmount = Convert.ToDouble(depositeamounttextBox.Text);
            PartyReservation.DueAmount = PartyReservation.TotalPayableAmount - PartyReservation.DepositeAmount;
            PartyReservation.SpecialInstruction = specialinstructiontextBox.Text;
            PartyReservation.ClientName = clientnametextBox.Text;
            PartyReservation.ClientEmail = clientemailtextBox.Text;
            PartyReservation.ClientPhone = clientphonetextBox.Text;
        }

        private void PrintDocument(Reservation partyReservation, string sr)
        {
            printReportLogoType = 1;
            //int printlenght = oItemList.Count + 30;
            PrintDocument doc = new TextDocument(PrintReport(),50);
            doc.PrintPage += this.Doc_PrintPage;

            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            dlgSettings.UseEXDialog = true;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                if (sr == "Confirm")
                {
                    for(int i=0;i<3;i++)
                    {
                        doc.Print();
                    }
                }
                else
                {
                    doc.Print();
                }
              
            }
        }


        private void PrintDocumentForPOS(Reservation partyReservation, string sr)
        {
            //int printlenght = oItemList.Count + 30;
            printReportLogoType = 2;
            PrintDocument doc = new TextDocument(PrintReportForPOS(), 50);
            doc.PrintPage += this.Doc_PrintPage;

            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            dlgSettings.UseEXDialog = true;

            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                if (sr == "Confirm")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        doc.Print();
                    }
                }
                else
                {
                    doc.Print();
                }

            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                
                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top + 3;

                if (printReportLogoType == 1)
                {
                 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 400, 0);

                }
                else if (printReportLogoType == 2)
                {
                 
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 50, 0);

                }
                else if (printReportLogoType == 3)
                {
                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\SKYSHEEP.png"), 50, 40);

                }


                doc.PageNumber += 1;

                while ((y + lineHeight) < e.MarginBounds.Bottom && doc.Offset <= doc.Text.GetUpperBound(0))
                {
                    e.Graphics.DrawString(doc.Text[doc.Offset], font, Brushes.Black, 0, y);
                    doc.Offset += 1;
                    y += lineHeight;
                }

                if (doc.Offset < doc.Text.GetUpperBound(0))
                {
                    e.HasMorePages = true;
                }
                else
                {
                    doc.Offset = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            }
        }

        private string PrintReport()
        {

            List<ReservationIteminformation> utilityIteminformations = new List<ReservationIteminformation>();
            utilityIteminformations = aPartyReservationDao.GetUtilityIteminformationByreservationId(reservationId);

            List<ReservationIteminformation> otherGuestIteminformations = new List<ReservationIteminformation>();
            otherGuestIteminformations = aPartyReservationDao.GetotherguestIteminformationByreservationId(reservationId);

            List<ReservationIteminformation> mainGuestIteminformations = new List<ReservationIteminformation>();
            mainGuestIteminformations = aPartyReservationDao.GetMainguestIteminformationByreservationId(reservationId);


            string strBody = "";
         StringPrintFormater  stringPrintFormater = new StringPrintFormater(172);

            string header = GetPrintDecorationText(PrintDecoration.HEADER);


            string[] lines = null;
            char[] param = { '\n' };
            if (header != null && header.Length > 0)
                lines = header.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };

            string TotalHader = "";
            if (lines != null && lines.Length > 0)
                foreach (string s in lines)
                {
                    TotalHader += stringPrintFormater.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }


            strBody += TotalHader;

            //   strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Party Reservation Form");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Booking Date: " + PartyReservation.BookingDate.ToShortDateString(), "Booking By: " + PartyReservation.LoginPerson);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Booking Area: " + PartyReservation.BookingArea, "Type Of Booking: " + PartyReservation.BookingType);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Party Date: " + PartyReservation.PartyDate.ToShortDateString(), "Nummber Of Guest: " + PartyReservation.NumberOfGuest.ToString());
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Time Of Entry: " +PartyReservation.FromTime+" To "+PartyReservation.ToTime, "Number Of Other Guest: " + PartyReservation.NumberofOtherGuest);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace(" Main Guest Particulars");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 80, false);
            //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            strBody += stringPrintFormater.GridCell("Unit Price", 40, false);
            strBody += stringPrintFormater.GridCell("Total Price", 40, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (ReservationIteminformation iteminformation in mainGuestIteminformations)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(iteminformation.ItemName, 80, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                strBody += stringPrintFormater.GridCell(iteminformation.UnitPrice.ToString("F02"), 40, false);
                strBody += stringPrintFormater.GridCell(iteminformation.TotalPrice.ToString("F02"), 40, false);
            }
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Other Guest Particulars");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 80, false);
            //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            strBody += stringPrintFormater.GridCell("Unit Price", 40, false);
            strBody += stringPrintFormater.GridCell("Total Price", 40, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (ReservationIteminformation iteminformation in otherGuestIteminformations)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(iteminformation.ItemName, 80, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                strBody += stringPrintFormater.GridCell(iteminformation.UnitPrice.ToString("F02"), 40, false);
                strBody += stringPrintFormater.GridCell(iteminformation.TotalPrice.ToString("F02"), 40, false);
            }

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Utility Cost  Particulars");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 80, false);
            //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            //strBody += stringPrintFormater.GridCell("Unit Price", 40, false);
            strBody += stringPrintFormater.GridCell("Total Price", 80, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (ReservationIteminformation iteminformation in utilityIteminformations)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(iteminformation.ItemName, 80, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                //strBody += stringPrintFormater.GridCell(iteminformation.UnitPrice.ToString("F02"), 40, false);
                strBody += stringPrintFormater.GridCell(iteminformation.TotalPrice.ToString("F02"), 80, false);
            }
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Main Guest Amount(Tk): " + PartyReservation.MainGuestAmount.ToString("F02"), "Total Payable Amount(Tk): " + PartyReservation.TotalPayableAmount.ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Other Guest Amount(Tk): " + PartyReservation.OtherGuestAmount.ToString("F02"), "Deposite Amount(Tk): " + PartyReservation.DepositeAmount.ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Utility Cost Amount(Tk): " + PartyReservation.UtilityCostAmount.ToString("F02"), "Due Amount(Tk): " + PartyReservation.DueAmount.ToString("F02"));
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Service Charge Amount(Tk): " + PartyReservation.ServiceCharge.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Vat Amount(Tk): " + PartyReservation.Vat.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Discount Amount(Tk): " + PartyReservation.Discount.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Special Instruction");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + PartyReservation.SpecialInstruction;
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Client Information");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Full Name: " + PartyReservation.ClientName, "Cell Number: " + PartyReservation.ClientPhone);
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Email Address: " + PartyReservation.ClientEmail, "");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");
            strBody += "\r\n\r\n\r\n" + "                     ------------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                     Signature Executive Chef" + "                                                             Signature Managemant  ";


            PartyReservation.PrintPreview = strBody;
            return strBody;
        }

        private string PrintReportForPOS()
        {

            List<ReservationIteminformation> utilityIteminformations = new List<ReservationIteminformation>();
            utilityIteminformations = aPartyReservationDao.GetUtilityIteminformationByreservationId(reservationId);

            List<ReservationIteminformation> otherGuestIteminformations = new List<ReservationIteminformation>();
            otherGuestIteminformations = aPartyReservationDao.GetotherguestIteminformationByreservationId(reservationId);

            List<ReservationIteminformation> mainGuestIteminformations = new List<ReservationIteminformation>();
            mainGuestIteminformations = aPartyReservationDao.GetMainguestIteminformationByreservationId(reservationId);


            string strBody = "";
            StringPrintFormater stringPrintFormater = new StringPrintFormater(40);

            string header = GetPrintDecorationText(PrintDecoration.HEADER);


            string[] lines = null;
            char[] param = { '\n' };
            if (header != null && header.Length > 0)
                lines = header.Split(param);
            int i = 0;
            char[] trimParam = { '\r' };

            string TotalHader = "";
            if (lines != null && lines.Length > 0)
                foreach (string s in lines)
                {
                    TotalHader += stringPrintFormater.CenterTextWithWhiteSpace(s.TrimEnd(trimParam)) + "\r\n";
                }


            strBody += TotalHader;

            //   strBody += "\r\n";
            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Party Reservation Form");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Booking Date: " + PartyReservation.BookingDate.ToShortDateString(),"");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Booking By: " + PartyReservation.LoginPerson, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Booking Area: " + PartyReservation.BookingArea, ""); 
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Type Of Booking: " + PartyReservation.BookingType,"");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Party Date: " + PartyReservation.PartyDate.ToShortDateString(), ""); 
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Nummber Of Guest: " + PartyReservation.NumberOfGuest,"");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Time Of Entry: " + PartyReservation.FromTime + " To " + PartyReservation.ToTime, ""); 
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Number Of Other Guest: " + PartyReservation.NumberofOtherGuest,"");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace(" Main Guest Particulars");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 18, false);
            //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            strBody += stringPrintFormater.GridCell("Unit Price", 12, false);
            strBody += stringPrintFormater.GridCell("Total Price",10, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (ReservationIteminformation iteminformation in mainGuestIteminformations)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(iteminformation.ItemName,18, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                strBody += stringPrintFormater.GridCell(iteminformation.UnitPrice.ToString("F02"),12, false);
                strBody += stringPrintFormater.GridCell(iteminformation.TotalPrice.ToString("F02"), 10, false);
            }
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Other Guest Particulars");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 18, false);
            //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            strBody += stringPrintFormater.GridCell("Unit Price", 12, false);
            strBody += stringPrintFormater.GridCell("Total Price", 10, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (ReservationIteminformation iteminformation in otherGuestIteminformations)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(iteminformation.ItemName, 18, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                strBody += stringPrintFormater.GridCell(iteminformation.UnitPrice.ToString("F02"), 12, false);
                strBody += stringPrintFormater.GridCell(iteminformation.TotalPrice.ToString("F02"), 10, false);
            }

            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Utility Cost  Particulars");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 26, false);
            //  strBody += stringPrintFormater.GridCell("SN", 14, false);
            //strBody += stringPrintFormater.GridCell("Unit Price", 40, false);
            strBody += stringPrintFormater.GridCell("Total Price", 10, false);
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            foreach (ReservationIteminformation iteminformation in utilityIteminformations)
            {
                strBody += "\r\n" + stringPrintFormater.GridCell(iteminformation.ItemName, 26, false);
                //  strBody += stringPrintFormater.GridCell(item.SerialNumber.ToString(), 14, false);
                //strBody += stringPrintFormater.GridCell(iteminformation.UnitPrice.ToString("F02"), 40, false);
                strBody += stringPrintFormater.GridCell(iteminformation.TotalPrice.ToString("F02"), 10, false);
            }
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n" +stringPrintFormater.ItemLabeledText( "Main Guest Amount(Tk): " + PartyReservation.MainGuestAmount.ToString("F02"), ""); 
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Payable Amount(Tk): " + PartyReservation.TotalPayableAmount.ToString("F02"),"");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Other Guest Amount(Tk): " + PartyReservation.OtherGuestAmount.ToString("F02"), ""); 
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Deposite Amount(Tk): " + PartyReservation.DepositeAmount.ToString("F02"),"");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Utility Cost Amount(Tk): " + PartyReservation.UtilityCostAmount.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Due Amount(Tk): " + PartyReservation.DueAmount.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Service Charge Amount(Tk): " + PartyReservation.ServiceCharge.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Vat Amount(Tk): " + PartyReservation.Vat.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Discount Amount(Tk): " + PartyReservation.Discount.ToString("F02"), "");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Special Instruction");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + PartyReservation.SpecialInstruction;
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Client Information");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Full Name: " + PartyReservation.ClientName, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Cell Number: " + PartyReservation.ClientPhone, "");
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Email Address: " + PartyReservation.ClientEmail, "");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");
            strBody += "\r\n\r\n\r\n" + "--------------------" + "   ---------------------      ";
            strBody += "\r\n" + "Executive Chef" + "              Managemant  ";


            PartyReservation.PrintPreview = strBody;
            return strBody;
        }


        public string GetPrintDecorationText(PrintDecoration printDecoration)
        {
            string firstString = "[---]";

            string fieldName = printDecoration == PrintDecoration.HEADER ? "header" : "footer";
            try
            {

                string HeaderContent = HeaderFooterDataset().Tables["PrintStyle"].Select("style_name = 'normal'")[0][fieldName].ToString();
                StringTokenizer tempStringTokenizer = new StringTokenizer(HeaderContent, "\r\n");
                firstString = tempStringTokenizer.NextToken();

                while (tempStringTokenizer.HasMoreTokens())
                {
                    firstString += "\r\n" + tempStringTokenizer.NextToken();

                }
            }
            catch (Exception esx)
            {


            }

            return firstString;
        }

        private DataSet HeaderFooterDataset()
        {
            DataSet tempDataSet = new DataSet();

            CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
            string tempConnectionString = oConstants.DBConnection;
            string sSql = SqlQueries.GetQuery(Query.GetPrintStyles);
            SqlDataAdapter tempSqlAdapter = new SqlDataAdapter(sSql, tempConnectionString);
            tempSqlAdapter.Fill(tempDataSet, "PrintStyle");

            return tempDataSet;
        }

        private void checkavabilitybutton_Click(object sender, EventArgs e)
        {
            
            PartyReservation.BookingDate = new DateTime(bookingdateTimePicker.Value.Year,
                                                        bookingdateTimePicker.Value.Month,
                                                        bookingdateTimePicker.Value.Day, 0, 0, 0);
            PartyReservation.LoginPerson = bookingpersontextBox.Text;
            PartyReservation.BookingArea = bookingareatextBox.Text;
            PartyReservation.BookingType = bookingtypetextBox.Text;
            PartyReservation.PartyDate = new DateTime(partydatedateTimePicker.Value.Year,
                                                        partydatedateTimePicker.Value.Month,
                                                        partydatedateTimePicker.Value.Day, 0, 0, 0);
            PartyReservation.FromTime = fromHourcomboBox.Text + ":" + fromMinutecomboBox.Text + ":" +
                                        fromTimeFormatcomboBox.Text;
            PartyReservation.ToTime = toHourcomboBox.Text + ":" + toMinutecomboBox.Text + ":" + toTimeFormatcomboBox.Text;
             reservationId = aPartyReservationDao.CheckAvabilityAndInsert(PartyReservation);
            if(reservationId!=0)
            {
                MessageBox.Show("You are welcome.");
            }
            else
            {
                MessageBox.Show("Sorry Please try another time.");
            }
            PartyReservation.ReservationId = reservationId;
        }

        private void additembutton_Click(object sender, EventArgs e)
        {
            if(reservationId==0)
            {
                MessageBox.Show("Please check available date");
            }
            else
            {
                if(itemnametextBox.Text.Length==0 || itemunitpricetextBox.Text.Length==0 || numberofguesttextBox.Text.Length==0)
                {
                    MessageBox.Show("Please check input field");
                }
                else
                {
                   ReservationIteminformation aIteminformation=new ReservationIteminformation();
                    aIteminformation.ItemName = itemnametextBox.Text;
                    aIteminformation.UnitPrice = Convert.ToDouble(itemunitpricetextBox.Text);
                    double guest = Convert.ToDouble(numberofguesttextBox.Text);
                    aIteminformation.TotalPrice = guest*aIteminformation.UnitPrice;
                    string sr = aPartyReservationDao.InsertMainGuestItemInformation(aIteminformation,reservationId);
                    MessageBox.Show(sr);
                    if(sr=="ItemInsertSucessfully")
                    {
                        itemnametextBox.Text = "";
                        itemunitpricetextBox.Text = "";
                    }
                    LoadItemInformation();
                }
            }
        }

        private void LoadItemInformation()
        {
            List<ReservationIteminformation> aIteminformations = new List<ReservationIteminformation>();
            aIteminformations = aPartyReservationDao.GetMainguestIteminformationByreservationId(reservationId);
            mainguestdataGridView.DataSource = aIteminformations;
            double sum = (from information in aIteminformations select information.TotalPrice).Sum();
            PartyReservation.MainGuestAmount = sum;
            mainguestamountlabel.Text = sum.ToString("F02");
            LoadTotalPayable();
          
        }

        private void mainguestdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You sure want to delete it?", "Attention", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int itemid = Convert.ToInt32(mainguestdataGridView.Rows[e.RowIndex].Cells[0].Value);
                        string res = aPartyReservationDao.DeleteItemInfromationFormainGuest(itemid);
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

        private void printPreviewbutton_Click(object sender, EventArgs e)
        {
            LoadPartyReservation();
            PrintDocument(PartyReservation,"test");
        }

        private void servicechargebutton_Click(object sender, EventArgs e)
        {
            Double MainFoodTotal = PartyReservation.MainGuestAmount+PartyReservation.OtherGuestAmount+PartyReservation.UtilityCostAmount;    
            ChargeAmountForm tempChargeForm = new ChargeAmountForm();
            tempChargeForm.ShowDialog(); 

            if (ChargeAmountForm.m_serviceChargeType.Equals("Cancel"))
                return;

            m_chargeAmount = ChargeAmountForm.m_serviceChargeAmount;
            m_chargeType = ChargeAmountForm.m_serviceChargeType;

            Double chargeAmount = 0.000;
            Double servicechargeRate = 0.000;
            if (m_chargeType.Equals("Fixed"))
            {
                chargeAmount = m_chargeAmount;
                  if (MainFoodTotal != 0)
                {
                servicechargeRate = m_chargeAmount * 100 / MainFoodTotal;
                 }

            }
            else if (m_chargeType.Equals("Percent"))
            {
               
                chargeAmount = MainFoodTotal * m_chargeAmount / 100;

                servicechargeRate = m_chargeAmount;
            }
      
            ServiceCharge tempOrderCharge = new ServiceCharge();
            tempOrderCharge= aPartyReservationDao.OrderServiceChargeGetByOrderID(reservationId);
            if (tempOrderCharge.OrderID==reservationId)
            {
                

                //update
                tempOrderCharge.OrderID = reservationId;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                tempOrderCharge.ServicechargeRate = servicechargeRate;
                aPartyReservationDao.UpdateOrderServiceCharge(tempOrderCharge);
            }

            else
            {
                //insert
                tempOrderCharge.OrderID = reservationId;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(chargeAmount);
                tempOrderCharge.ServicechargeRate = servicechargeRate;
                aPartyReservationDao.InsertOrderServiceCharge(tempOrderCharge);
            }
            PartyReservation.ServiceCharge = chargeAmount;
            servicechargelabel.Text = chargeAmount.ToString("F02");
            LoadTotalPayable();




        }

        private void LoadTotalPayable()
        {
            PartyReservation.TotalPayableAmount = PartyReservation.MainGuestAmount + PartyReservation.OtherGuestAmount +
                                                  PartyReservation.UtilityCostAmount + PartyReservation.Vat
                                                  + PartyReservation.ServiceCharge - PartyReservation.Discount;
            totalpayableamountlabel.Text = PartyReservation.TotalPayableAmount.ToString("F02");
        }

        private void discountbutton_Click(object sender, EventArgs e)
        {
            double discountRate = 0.0;
            Double MainFoodTotal = PartyReservation.MainGuestAmount + PartyReservation.OtherGuestAmount + PartyReservation.UtilityCostAmount; 
            CDiscountForm tempDiscountForm = new CDiscountForm();
            tempDiscountForm.ShowDialog();

            if (CDiscountForm.discountType.Equals("Cancel"))
                return;

            m_dDiscountAmount = Convert.ToDecimal(CDiscountForm.discountAmount);
            m_sDiscountType = CDiscountForm.discountType;

           double  discountAmount = 0;
            if (m_sDiscountType.Equals("Fixed"))
            {
                discountAmount = (double)m_dDiscountAmount;
                if (MainFoodTotal != 0)
                {
                    discountRate = m_chargeAmount*100/MainFoodTotal;
                } 

            }
            else if (m_sDiscountType.Equals("Percent"))
            {
                discountAmount =MainFoodTotal*(double) m_dDiscountAmount / 100;

                discountRate =(double)m_dDiscountAmount;

            }

            ServiceCharge tempOrderCharge = new ServiceCharge();
            tempOrderCharge = aPartyReservationDao.OrderDiscountGetByOrderID(reservationId);
            if (tempOrderCharge.OrderID == reservationId)
            {


                //update
                tempOrderCharge.OrderID = reservationId;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(discountAmount);
                tempOrderCharge.ServicechargeRate = discountRate;
                aPartyReservationDao.UpdateOrderDiscount(tempOrderCharge);
            }

            else
            {
                //insert
                tempOrderCharge.OrderID = reservationId;
                tempOrderCharge.ServiceChargeAmount = Convert.ToDouble(discountAmount);
                tempOrderCharge.ServicechargeRate = discountRate;
                aPartyReservationDao.InsertOrderDiscount(tempOrderCharge);
            }
            PartyReservation.Discount = discountAmount;
            discountlabel.Text = discountAmount.ToString("F02");
            LoadTotalPayable();
        }

        private void vatbutton_Click(object sender, EventArgs e)
        {

            Double MainFoodTotal = PartyReservation.MainGuestAmount + PartyReservation.OtherGuestAmount + PartyReservation.UtilityCostAmount; 
            CPriceCalculatorForm tempCalculatorForm1 = new CPriceCalculatorForm("Reservation", "Enter vat");
            tempCalculatorForm1.ShowDialog();

            if (CPriceCalculatorForm.inputResult.Equals("Cancel"))
                return;

            if (CPriceCalculatorForm.inputResult.Equals("0.000"))
            {
                CMessageBox tempMessageBox = new CMessageBox("Error!", "Vat cannot be zero.");
                tempMessageBox.ShowDialog();
                return;
            }

            double reservationvatpercent = Double.Parse(CPriceCalculatorForm.inputResult);
            double vat = 0;
            vat = (reservationvatpercent*MainFoodTotal)/100;
            PartyReservation.Vat= vat;
            vatlabel.Text = vat.ToString("F02");
            LoadTotalPayable();

       
        }

        private void posPrintButton_Click(object sender, EventArgs e)
        {
            LoadPartyReservation();
            PrintDocumentForPOS(PartyReservation, "test");
        }

     
    }
}
