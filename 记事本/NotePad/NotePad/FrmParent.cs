using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class FrmParent : Form
    {
        public FrmParent()
        {
            InitializeComponent();
        }
        //新建
        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            //实例化一个子窗体对象
            FrmChild child = new FrmChild();
            //设置子窗体的父窗体
            child.MdiParent = this;
            //打开子窗体
            child.Show();
        }
        //关闭
        private void ToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Form frm = this.ActiveMdiChild;
            frm.Close();
        }
        //关闭全部(MdiChildren:子窗体的数组集合。ActiveMdiChild:当前活动的子窗体)
        private void ToolStripMenuItemCloseAll_Click(object sender, EventArgs e)
        {
            //this.MdiChildren获取父窗体的子窗体集合
            foreach (var item in this.MdiChildren)
            {
                //Form frm = this.ActiveMdiChild;
                //frm.Close();
                this.ActiveMdiChild.Close();
            }
        }
        //退出
        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
