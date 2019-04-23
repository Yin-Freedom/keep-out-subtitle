using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 字幕遮挡器
{
    public partial class OutSubtitle : Form
    {
        public MouseDirection direction;

        public OutSubtitle()
        {
            InitializeComponent();
        }

        public static implicit operator Size(OutSubtitle v)
        {
            throw new NotImplementedException();
        }

        private void OutSubtitle_MouseDown(object sender, MouseEventArgs e)
        {
            // e.Location 为鼠标相对于窗体左上角的 x 坐标和 y 坐标（以像素为单位）
            mouseDownPoint.X = MousePosition.X;
            mouseDownPoint.Y = MousePosition.Y;
            oldSize = Size;
            if (e.Button == MouseButtons.Left && direction == MouseDirection.None)
            {
                Cursor = Cursors.SizeAll;
                beginMove = true;
            }
            else if(e.Button==MouseButtons.Left && direction != MouseDirection.None)
            {
                reSize = true;
            }

            if(e.Button==MouseButtons.Right)
            {
                ColorDialog MyDialog = new ColorDialog();
                // Keeps the user from selecting a custom color.
                MyDialog.AllowFullOpen = false;
                // Allows the user to get help. (The default is false.)
                MyDialog.ShowHelp = true;
                // Sets the initial color select to the current text color.
                MyDialog.Color = this.BackColor;

                // Update the text box color if the user clicks OK 
                if (MyDialog.ShowDialog() == DialogResult.OK)
                    this.BackColor = MyDialog.Color;
            }
        }

        private void OutSubtitle_MouseMove(object sender, MouseEventArgs e) // Location Coordinate 相较于WinForm左上角而言
        {
            // 如果将 reSize 判断放在 Mouse 位置判断之后，将会导致鼠标进入窗体时先将 reSize 设置为false。
            if (beginMove)
            {
                Relocation();
            }
            if (reSize)
            {
                ResizeControl(e.Location);
            }

            if (e.Location.X >= Width - 10 && e.Location.Y >= Height - 10) // 东南
            {
                Cursor = Cursors.SizeNWSE;
                direction = MouseDirection.EastSouth;
            }
            else if (e.Location.X >= Width - 10 && e.Location.Y <= 10) // 东北
            {
                Cursor = Cursors.SizeNESW;
                direction = MouseDirection.EastNorth;
            }
            else if (e.Location.X <= 10 && e.Location.Y >= Height - 10) // 西南
            {
                Cursor = Cursors.SizeNESW;
                direction = MouseDirection.WestSouth;
            }
            else if (e.Location.X <= 10 && e.Location.Y <= 10) // 西北
            {
                Cursor = Cursors.SizeNWSE;
                direction = MouseDirection.WestNorth;
            }

            else if ((e.Location.X < 10) && (e.Location.Y > 10 || e.Location.Y < Height - 10)) // 西
            {
                Cursor = Cursors.SizeWE;
                direction = MouseDirection.West;
            }
            else if ((e.Location.X > Width - 10) && (e.Location.Y > 10 || e.Location.Y < Height - 10)) // 东
            {
                Cursor = Cursors.SizeWE;
                direction = MouseDirection.East;
            }
            else if ((e.Location.Y < 10) && (e.Location.X > 10 || e.Location.X < Width - 10)) // 北
            {
                Cursor = Cursors.SizeNS;
                direction = MouseDirection.North;
            }
            else if ((e.Location.Y > Height - 10) && (e.Location.X > 10 || e.Location.X < Width - 10)) // 南
            {
                Cursor = Cursors.SizeNS;
                direction = MouseDirection.South;
            }
            else
            {
                Cursor = Cursors.Default;
                direction = MouseDirection.None;
            }

        }

        private void OutSubtitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = false;
                reSize = false;
                mouseDownPoint.X = 0;
                mouseDownPoint.Y = 0;
            }
        }

        private void Relocation() // 改变位置的方法 parameter 是父控件的location
        {
            Cursor = Cursors.SizeAll;
            Left += MousePosition.X - mouseDownPoint.X;
            Top += MousePosition.Y - mouseDownPoint.Y;
            mouseDownPoint.X = MousePosition.X;
            mouseDownPoint.Y = MousePosition.Y;
        }

        private void ResizeControl(Point p) // 改变大小的方法
        {
            Point mousePosition = PointToScreen(p); //鼠标在相对屏幕的位置
            Point location = Location;
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            
            if(direction==MouseDirection.EastSouth)
            {
                Cursor = Cursors.SizeNWSE;
                Width = mousePosition.X - Left;
                Height = mousePosition.Y - Top;
                if(mousePosition.X-Left <= 10) // 向左拖动只能拖到Left+20
                {
                    mousePosition.X = Left + 20;
                    Width = 20;
                }
                if(mousePosition.Y-Top <= 20)
                {
                    mousePosition.Y = Top + 20;
                    Height = 20;
                }
            }
            else if(direction==MouseDirection.East)
            {
                Cursor = Cursors.SizeWE;
                if (mousePosition.X - Left <= 10) // 向左拖动只能拖到Left+20
                {
                    mousePosition.X = Left + 20;
                    Width = 20;
                }
                Width = mousePosition.X - Left;
            }
            else if (direction == MouseDirection.South)
            {
                Cursor = Cursors.SizeNS;
                if (mousePosition.Y - Top <= 10)
                {
                    mousePosition.Y = Top + 20;
                    Height = 20;
                }
                Height = mousePosition.Y - Top;
            }
        }

        private void OutSubtitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }

}
