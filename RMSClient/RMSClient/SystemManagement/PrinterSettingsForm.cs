using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace RMS.SystemManagement
{
    public partial class PrinterSettingsForm : Form
    {
        private PrinterConfig printConfig;
        public PrinterSettingsForm()
        {
           
            InitializeComponent();

            Init();
            radioButtonNo.Checked = true;
            txtBoxBevaragePrinterName.Click += new System.EventHandler(this.txtBox_Click);
            txtBoxClientPrinterName.Click += new System.EventHandler(this.txtBox_Click);
            txtBoxKitchenPrinterName.Click += new System.EventHandler(this.txtBox_Click);
            txtBoxotherPrinterName.Click += new System.EventHandler(this.txtBox_Click);
            txtBoxothernonfoodPrinterNametextBox.Click += new System.EventHandler(this.txtBox_Click);


        }

        private void Init()
        {
            printConfig = new PrinterConfig();
            txtBoxBevaragePrinterName.Text = printConfig.BeveragePrinterName;
            txtBoxKitchenPrinterName.Text = printConfig.KitchenPrinterName;
            txtBoxClientPrinterName.Text = printConfig.ClientPrinterName;
            txtBoxotherPrinterName.Text = printConfig.OtherPrinter;
            txtBoxothernonfoodPrinterNametextBox.Text = printConfig.OtherNonFoodPrinter;
            radioButtonYex.Checked = printConfig.EnableSerialPortPrinting;


            //if (printConfig.BeveragePrintPaperSize == 38)
            //{
            //    rdbBevaragePrintSize38.Checked = true;
            //}
            //else if (printConfig.BeveragePrintPaperSize == 26)
            //{
            //    rdbBevaragePrintSize26.Checked = true;
            //}

            //if (printConfig.KitchenPrintPaperSize == 38)
            //{
            //    rdbKitchenPaperSize38.Checked = true;
            //}
            //else if (printConfig.KitchenPrintPaperSize == 26)
            //{
            //    rdbKitchenPaperSize26.Checked = true;
            //}

        }

        private void txtBox_Click(object sender, EventArgs e)
        {
            keyboard1.ControlToInputText = (TextBox)sender;
        }

        private void btnSavePrinterSettings_Click(object sender, EventArgs e)
        {
            printConfig.BeveragePrinterName = txtBoxBevaragePrinterName.Text;
            printConfig.KitchenPrinterName=txtBoxKitchenPrinterName.Text;
            printConfig.ClientPrinterName = txtBoxClientPrinterName.Text;
            printConfig.OtherPrinter = txtBoxotherPrinterName.Text;
            printConfig.OtherNonFoodPrinter = txtBoxothernonfoodPrinterNametextBox.Text;
            printConfig.EnableSerialPortPrinting=radioButtonYex.Checked;

            //if (rdbBevaragePrintSize38.Checked)
            //{
            //    printConfig.BeveragePrintPaperSize = 38;
            //}
            //else if (rdbBevaragePrintSize26.Checked)
            //{
            //    printConfig.BeveragePrintPaperSize = 26;
            //}


            //if (rdbKitchenPaperSize38.Checked)
            //{
            //    printConfig.KitchenPrintPaperSize = 38;
            //}
            //else if (rdbKitchenPaperSize26.Checked)
            //{
            //    printConfig.KitchenPrintPaperSize = 26;
            //}

            if (printConfig.SaveChanges())
            {
                MessageBox.Show("Printer Cofiguration has ben saved Successfully");
            }
            else
            {
                MessageBox.Show("Printer Cofiguration has not ben saved Successfully");
            }

        }

        private void btnTestClientPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnTestKitchenPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnTestBevaragePrint_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machineName = System.Environment.MachineName;
            string printerNameWithMachine = cbGuestBillPrinterList.SelectedItem.ToString();
            string[] partOfPrinterName = printerNameWithMachine.Split('\\');
            string printerName = "";
            bool foundMachineName = false;
            if (partOfPrinterName.Length > 1)
            {
                foreach (string str in partOfPrinterName)
                {
                    if (str == "")
                        continue;
                    else
                    {
                        if (foundMachineName == false)
                        {
                            machineName = str;
                            foundMachineName = true;
                        }
                        else
                            printerName = str;
                    }
                }
            }
            else
                printerName = partOfPrinterName[0];
            this.txtBoxClientPrinterName.Text = "\\\\" + machineName + "\\" + printerName;
        }

        private void cbBevaragePrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machineName = System.Environment.MachineName;
            string printerNameWithMachine = cbBevaragePrinter.SelectedItem.ToString();
            string[] partOfPrinterName = printerNameWithMachine.Split('\\');
            string printerName = "";
            bool foundMachineName = false;
            if (partOfPrinterName.Length > 1)
            {
                foreach (string str in partOfPrinterName)
                {
                    if (str == "")
                        continue;
                    else
                    {
                        if (foundMachineName == false)
                        {
                            machineName = str;
                            foundMachineName = true;
                        }
                        else
                            printerName = str;
                    }
                }
            }
            else
                printerName = partOfPrinterName[0];
            this.txtBoxBevaragePrinterName.Text = "\\\\" + machineName + "\\" + printerName;
        }

        private void cbPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machineName = System.Environment.MachineName;
            string printerNameWithMachine = cbPrinterList.SelectedItem.ToString();
            string[] partOfPrinterName = printerNameWithMachine.Split('\\');
            string printerName = "";
            bool foundMachineName = false;
            if (partOfPrinterName.Length > 1)
            {
                foreach (string str in partOfPrinterName)
                {
                    if (str == "")
                        continue;
                    else
                    {
                        if (foundMachineName == false)
                        {
                            machineName = str;
                            foundMachineName = true;
                        }
                        else
                            printerName = str;
                    }
                }
            }
            else
                printerName = partOfPrinterName[0];
            this.txtBoxKitchenPrinterName.Text = "\\\\" + machineName + "\\" + printerName;
        }

        private void PrinterSettingsForm_Load(object sender, EventArgs e)
        {
            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                cbPrinterList.Items.Add(printer.ToString());
                cbBevaragePrinter.Items.Add(printer.ToString());
                cbGuestBillPrinterList.Items.Add(printer.ToString());
                comboBoxotherBillPrinterList.Items.Add(printer.ToString());
                comboBoxothernonfoodBillPrinterList.Items.Add(printer.ToString());
               
            }
        }

        private void comboBoxotherBillPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machineName = System.Environment.MachineName;
            string printerNameWithMachine =comboBoxotherBillPrinterList.SelectedItem.ToString();
            string[] partOfPrinterName = printerNameWithMachine.Split('\\');
            string printerName = "";
            bool foundMachineName = false;
            if (partOfPrinterName.Length > 1)
            {
                foreach (string str in partOfPrinterName)
                {
                    if (str == "")
                        continue;
                    else
                    {
                        if (foundMachineName == false)
                        {
                            machineName = str;
                            foundMachineName = true;
                        }
                        else
                            printerName = str;
                    }
                }
            }
            else
                printerName = partOfPrinterName[0];
            this.txtBoxotherPrinterName.Text = "\\\\" + machineName + "\\" + printerName;

        }

        private void comboBoxothernonfoodBillPrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string machineName = System.Environment.MachineName;
            string printerNameWithMachine = comboBoxothernonfoodBillPrinterList.SelectedItem.ToString();
            string[] partOfPrinterName = printerNameWithMachine.Split('\\');
            string printerName = "";
            bool foundMachineName = false;
            if (partOfPrinterName.Length > 1)
            {
                foreach (string str in partOfPrinterName)
                {
                    if (str == "")
                        continue;
                    else
                    {
                        if (foundMachineName == false)
                        {
                            machineName = str;
                            foundMachineName = true;
                        }
                        else
                            printerName = str;
                    }
                }
            }
            else
                printerName = partOfPrinterName[0];
            this.txtBoxothernonfoodPrinterNametextBox.Text = "\\\\" + machineName + "\\" + printerName;
        }
    }
}
