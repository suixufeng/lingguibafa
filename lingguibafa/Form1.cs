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
using Timer = System.Windows.Forms.Timer;

namespace lingguibafa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(getXue);//添加事件
          //  getXue();

        }
      
        
        private void  getXue(object source, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
            ChineseDateTime cd = new ChineseDateTime(DateTime.Now);
            label1.Text = cd.ToChineseEraString();
            //定义一个键值对集合，取除数 { "甲":9,"丙":9,"乙":6,"戊":9,"庚":9,"辛":6,"壬":9,"丁":6,"己":6,"癸":6};

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //添加键值对数据,键必须唯一,值可重复
            dictionary.Add("甲", 9);
            dictionary.Add("丙", 9);
            dictionary.Add("戊", 9);
            dictionary.Add("庚", 9);
            dictionary.Add("壬", 9);
            dictionary.Add("乙", 6);
            dictionary.Add("辛", 6);
            dictionary.Add("丁", 6);
            dictionary.Add("己", 6);
            dictionary.Add("癸", 6);
            //---------------------------------日干支
            string riganzhi = cd.GetEraDay();
            int chunum = dictionary[riganzhi.Substring(0, 1)]; //根据日干计算为阳日还是阴日，阳日/9，阴日/6

            // 定义一个键值对集合，取日干值 { "甲":10,"己":10,"乙":9,"丙":7,"庚":9,"丁":8,"辛":7,"壬":8,"戊":7,"癸":7}
            Dictionary<string, int> dicRigan = new Dictionary<string, int>();
            //添加键值对数据,键必须唯一,值可重复
            dicRigan.Add("甲", 10);
            dicRigan.Add("丙", 7);
            dicRigan.Add("戊", 7);
            dicRigan.Add("庚", 9);
            dicRigan.Add("壬", 8);
            dicRigan.Add("乙", 9);
            dicRigan.Add("辛", 7);
            dicRigan.Add("丁", 8);
            dicRigan.Add("己", 10);
            dicRigan.Add("癸", 7);

            int rigannum = dicRigan[riganzhi.Substring(0, 1)];//取日干数值



            // 定义一个键值对集合，取日支值 日支查询表{ "丑":10,"寅":8,"辰":10,"戌":10,"子":7,"酉":9,"未":10,"申":9,"卯":8,"巳":7,"午":7,"亥":7}
            Dictionary<string, int> dicRizhi = new Dictionary<string, int>();
            //添加键值对数据,键必须唯一,值可重复
            dicRizhi.Add("丑", 10);
            dicRizhi.Add("寅", 8);
            dicRizhi.Add("辰", 10);
            dicRizhi.Add("戌", 10);
            dicRizhi.Add("子", 7);
            dicRizhi.Add("酉", 9);
            dicRizhi.Add("未", 10);
            dicRizhi.Add("申", 9);
            dicRizhi.Add("卯", 8);
            dicRizhi.Add("巳", 7);
            dicRizhi.Add("午", 7);
            dicRizhi.Add("亥", 7);
            int rizhinum = dicRizhi[riganzhi.Substring(1, 1)];//取日支数值

            //---------------------------------时干支
            string shiganzhi = cd.GetEraHour();


            //int shigan = dicRizhi[shiganzhi.Substring(0, 1)];//取时干数值


            // 定义一个键值对集合，取时干值 {"甲":9,"己":9,"乙":8,"丙":7,"庚":8,"壬":6,"辛":7,"丁":6,"戊":5,"癸":5}
            Dictionary<string, int> dicshigan = new Dictionary<string, int>();
            //添加键值对数据,键必须唯一,值可重复
            dicshigan.Add("甲", 9);
            dicshigan.Add("丙", 7);
            dicshigan.Add("戊", 5);
            dicshigan.Add("庚", 8);
            dicshigan.Add("壬", 6);
            dicshigan.Add("乙", 8);
            dicshigan.Add("辛", 7);
            dicshigan.Add("丁", 6);
            dicshigan.Add("己", 9);
            dicshigan.Add("癸", 5);

            int shigannum = dicshigan[shiganzhi.Substring(0, 1)];//取时干数值

            // 定义一个键值对集合，取时支值 时支查询表{"酉":6,"未":8,"子":9,"申":7,"午":9,"丑":8,"辰":5,"寅":7,"卯":6,"戌":5,"巳":4,"亥":4}
            Dictionary<string, int> dicshizhi = new Dictionary<string, int>();
            //添加键值对数据,键必须唯一,值可重复
            dicshizhi.Add("丑", 8);
            dicshizhi.Add("寅", 7);
            dicshizhi.Add("辰", 5);
            dicshizhi.Add("戌", 5);
            dicshizhi.Add("子", 9);
            dicshizhi.Add("酉", 6);
            dicshizhi.Add("未", 8);
            dicshizhi.Add("申", 7);
            dicshizhi.Add("卯", 6);
            dicshizhi.Add("巳", 4);
            dicshizhi.Add("午", 9);
            dicshizhi.Add("亥", 4);
            int shizhinum = dicshizhi[shiganzhi.Substring(1, 1)];//取时支数值

            //计算公式：  （日干 + 日支 + 时干 + 时支）÷9（阳日）或÷6（阴日）= 商……余数

            int yu = ((rigannum + rizhinum + shigannum + shizhinum) % chunum);
            if (yu == 0)
            {
                yu = chunum;

            }
           
            // int yu = 5;
            //配穴数值 1代表申脉，2代表照海穴，3代表外关，4代表足临泣，5男子取照海 | 女子取内关，余数6取公孙，7取后溪，8取内关。 
            Dictionary<int, string> dicxue = new Dictionary<int, string>();
            //添加键值对数据,键必须唯一,值可重复
            dicxue.Add(1, "申脉");
            dicxue.Add(2, "照海");
            dicxue.Add(3, "外关");
            dicxue.Add(4, "临泣");
            dicxue.Add(5, "男子取照海 | 女子取内关");
            dicxue.Add(6, "公孙");
            dicxue.Add(7, "后溪");
            dicxue.Add(8, "内关");
            if (yu == 5)
            {
                label8.Text = "余数为5，请选择 男/女";
                if (radioButton1.Checked == true)
                {
                    dicxue[5] = "照海";//索引方式赋值，没有则新增，有则修改
                }
                else
                {
                    dicxue[5] = "内关";//索引方式赋值，没有则新增，有则修改
                }
            }
            string xue1 = dicxue[yu];//取第一个穴位
            label5.Text = xue1;
            //string xue = dicxue[shizhinum];//按照余数取穴

            //交经临泣穴--外关；后溪--申脉；公孙--外关；列缺--照海
            Dictionary<string, string> dicjiaojing = new Dictionary<string, string>();
            //添加键值对数据,键必须唯一,值可重复
            dicjiaojing.Add("临泣", "外关");
            dicjiaojing.Add("后溪", "申脉");
            dicjiaojing.Add("公孙", "内关");
            dicjiaojing.Add("列缺", "照海");

            dicjiaojing.Add("外关", "临泣");
            dicjiaojing.Add("申脉", "后溪");
            dicjiaojing.Add("内关", "公孙");
            dicjiaojing.Add("照海", "列缺");


            string xue2 = dicjiaojing[xue1];//对应取配穴
            label6.Text = xue2;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            getXue(null,null);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            getXue(null, null);
        }
    }
}
