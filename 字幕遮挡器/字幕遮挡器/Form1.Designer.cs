using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace 字幕遮挡器
{
    partial class OutSubtitle
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OutSubtitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(499, 96);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OutSubtitle";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OutSubtitle_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutSubtitle_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OutSubtitle_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OutSubtitle_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        /*
        [DllImport("user32.dll")]
        public static extern bool ReleaseCaptuee();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int iParam);
        */
      
        private Point mouseDownPoint;
        private Size oldSize;

        private bool beginMove = false;
        private bool reSize = false;
        /*
        public delegate void ONEventControlResize();
        public class ControlResize
        {

        }
        public event ONEventControlResize EventControlResize;
        */
    }
}

