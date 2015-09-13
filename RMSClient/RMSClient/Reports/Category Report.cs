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
using RMSClient.DataAccess;

namespace RMS.Reports
{
    public partial class Category_Report : Form
    {
        private int printReportLogoType = 0;
        public Category_Report()
        {
            InitializeComponent();
            LoadParentCategory();
            LoadSubCategory();
            LoadItemMenu();
        }

        private void LoadSubCategory()
        {
            List<CCategory2> tempCategory2List = new List<CCategory2>();
            CCategory2DAO aCategory2Dao=new CCategory2DAO();
            tempCategory2List = aCategory2Dao.GetAllCategory2();

            CCategory2 aCategory2=new CCategory2();
            aCategory2.Category2ID = 0;
            aCategory2.Category2Name = "AddMisc";
            tempCategory2List.Add(aCategory2);
            cmbsubcategory.DataSource = tempCategory2List;
            cmbsubcategory.DisplayMember = "Category2Name";
            cmbsubcategory.ValueMember = "Category2ID";
        }

        private void LoadParentCategory()
        {
            List<CParentCategory> tempParentCategoryList = new List<CParentCategory>();
            CParentCategoryDAO aCParentCategoryDao=new CParentCategoryDAO();
            tempParentCategoryList = aCParentCategoryDao.GetAllParentCategory();
            CParentCategory aCategory=new CParentCategory();
            aCategory.ParentCategoryName = "ALL";
            aCategory.ParentCategoryID = 0;
            tempParentCategoryList.Add(aCategory);

            cmbparentcategory.DataSource = tempParentCategoryList;
            cmbparentcategory.DisplayMember = "ParentCategoryName";
            cmbparentcategory.ValueMember = "ParentCategoryID";
        }

        private void rbtnparentcategory_CheckedChanged(object sender, EventArgs e)
        {
            cmbparentcategory.Enabled = rbtnparentcategory.Checked;
        }

        private void rbtsubcategory_CheckedChanged(object sender, EventArgs e)
        {
            cmbsubcategory.Enabled = rbtsubcategory.Checked;
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            SysytemManagementDAO aManagementDao=new SysytemManagementDAO();
            Int64 startDate = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0).Ticks;
            DateTime dtTemp = dtpEnd.Value.AddDays(1);
            Int64 endDate = new DateTime(dtTemp.Year, dtTemp.Month, dtTemp.Day, 0, 0, 0).Ticks;
            


            if (complementoryRadioButton.Checked)
            {
                DataTable dtFood = aManagementDao.GetComplementorySales(startDate, endDate);
                categorydataGridView.DataSource = dtFood.AsDataView();

                Decimal totalprice = 0;
                try
                {

                    totalprice =
                        (from order in dtFood.AsEnumerable()
                         select order.Field<Decimal>("TotalPrice")).Sum();
                }
                catch (Exception)
                {


                }
                lblPriceTotal.Text = "Total Sale Price: " + totalprice.ToString("F02");

            }
            else
            {
                DataTable dtFood = aManagementDao.GetCategoryWiseSales(startDate, endDate);
                if (rbtnparentcategory.Checked)
                {

                    if (cmbparentcategory.Text != "ALL")
                    {
                        var results = from myRow in dtFood.AsEnumerable()
                                      where
                                          myRow.Field<int?>("parent_cat_id") ==
                                          Convert.ToInt32(cmbparentcategory.SelectedValue)
                                      select myRow;


                        Decimal totalprice = 0;
                        try
                        {

                            totalprice =
                                (from order in results.AsEnumerable()
                                 select order.Field<Decimal>("TotalPrice")).Sum();
                        }
                        catch (Exception)
                        {


                        }

                        if (results != null)
                        {
                            // dtFood = results.CopyToDataTable();
                            lblPriceTotal.Text = "Total Sale Price: " + totalprice.ToString("F02");
                            categorydataGridView.DataSource = results.AsDataView();
                        }

                    }
                    else
                    {
                        var results = from myRow in dtFood.AsEnumerable()
                                      select myRow;


                        Decimal totalprice = 0;
                        try
                        {

                            totalprice =
                                (from order in results.AsEnumerable()
                                 select order.Field<Decimal>("TotalPrice")).Sum();
                        }
                        catch (Exception)
                        {


                        }

                        if (results != null)
                        {
                            // dtFood = results.CopyToDataTable();
                            lblPriceTotal.Text = "Total Sale Price: " + totalprice.ToString("F02");
                            categorydataGridView.DataSource = results.AsDataView();
                        }

                    }




                }
                else if (rbtsubcategory.Checked)
                {
                    try
                    {
                        if (cmbsubcategory.Text != "AddMisc")
                        {
                            var results = from myRow in dtFood.AsEnumerable()
                                          where
                                              myRow.Field<int?>("cat2_id") ==
                                              Convert.ToInt32(cmbsubcategory.SelectedValue)
                                          select myRow;
                            // dtFood = results.CopyToDataTable();
                            Decimal totalprice = 0;
                            try
                            {

                                totalprice =
                                    (from order in results.AsEnumerable()
                                     select order.Field<Decimal>("TotalPrice")).Sum();
                                lblPriceTotal.Text = "Total Sale Price: " + totalprice.ToString("F02");
                            }
                            catch (Exception)
                            {


                            }

                            categorydataGridView.DataSource = results.AsDataView();
                        }
                        else
                        {


                            var results = from myRow in dtFood.AsEnumerable()
                                          where
                                              myRow.Field<Int64?>("product_id") == 0
                                          select myRow;
                            // dtFood = results.CopyToDataTable();
                            Decimal totalprice = 0;
                            try
                            {

                                totalprice =
                                    (from order in results.AsEnumerable()
                                     select order.Field<Decimal>("TotalPrice")).Sum();
                                lblPriceTotal.Text = "Total Sale Price: " + totalprice.ToString("F02");
                            }
                            catch (Exception)
                            {


                            }
                            categorydataGridView.DataSource = results.AsDataView();
                        }
                    }
                    catch (Exception)
                    {


                    }


                }
                else if (itemRadioButton.Checked)
                {

                    try
                    {

                        var results = from myRow in dtFood.AsEnumerable()
                                      where
                                          myRow.Field<Int64?>("product_id") ==
                                          Convert.ToInt64(itemMenucomboBox.SelectedValue)
                                      select myRow;
                        //   dtFood = results.CopyToDataTable();
                        Decimal totalprice = 0;
                        try
                        {

                            totalprice =
                                (from order in results.AsEnumerable()
                                 select order.Field<Decimal>("TotalPrice")).Sum();
                            lblPriceTotal.Text = "Total Sale Price: " + totalprice.ToString("F02");
                        }
                        catch (Exception)
                        {


                        }
                        categorydataGridView.DataSource = results.AsDataView();


                    }
                    catch (Exception)
                    {


                    }

                    // categorydataGridView.DataSource = dtFood.AsDataView();

                }
            }


            // categorydataGridView.DataSource = dtFood;
        }

        private void categorydataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            categorydataGridView.Columns["product_id"].Visible = false;
            categorydataGridView.Columns["parent_cat_id"].Visible = false;
            categorydataGridView.Columns["cat2_id"].Visible = false;
        }

        private void functionalButton1_Click(object sender, EventArgs e)
        {
            try
            {
                printReportLogoType = 1;
                int printlenght = categorydataGridView.Rows.Count + 28;
                DataView dv = (DataView)(categorydataGridView.DataSource);

                DataTable dtt = dv.ToTable();
                PrintDocument doc = new TextDocument(PrintReport(dtt), printlenght);
                doc.PrintPage += this.Doc_PrintPage;

                doc.DefaultPageSettings.Landscape = true;
                PrintDialog dlgSettings = new PrintDialog();
                dlgSettings.UseEXDialog = true;
                dlgSettings.Document = doc;

                if (dlgSettings.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }
            }
            catch (Exception)
            {
                
            }
         
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
      

            try
            {
                #region with Image
                //Font printFont = new Font("Lucida Console", 8);


                //int printHeight;
                //int printWidth;
                //printHeight = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Height - ((PrintDocument)sender).DefaultPageSettings.Margins.Top - ((PrintDocument)sender).DefaultPageSettings.Margins.Bottom;
                //printWidth = ((PrintDocument)sender).DefaultPageSettings.PaperSize.Width - ((PrintDocument)sender).DefaultPageSettings.Margins.Left - ((PrintDocument)sender).DefaultPageSettings.Margins.Right;

                //StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);

                ////   e.Graphics.DrawImage(Image.FromFile("d:\\carnival-logo2.PNG"), 80, 0);
                //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 60, 2);


                ////  e.Graphics.DrawImage("",
                //RectangleF printArea = new RectangleF(0, 60, 260, printHeight);

                ////    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

                ////  Font printFont = new Font("Lucida Console", 8);
                //Font printFont1 = new Font("Lucida Console", 10);

                //if (printDestiNationType == PrintDestiNation.BEVARAGE || printDestiNationType == PrintDestiNation.KITCHEN)
                //{
                //    printBody = printBody.ToUpper();

                //    string substring1 = printBody.Substring(0, printBody.IndexOf("TABLE"));
                //    string substring2 = printBody.Substring(printBody.IndexOf("TABLE"), printBody.IndexOf("COVERS:") + 10 - substring1.Length);
                //    string substring3 = printBody.Substring(printBody.IndexOf("COVERS:") + 10, printBody.Length - substring1.Length - substring2.Length - 1);
                //    string newLine = "";
                //    string newLine1 = "";
                //    if (printDestiNationType == PrintDestiNation.KITCHEN)
                //    {
                //        newLine = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r";
                //        newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
                //    }
                //    else
                //    {
                //        newLine = "\r\n\r\n\r\n\r\n\r\n\r";
                //        newLine1 = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
                //    }
                //    //e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);

                //    e.Graphics.DrawString(substring1, printFont, Brushes.Black, printArea, format);
                //    e.Graphics.DrawString(newLine + substring2, printFont1, Brushes.Black, printArea, format);
                //    e.Graphics.DrawString(newLine1 + substring3, printFont, Brushes.Black, printArea, format);
                //}
                //else
                //{
                //    e.Graphics.DrawString(printBody, printFont, Brushes.Black, printArea, format);
                //}

                #endregion

                #region  Image

                TextDocument doc = (TextDocument)sender;

                Font font = new Font("Lucida Console", 7);

                float lineHeight = font.GetHeight(e.Graphics);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                if (printReportLogoType == 1)
                {
                    //For Birds Eye Restaurant
                //    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 480, 40);

                    //for Labamba Restaurant 

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 400, 0);

                     //for Aroma Restaurant 
                     //e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 400, 0);
                    
                }
                else if (printReportLogoType == 2)
                {
                    //For Bird Eye Restaurant Logo 
                  //  e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 0,0);

                    //for Aroma Restaurant 
                 //   e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
                }
                else if (printReportLogoType == 3)
                {
                    //For Bird Eye Restaurant Logo 
                //    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\rooftop.png"), 50, 40);

                    //for Labamba Restaurant 

                    e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\IZUMI.jpg"), 35, 40);

                    //for Aroma Restaurant 
                   // e.Graphics.DrawImage(Image.FromFile("C:\\Program Files\\Ibacs Ltd\\RMS Client\\aroma.png"), 5, 0);
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

                #endregion


                #region Without Image 
                
                //TextDocument doc = (TextDocument)sender;

                //Font font = new Font("Lucida Console", 7);

                //float lineHeight = font.GetHeight(e.Graphics);

                //float x = e.MarginBounds.Left;
                //float y = e.MarginBounds.Top ;
               

                //doc.PageNumber += 1;

                //while ((y + lineHeight) < e.MarginBounds.Bottom && doc.Offset <= doc.Text.GetUpperBound(0))
                //{
                //    e.Graphics.DrawString(doc.Text[doc.Offset], font, Brushes.Black, 0, y);
                //    doc.Offset += 1;
                //    y += lineHeight;
                //}

                //if (doc.Offset < doc.Text.GetUpperBound(0))
                //{
                //    e.HasMorePages = true;
                //}
                //else
                //{
                //    doc.Offset = 0;
                //}

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry! Problem occured." + ex.ToString());
            }

        }


        private string PrintReport(DataTable dtFood)
        {
            StringPrintFormater stringPrintFormater = new StringPrintFormater(172);

            string strBody = "";
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
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("SALES REPORT- Category WISE");
            //  strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("RED CHICK'N");
            strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("Date: From - " + dtpStart.Value.ToShortDateString() + " to " + dtpEnd.Value.ToShortDateString());
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            Decimal totalprice = 0;
            try
            {

                 totalprice =
                (from order in dtFood.AsEnumerable()
                 select order.Field<Decimal>("TotalPrice")).Sum();
            }
            catch (Exception)
            {
                
              
            }
            strBody += "\r\n" + stringPrintFormater.ItemLabeledText("Total Sold Price: "+totalprice.ToString("F02"),"" );
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblQtySoldFood.Text, "");
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblQtySoldNonFood.Text, "");
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblQtySoldTotal.Text, "");
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblPriceFood.Text, "");
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblPriceNonFood.Text, "");
            //strBody += "\r\n" + stringPrintFormater.ItemLabeledText("" + lblPriceTotal.Text, "");

            //strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            //strBody += "\r\n";
            //strBody += "\r\n";
            //strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("DETAILS : FOOD");
            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

          //  strBody += "\r\n" + stringPrintFormater.GridCell("Item ID", 15, false);
            strBody += "\r\n" + stringPrintFormater.GridCell("Item Name", 45, false);
            strBody += stringPrintFormater.GridCell("Price Per Unit", 18, false);
            strBody += stringPrintFormater.GridCell("Quantity Sold", 18, false);

            strBody += stringPrintFormater.GridCell("Total Price", 18, false);
            //strBody += stringPrintFormater.GridCell("Total Cost", 18, false);
            //strBody += stringPrintFormater.GridCell("Profit", 18, false);
            //strBody += stringPrintFormater.GridCell("Profit(%)", 18, false);


            strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            foreach (DataRow row in dtFood.Rows)
            {

                //strBody += "\r\n" + stringPrintFormater.GridCell(row[0].ToString(), 15, false);
                strBody += "\r\n" + stringPrintFormater.GridCell(row["product_Name"].ToString(), 45, false);
                strBody += stringPrintFormater.GridCell(row["PricePerUnit"].ToString(), 18, false);
                strBody += stringPrintFormater.GridCell(row["QuantitySold"].ToString(), 18, false);

                strBody += stringPrintFormater.GridCell(row["TotalPrice"].ToString(), 18, false);
                //strBody += stringPrintFormater.GridCell(row[5].ToString(), 18, false);
                //strBody += stringPrintFormater.GridCell(row[6].ToString(), 18, false);
                //strBody += stringPrintFormater.GridCell(row[7].ToString(), 18, false);


                strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            }


            //strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            //strBody += "\r\n";
            //strBody += "\r\n";
            //strBody += "\r\n" + stringPrintFormater.CenterTextWithWhiteSpace("DETAILS : NON FOOD");
            //strBody += "\r\n" + stringPrintFormater.CreateDashedLine();


            //foreach (DataRow row in dtNonFood.Rows)
            //{
            //    strBody += "\r\n" + stringPrintFormater.GridCell(row[0].ToString(), 15, false);
            //    strBody += stringPrintFormater.GridCell(row[1].ToString(), 45, false);
            //    strBody += stringPrintFormater.GridCell(row[2].ToString(), 18, false);
            //    strBody += stringPrintFormater.GridCell(row[3].ToString(), 18, false);
            //    strBody += stringPrintFormater.GridCell(row[4].ToString(), 18, false);
            //    strBody += stringPrintFormater.GridCell(row[5].ToString(), 18, false);
            //    strBody += stringPrintFormater.GridCell(row[6].ToString(), 18, false);
            //    strBody += stringPrintFormater.GridCell(row[7].ToString(), 18, false);
            //    strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            //}


            // strBody += "\r\n" + stringPrintFormater.CreateDashedLine();

            strBody += "\r\n";
            strBody += "\r\n" + stringPrintFormater.CenterTextWithDashed("END REPORT");

            strBody += "\r\n\r\n\r\n" + "                     --------------------" + "                                                             ---------------------      ";
            strBody += "\r\n" + "                           Checked By" + "                                                                       Prepared By         ";

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

        private void itemRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemMenucomboBox.Enabled = itemRadioButton.Checked;
        }

        private void cmbsubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemMenu();
        }

        private void LoadItemMenu()
        {
            try
            {
                CCategory3DAO aCCategory3Dao = new CCategory3DAO();
                List<CCategory3> aCategory3s = new List<CCategory3>();
                if (Convert.ToInt32("0" + cmbsubcategory.SelectedValue) != 0)
                {
                    aCategory3s =
                        aCCategory3Dao.GetCategory3ByCategory2ID(Convert.ToInt32("0" + cmbsubcategory.SelectedValue));
                    itemMenucomboBox.DataSource = aCategory3s;

                    itemMenucomboBox.DisplayMember = "Category3Name";
                    itemMenucomboBox.ValueMember = "Category3ID";
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
