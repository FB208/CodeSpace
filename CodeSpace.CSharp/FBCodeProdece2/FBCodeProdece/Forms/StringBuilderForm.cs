using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBCodeProduce.Forms
{
    public partial class StringBuilderForm : Form
    {
        public StringBuilderForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 清除SQL两侧的C#代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            string content = tb_content.Text;
            content = content.Replace(tb_sqlName.Text + ".Append(\"", "").Replace("\");", "");
            foreach (var item in list_replace.Items)
            {
                string oldS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[0];
                string newS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[1];
                content = content.Replace(oldS, newS);
            }
            tb_Result.Text = content;
        }
        /// <summary>
        /// 在SQL两侧添加StringBuilderC#代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string content = tb_content.Text;
            string result = "";
            string[] line = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < line.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(line[i].Trim()))
                {
                    continue;
                }
                if (line[i].Trim().IndexOf(@"--") == 0)
                {
                    result += line[i].Trim().Replace("--", "//") + " \r\n";
                    continue;
                }
                result = result + tb_sqlName.Text + ".Append(\" " + line[i].Trim() + " \");\r\n";

            }
            foreach (var item in list_replace.Items)
            {
                string oldS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[0];
                string newS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[1];
                result = result.Replace(oldS, newS);
            }
            tb_Result.Text = result;
            tb_old.Text = "";
            tb_new.Text = "";
        }
        /// <summary>
        /// 在SQL两侧添加StringBuilderC#代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_product_Click(object sender, EventArgs e)
        {
            string content = tb_content.Text;
            string result = "";
            string[] line = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < line.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(line[i].Trim()))
                {
                    continue;
                }
                if (line[i].Trim().IndexOf(@"--") == 0)
                {
                    result += line[i].Trim().Replace("--", "//") + " \r\n";
                    continue;
                }
                result = result + tb_sqlName.Text + ".Append(\" \".repeat(4) + $\" " + line[i].Trim() + " \\r\\n\");\r\n";

            }
            foreach (var item in list_replace.Items)
            {
                string oldS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[0];
                string newS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[1];
                result = result.Replace(oldS, newS);
            }
            tb_Result.Text = result;
            tb_old.Text = "";
            tb_new.Text = "";
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StringBuilderForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 添加替换项，一般用于将 @variable 替换成 "+variable+"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addReplace_Click(object sender, EventArgs e)
        {
            string text = tb_old.Text + "->" + tb_new.Text;
            ListViewItem lvi = new ListViewItem();
            lvi.Text = text;
            this.list_replace.Items.Add(lvi);
        }
        /// <summary>
        /// 鼠标选中listview中item,替换左侧文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_replace_MouseClick(object sender, MouseEventArgs e)
        {
            string text = list_replace.FocusedItem.Text;
            tb_old.Text = text.Split(new string[] { "->" }, StringSplitOptions.None)[0];
            tb_new.Text = text.Split(new string[] { "->" }, StringSplitOptions.None)[1];
        }
        /// <summary>
        /// 反转listview中的左右项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Turn_Click(object sender, EventArgs e)
        {
            list_replace.BeginUpdate();
            foreach (ListViewItem item in list_replace.Items)
            {
                string oldS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[0];
                string newS = ((ListViewItem)item).Text.Split(new string[] { "->" }, StringSplitOptions.None)[1];
                list_replace.Items.RemoveAt(item.Index);
                list_replace.Items.Add(new ListViewItem() { Text = newS + "->" + oldS });
            }
            list_replace.EndUpdate();
        }
        /// <summary>
        /// 删除listview中选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_deleteReplace_Click(object sender, EventArgs e)
        {
            this.list_replace.FocusedItem.Remove();
        }
        /// <summary>
        /// 全选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ctrl_A(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        
    }
}
