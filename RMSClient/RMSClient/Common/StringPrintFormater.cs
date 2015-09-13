﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common
{
    public  class StringPrintFormater
    {

        private int lineLength = 0;
        private string dashedLine = "";

        public StringPrintFormater(int lineLength)
        {
            this.lineLength = lineLength;
            string str = "";
            for (int i = 0; i < lineLength; i++)
            {
                str += "-";
            }
            dashedLine =str;
        }

       
        public string CreateDashedLine()
        {
            return dashedLine;
        }
        public string CenterTextWithDashed(string text)
        {
            string str = dashedLine.Remove(0, text.Length);
            str = str.Insert(str.Length/2, text);
            return str;
        }

        public string CenterTextWithWhiteSpace(string text)
        {
            string str = dashedLine.Replace("-", " ");

            try
            {
               // string str = dashedLine.Replace("-", " ");
                str = str.Remove(0, text.Length);
                str = str.Insert(str.Length / 2, text);
            }
            catch { }
            return str;
        }
        public string ItemLabeledText(string leftText, string rightText)
        {
            int leftTextLength = leftText.Length;
            int rightTextLength = rightText.Length;
            int diff = lineLength - (leftTextLength + rightTextLength);
            string strDash = "";
            for (int i = 0; i < diff; i++)
            {
                strDash += " ";
            }
            string str = leftText + strDash + rightText;
            return str;
        }
        public string SumupLabeledText(string leftText, string rightText)
        {
            string str = rightText;

            while (str.Length < lineLength-1) // Change by Mithu
            {

                if (str.Length < 9)
                {
                   str= str.Insert(0, " ");
                }
                else if (str.Length == 9)
                {
                    str = str.Insert(0, leftText);
                }
                else {
                    str = str.Insert(0, " ");
                }
            }
            return str;
        }

        public string GridCell(string value, int length, bool right)
        {
            string str = "";

            if (right)
            {

                str += value ;
                while (str.Length < length-1)
                {
                    str = str.Insert(0, " ");
                }
                str = str.Insert(0, "|");
            }
            else 
            {
                str +=  "|"+value;
                while (str.Length < length-1)
                {
                    str+=(" ");
                }
            }


            return str;
        
        }



    }
}