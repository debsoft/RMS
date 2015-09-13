using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RMSUI
{
    public class SimpleGrid:DataGridView
    {
        public SimpleGrid()
        {
            Font headerFont = new Font("Microsoft Sans Serif", 10);

            Padding padding=new Padding(2) ;
       
         

            base.RowHeadersVisible = false;
           
            base.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            base.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            base.ColumnHeadersDefaultCellStyle.Font = headerFont;
            base.ColumnHeadersDefaultCellStyle.Padding = padding;
            base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            base.ColumnHeadersHeight = 40;
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            base.BackgroundColor = Color.WhiteSmoke;
            base.BorderStyle = BorderStyle.None;
            base.GridColor = Color.Gray;

        }
    }
}
