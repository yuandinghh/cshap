using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WINEX {
    public partial class Form1 : Form {
        bool boolt = true;
        public Form1( ) {
            InitializeComponent();
            button1.Text = "点击开始测试";
            this.Text = "多线程范例";
        }

        private void button1_Click(object sender, EventArgs e) {
            new Thread( ThreadProc ).Start();   //启动一个线程
        }

        public void ThreadProc( ) {       //this.Invoke就是跨线程访问ui的方法，也是本文的范例  
            this.Invoke( (EventHandler)delegate {   //首先invoke一个匿名委托，将button1对象禁用  
                button1.Enabled = false;
            } );
            int tick = Environment.TickCount;     //记录一个时间戳，以演示倒计时效果  
            this.Invoke( (EventHandler)delegate {   //调用主进程的 控件要 委托
                textBox1.Text = Environment.CommandLine;  //获取命令行
                textBox2.Text = Environment.CurrentDirectory;  //获取或设置当前工作目录的完全限定路径。
                textBox3.Text = Environment.SystemDirectory;
            } );
            while (Environment.TickCount - tick < 5000) {
                //跨线程调用更新窗体上控件的属性，这里是更新这个按钮对象的Text属性  
                this.Invoke( (EventHandler)delegate {
                    textBox4.Text = (5000 - Environment.TickCount + tick).ToString() + "微秒后开始更新";
                } );
                //做一个延迟，避免太快了，视觉效果不好。  
                Thread.Sleep( 200 );
            }
            //演示，10次数字递增显示  
            for (int i = 0; i < 10; i++) {
                this.Invoke( (EventHandler)delegate {
                    textBox5.Text = i.ToString();
                } );
                Thread.Sleep( 500 );
            }
          //虽然不是循环内，请不要忘记，你的调用依然在辅助线程中，所以，还是需要invoke的。  
            //还原状态，设置按钮的文本为初始状态，设置按钮可用。  
            this.Invoke( (EventHandler)delegate {
                button1.Text = "点击开始测试";
                button1.Enabled = true;
            } );
        }

        private void button2_Click(object sender, EventArgs e) {
            boolt = !boolt;
            checkBox1.Checked = boolt;
            button2.Text = "run......";
        }
    }
//作者：偏执灬 //来源：CSDN
//原文：https://blog.csdn.net/sinat_23338865/article/details/52587505 
  
}
