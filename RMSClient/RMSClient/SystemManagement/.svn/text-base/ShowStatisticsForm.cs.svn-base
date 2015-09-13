using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebChart;
using RMS.Common;
using System.Data.SqlClient;
using Managers.Payment;
using RMS.Common.ObjectModel;
using Managers.TableInfo;
using System.Net;
using RMSUI;

namespace RMS
{
    public partial class ShowStatisticsForm : Form
    {
        Int64 m_oStartTime;
        Int64 m_oEndTime;

        public ShowStatisticsForm()
        {
            InitializeComponent();
            LoadGraph();
        }

        
        public void ConvertTime(ref DataSet inDataSet)
        {
            for (int rowIndex = 0; rowIndex < inDataSet.Tables[0].Rows.Count; rowIndex++)
            {
                Int64 oldFormat = Int64.Parse(inDataSet.Tables[0].Rows[rowIndex]["Time"].ToString());

                DateTime newFormat = new DateTime(oldFormat);
                inDataSet.Tables[0].Rows[rowIndex]["NewTime"] = newFormat.Hour + ":" + newFormat.Minute;

            }
        }

        public void GetTimeSpan(DateTime inCurrentDate)
        {
            Int64 tempStartTime = inCurrentDate.Ticks;
            Int64 tempEndTime = inCurrentDate.AddDays(1).Ticks;

            Int64 tempCheckTime = (inCurrentDate.Date.AddHours(8)).Ticks;

            if (inCurrentDate.Ticks < tempCheckTime)
            {
                tempStartTime = tempCheckTime - 864000000000;
                tempEndTime = tempCheckTime;
            }

            else if (inCurrentDate.Ticks >= tempCheckTime)
            {
                tempStartTime = tempCheckTime;
                tempEndTime = tempCheckTime + 864000000000;
            }

            m_oStartTime = tempStartTime;
            m_oEndTime = tempEndTime;

        }      

        public void LoadGraph()
        {
            ChartEngine tempChartEngine = new ChartEngine();
            tempChartEngine.Size = GraphPictureBox.Size;
            tempChartEngine.ShowXValues = true;
            tempChartEngine.ShowYValues = true;
          //  tempChartEngine.Padding = 40;
            tempChartEngine.BottomChartPadding = 30;
            tempChartEngine.LeftChartPadding = 40;


            ChartText tempChartText = new ChartText();
            tempChartText.Text = "Hourly Sales";
            tempChartEngine.Title = tempChartText;

            CPaymentManager tempPaymentManager = new CPaymentManager();
            CResult oResult = tempPaymentManager.GetSortedPayment(DateTime.Now);
            double MaxAmount = 0.0;
            if (oResult.IsSuccess && oResult.Data != null)
            {
                MaxAmount = (double)oResult.Data;
            }


           // tempChartEngine.YValuesInterval = (int)Math.Floor(MaxAmount / 20);
            tempChartEngine.YValuesInterval = GetInterVal(MaxAmount);
            tempChartEngine.YCustomEnd = GetCustomEnd(GetInterVal(MaxAmount), MaxAmount);

            ChartCollection tempChartCollection = new ChartCollection(tempChartEngine);
            tempChartEngine.Charts = tempChartCollection;
            DateTime inCurrentDate = DateTime.Now;
            GetTimeSpan(inCurrentDate);


            //Data Access

            try
            {
                CPcInfoManager tempPcInfoManager = new CPcInfoManager();
                IPHostEntry ipEntry = System.Net.Dns.GetHostByName(Dns.GetHostName());
                CPcInfo tempPcInfo = (CPcInfo)tempPcInfoManager.PcInfoByPcIP(ipEntry.AddressList[0].ToString()).Data;

                DataSet tempHourlySaleDataSet = new DataSet();
                CCommonConstants oConstants = ConfigManager.GetConfig<CCommonConstants>();
                String sSql = String.Format("select 'NewTime' as \"NewTime\",bill_print_time.payment_time as \"Time\",payment.total_amount as \"Amount\" from payment,bill_print_time where payment.order_id=bill_print_time.order_id and bill_print_time.payment_time>={0} and bill_print_time.payment_time<{1} and payment.pc_id={2}", m_oStartTime, m_oEndTime, tempPcInfo.PcID);
                SqlDataAdapter tempSqlDataAdapter = new SqlDataAdapter(sSql, oConstants.DBConnection);
                tempSqlDataAdapter.Fill(tempHourlySaleDataSet);

                sSql = String.Format("select 'NewTime' as \"NewTime\",deposit_time as \"Time\",total_amount as \"Amount\" from deposit where deposit_time >= {0} and deposit_time < {1} and deposit.pc_id={2}", m_oStartTime, m_oEndTime, tempPcInfo.PcID);
                tempSqlDataAdapter = new SqlDataAdapter(sSql, oConstants.DBConnection);
                tempSqlDataAdapter.Fill(tempHourlySaleDataSet);


                ConvertTime(ref tempHourlySaleDataSet);

                //start dummy time
                DataRow row1 = tempHourlySaleDataSet.Tables[0].NewRow();
                row1["NewTime"] = "0:00";
                row1["Amount"] = "0.000";

                //end dummy time
                DataRow row2 = tempHourlySaleDataSet.Tables[0].NewRow();
                row2["NewTime"] = "23:59";
                row2["Amount"] = "0.000";

                tempHourlySaleDataSet.Tables[0].Rows.Add(row1);
                tempHourlySaleDataSet.Tables[0].Rows.Add(row2);



                Chart tempLineChart = new LineChart();
                tempLineChart.Line.Color = Color.Red;
                tempLineChart.ShowLineMarkers = false;
                tempLineChart.Line.Width = (float)2.0;

                DataTableReader oReader = tempHourlySaleDataSet.Tables[0].CreateDataReader();

                tempLineChart.DataSource = oReader;

                tempLineChart.DataXValueField = "NewTime";
                tempLineChart.DataYValueField = "Amount";
                tempLineChart.DataBind();
                tempChartCollection.Add(tempLineChart);


                Image image = tempChartEngine.GetBitmap();
                GraphPictureBox.Image = image;
                GraphPictureBox.Update();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private int GetInterVal(double maxValue)
        {
            int intervalSpan = 500;

            if (maxValue <= 1000)
            {
                intervalSpan = 200;
            }
            else if (maxValue <= 5000) 
            {
                intervalSpan = 500;
            }
            else if (maxValue <= 10000)
            {
                intervalSpan = 1000;
            }
            else if (maxValue <= 50000)
            {
                intervalSpan = 2500;
            }
            else if (maxValue <= 100000)
            {
                intervalSpan = 5000;
            }
            else if (maxValue <= 200000)
            {
                intervalSpan = 10000;
            }
            else {
                intervalSpan = 25000;
            }


          /* double j=maxValue / intervalSpan;
           double i= (double)Math.Round(j);

           if (i < j)
           {

               i += 1;
           }



            
            */

          //  (int)Math.Floor(MaxAmount / 20);



           return intervalSpan;
        }

        private int GetCustomEnd(int interval, double maxValue)
        {

            int i = 0;
            while (i < maxValue)
            {
                i += interval;
            }
            return i;
        
        }
    }
}
