using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

/*
#include<>
int main(){
    char a;
    int a=1213234;
    string str="abcsafdsad112dsfhk";
    if(){}else{}
    while(){}
    do{}while();
    for(int i=1;){}
}
*/


            string str = richTextBox1.Text;
            string patternKeyWord = @"\bint\b|\bchar\b|\bif\b|\belse\b|\bwhile\b|\bdo\b|\bfor\b";//匹配关键字
            string patternC = @"/\*(\n|.)*\*/";//匹配注释
            string patternStr = @""".*""";//匹配字符串常量
            string patternNum = @"\b\d+\b";//匹配数字常量
            string patternY = @"#.*";//匹配预编译指令

            

            Regex r = new Regex(patternKeyWord, RegexOptions.IgnoreCase);//匹配关键字
            Match m = r.Match(str);
            int ct = 0;
            while (m.Success)
            {
                ct++;
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.Blue;
                }

                for (int i = 0; i < m.Groups.Count; i++)
                {
                    Group group = m.Groups[i];
                    for (int j = 0; j < group.Captures.Count; j++)
                    {
                        Capture capture = group.Captures[j];
                    }
                }
                m = m.NextMatch();
            }

            r = new Regex(patternC, RegexOptions.IgnoreCase);//匹配注释
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.DarkGreen;
                }
                m = m.NextMatch();
            }

            r = new Regex(patternStr, RegexOptions.IgnoreCase);//匹配字符串常量
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.DeepPink;
                }
                m = m.NextMatch();
            }

            r = new Regex(patternNum, RegexOptions.IgnoreCase);//匹配数字常量
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.Purple;
                }
                m = m.NextMatch();
            }

            r = new Regex(patternY, RegexOptions.IgnoreCase);//匹配预编译指令
            m = r.Match(str);
            while (m.Success)
            {
                CaptureCollection cc = m.Captures;
                foreach (Capture c in cc)
                {
                    richTextBox1.Select(c.Index, c.Length);
                    richTextBox1.SelectionColor = Color.Red;
                }
                m = m.NextMatch();
            }
        }
    }
}
