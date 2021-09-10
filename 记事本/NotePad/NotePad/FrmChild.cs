using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections;
using System.IO;

namespace NotePad
{
    public partial class FrmChild : Form
    {
        //通过FontStyle中的Enum创建
        FontStyle allButBoldstyle = FontStyle.Italic | FontStyle.Regular | FontStyle.Strikeout | FontStyle.Underline;
        FontStyle allButItalicstyle = FontStyle.Bold | FontStyle.Regular | FontStyle.Strikeout | FontStyle.Underline;

        public FrmChild()
        {
            InitializeComponent();
        }


        //窗体加载事件
        private void FrmChild_Load(object sender, EventArgs e)
        {
            //窗体加载时，要加载系统字体
            InstalledFontCollection myFonts = new InstalledFontCollection();
            //获取InstalledFontCollection对象的数组
            FontFamily[] ff = myFonts.Families;
            //声明一个ArrayList变量(数组可动态增减)
            ArrayList list = new ArrayList();
            //获取系统数组的列表中集合的长度
            int count = ff.Length;
            //用for循环把字体名称写入toolStripComboBoxFonts控件中
            for (int i = 0; i < count; i++)
            {
                string FontName = ff[i].Name;
                toolStripComboBoxFonts.Items.Add(FontName);
            }
        }
        //加粗按钮
        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            
            if (textBoxNote.Font.Bold)            //取消加粗(其中textBoxNote.Font.Style为当前文本字体的样式)
            {
              //  textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Regular & textBoxNote.Font.Style);
                textBoxNote.Font = new Font(textBoxNote.Font, allButBoldstyle & textBoxNote.Font.Style);

            }
            else                                        //设置加粗
            {
                textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Bold | textBoxNote.Font.Style);

            }

        }
        //斜体按钮
        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            if (textBoxNote.Font.Italic)            //取消斜体
            {
                // textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Regular & textBoxNote.Font.Style);
                textBoxNote.Font = new Font(textBoxNote.Font, allButItalicstyle & textBoxNote.Font.Style);
            }
            else                                        //设置斜体
            {
                textBoxNote.Font = new Font(textBoxNote.Font, FontStyle.Italic | textBoxNote.Font.Style);

            }

        }
        //改变选择字体的索引事件
        private void toolStripComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName = toolStripComboBoxFonts.Text;      //字体
            float fontSize = float.Parse(toolStripComboBoxSize.Text); //大小
            textBoxNote.Font = new Font(fontName, fontSize,textBoxNote.Font.Style);
        }
        //改变字体大小
        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName = toolStripComboBoxFonts.Text;
            float fontSize = float.Parse(toolStripComboBoxSize.Text);
            textBoxNote.Font = new Font(fontName, fontSize,textBoxNote.Font.Style);
        }
        //自己编写字体大小
        private void toolStripComboBoxSize_TextChanged(object sender, EventArgs e)
        {
            string fontName = toolStripComboBoxFonts.Text;
            float fontSize = float.Parse(toolStripComboBoxSize.Text);
            textBoxNote.Font = new Font(fontName, fontSize, textBoxNote.Font.Style);
        }
        //保存文档
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNote.Text.Trim()!="")     //文本框不为空
            {
                //保存文件时，清空记号
                toolStripLabelMake.Text = "";
                if (this.Text =="记事本")          //自己新建的记事本
                {
                    //新建一个保存文件的对话框
                    //创建一个筛选器/过滤器
                    saveFileDialog1.Filter = ("文本文档(*. txt)|*.txt");
                    //判断点击的是保存按钮还是取消
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //保存文件到用户指定的目录位置
                        //获取用户选择的文件及路径
                        string path = saveFileDialog1.FileName;
                        //保存文件到指定路径
                        StreamWriter sw = new StreamWriter(path, false);//缓存至该文件中
                        sw.WriteLine(textBoxNote.Text.Trim());          //将文本框的内容写进sw文件
                        //将窗体text属性设置为保存后的文件路径
                        this.Text = path;
                        sw.Flush();                                     //清空缓存
                        sw.Close();
                    }
                }
                else                                 //是打开的记事本而不是自己新建的
                {
                    //保存文件到用户指定的目录位置
                    //获取用户选择的文件及路径
                    string path = this.Text;
                    //保存文件到指定路径
                    StreamWriter sw = new StreamWriter(path, false);//缓存至该文件中
                    sw.WriteLine(textBoxNote.Text.Trim());          //将文本框的内容写进sw文件
                    sw.Flush();                                     //清空缓存
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("空文档不能保存", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //打开文件
        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            //新建一个保存文件的对话框
            //创建一个筛选器/过滤器
            openFileDialog1.Filter = ("文本文档(*.txt)|*.txt");
            //判断用户点开的是打开按钮还是取消按钮
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                //获取打开文件的路径
                string path = openFileDialog1.FileName;
                //通用编码UTF8
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                //读取文档中的数据流
                string text = sr.ReadToEnd();
                textBoxNote.Text = text;
                //将打开的文件路径写到当前窗体的text属性中（文本的左上角）
                this.Text = path;           
                //打开文件时，清空记号
                toolStripLabelMake.Text = "";

                sr.Close();
            }
        }
        //编辑文本时，写上记号*
        private void textBoxNote_TextChanged(object sender, EventArgs e)
        {
            toolStripLabelMake.Text = "*";
        }
        //窗体关闭事件
        private void FrmChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            //判断文本是否编辑过（即记号是否为*）
            if (toolStripLabelMake.Text == "*")
            {
                //提示用户尚未保存
                DialogResult dr= MessageBox.Show("文件尚未保持，是否继续退出", "信息询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    this.Dispose();       //释放所有资源（即关闭文本）  
                }
                else            
                {
                    e.Cancel = true;   //取消关闭
                }
            }
        }
        //新建按钮
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            textBoxNote.Text = "";           //文本框清空
            toolStripLabelMake.Text = "";    //标记清空
            this.Text = "";
        }
    }
}
