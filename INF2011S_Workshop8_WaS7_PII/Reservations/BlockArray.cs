using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Drawing;

namespace INF2011S_Workshop8_WaS7_PII.Shifts
{
    public class BlockArray : System.Collections.CollectionBase
    {
        private Form hostForm;
        private int height;         //size of ONE block --- height
        private int width;          //size of ONE block --- width
        private int offset;         //distance from left side
        private int blocksInRow;     //number of block in a row

        public System.Windows.Forms.Button Item(int index)
        {
            return (System.Windows.Forms.Button)this.List[index];
        }

        public BlockArray(System.Windows.Forms.Form host, int heightVal, int widthVal, int offsetVal, int nrInRow)
        {
            hostForm = host;
            height = heightVal;
            width = widthVal;
            offset = offsetVal;
            blocksInRow = nrInRow;
        }


        // determines the position of blocks
         public void AddNewBlock()
        {
            System.Windows.Forms.Button aBlock = new System.Windows.Forms.Button();

            aBlock.Height = height;    //***size of control
            aBlock.Width = width;      //***size of control
            // **** Calculations below will test you maths skills :) - for each block you need the coordinates of the top left point :)
            aBlock.Top =  (this.Count / blocksInRow + 4) * aBlock.Height;         //***Position
            aBlock.Left = offset + (this.Count % blocksInRow) * aBlock.Width;    //***Position

            aBlock.Tag = this.Count;   //to indicate number of the block save it in the Tag property of the control (button)

            aBlock.BackColor = Color.LightGoldenrodYellow;  // see the use of enums- hallelujah :)

            //*****You have to add the control (a button in this case) 
            //****(to a list --a type of collection
            this.List.Add(aBlock);

            //*****You have to add the control (a button in this case)
            //***** to the Control list of the form
            hostForm.Controls.Add(aBlock);
        }

        public void RemoveLastBlock()
        {
            if (this.Count > 0)
            {
                hostForm.Controls.Remove((System.Windows.Forms.Control)(this.List[this.Count - 1]));
                this.List.RemoveAt(this.Count - 1);
            }
        }

    }
}
