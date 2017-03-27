using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public enum CheckStyle
    {
        style1 = 0,
        style2 = 1,
        style3 = 2,
        style4 = 3,
        style5 = 4,
        style6 = 5
    };

    public partial class my_check_box : UserControl
    {
        private int isCheck = 0;

        public my_check_box()
        {
            InitializeComponent();

            //设置Style支持透明背景色并且双缓冲
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;

            this.Cursor = Cursors.Hand;
            this.Size = new Size(87, 27);
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public int Checked
        {
            set { isCheck = value; this.Invalidate(); }
            get { return isCheck; }
        }

        CheckStyle checkStyle = CheckStyle.style1;

        
        public CheckStyle CheckStyleX
        {
            set { checkStyle = value; this.Invalidate(); }
            get { return checkStyle; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bitMapOn = null;
            Bitmap bitMapOff = null;

            if (checkStyle == CheckStyle.style1)
            {
                bitMapOn = global::WinCommand.Properties.Resources.btncheckon1;
                bitMapOff = global::WinCommand.Properties.Resources.btncheckoff1;

            }
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            if (this .isCheck != 0) 
            {
                g.DrawImage(bitMapOn, rec);
            }
            else
            {
                g.DrawImage(bitMapOff, rec);
            }
        }

        private void my_check_box_Click(object sender, EventArgs e)
        {
            if (this.isCheck != 0)
            {
                this.isCheck = 0;
            }
            else
            {
                this.isCheck = 1;
            }
            this.Invalidate();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // my_check_box
            // 
            this.Name = "my_check_box";
            this.Size = new System.Drawing.Size(89, 29);
            this.Click += new System.EventHandler(this.my_check_box_Click);
            this.ResumeLayout(false);

        }

    }
}
