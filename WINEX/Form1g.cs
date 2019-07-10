using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINEX {
    public partial class Form1g : Form {
        int x, y;
        bool f = true;
        private Point rect1;

        public Form1g( ) {
            InitializeComponent();
            checkBox1.Checked = true;
            f = false;
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            string s = tabPage1.Text;
            string t = tabControl1.SelectedTab.Text;
            
            int i = tabControl1.SelectedIndex;
            //     tabPage1 =  TabPage.TabPageControlCollection;
            if (!f) {
                checkBox1.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            
            x = Convert.ToInt32( textBox1.Text );  
            y = Convert.ToInt32( textBox2.Text );
            pictureBox1.Invalidate();           //刷新 pictureBox图  要是只有这句话 还要重写OnPaint方法
            //pictureBox1.Load("tt.bmp");       //重新加载图片  图片位置在bin中
            pictureBox1.Update();             //这句话相当关键  会是消除之前画的图 速度加快
                                              //         pictureBox1_ht();

            SolidBrush mysbrush1 = new SolidBrush( Color.DarkOrchid );
            Graphics g = pictureBox1.CreateGraphics();
            Pen m_Pen = new Pen( Color.Blue, 1 );

       //     g.DrawLine( m_Pen, 20, 20, 21, 21 );
       //     g.FillEllipse( mysbrush1, 30, 50, 40, 80 );
       //     画圆圈：
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen( Color.Red );//画笔颜色                                
    //        g.DrawEllipse( pen, 10, 10, 2,2 );//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
            x = 1;y = 1;
            for (int i = 0; i < 80; i++) {
                g.DrawEllipse( pen, x, y, 10, 10 );
                x=x+3; y = y+3;
            }

            Font myFont = new Font( "宋体", 10, FontStyle.Bold );    //      写字：
            Brush bush = new SolidBrush( Color.Red );               //填充的颜色
           //    g.DrawString( "堵塞！", myFont, bush, 100, 100 );

 //-------------------------Bitmap---------------------------------------------------------------
            int pHeight = pictureBox2.Height; label1.Text = pHeight.ToString();
            int pWidth = pictureBox2.Width; label2.Text = pWidth.ToString();
            Bitmap myBitmap = new Bitmap( pWidth, pHeight ); //"Grapes.jpg"
            pictureBox2.Image = myBitmap;

            x = 1; y = 1;
            for (int i = 0; i < 120; i++) {
                myBitmap.SetPixel( x, y, Color.Red );
                x++; y++;
            }
            #region 画不同椭圆的 画刷 种类


            //    Rectangle myrect1 = new Rectangle( 20, 80, 250, 100 );
            //         SolidBrush mysbrush2 = new SolidBrush( Color.Aquamarine );
            //    SolidBrush mysbrush3 = new SolidBrush( Color.DarkOrange );

            //    //(梯度刷)
            ////     LinearGradientBrush mylbrush5 = new LinearGradientBrush( rect1,                    Color.DarkOrange, Color.Aquamarine, LinearGradientMode.BackwardDiagonal );

            //    //(阴影刷)
            //    HatchBrush myhbrush5 = new HatchBrush( HatchStyle.DiagonalCross,
            //    Color.DarkOrange, Color.Aquamarine );
            //    HatchBrush myhbrush2 = new HatchBrush( HatchStyle.DarkVertical,
            //    Color.DarkOrange, Color.Aquamarine );
            //    HatchBrush myhbrush3 = new HatchBrush( HatchStyle.LargeConfetti,
            //    Color.DarkOrange, Color.Aquamarine );

            //    //(纹理刷)
            //    TextureBrush textureBrush = new TextureBrush( new Bitmap( @"c:\gxh.jpg" ) );
            //    //         e.Graphics.FillRectangle( mysbrush1, rect1 );         // (实心刷)
            //    //         e.Graphics.FillRectangle( mylbrush1, rect1 );            //(梯度刷)

            //    //         e.Graphics.FillRectangle( myhbrush1, rect1 );             //(阴影刷)      
            //    //         e.Graphics.FillRectangle( mytextureBrush, rect1 );       //(纹理刷)
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e) {
            button2_Click( null, null );
        }

        public void pictureBox1_ht( )//画图的简单方法
        {
            // (实心刷)
            SolidBrush mysbrush1 = new SolidBrush( Color.DarkOrchid );
            Graphics g = pictureBox1.CreateGraphics();

            g.DrawLine( new Pen( Color.Red, 2 ), x, 20, y, 40 );
            g.FillEllipse( mysbrush1, x, 50, y, 140 );
        }


    }
}
