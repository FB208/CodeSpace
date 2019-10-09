using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP.Client.TCP
{
    public partial class CreateListener : Form
    {
        public CreateListener()
        {
            InitializeComponent();
        }

        private void Btn_Create_Click(object sender, EventArgs e)
        {
            bool result = true;
            int port = 0;
            result = int.TryParse(tb_port.Text, out port);
            if (!result)
            {
                MessageBox.Show("请输入正确的端口");
            }
            TCP.ListenerView form = new ListenerView(tb_ip.Text, port);
            form.Show();
            //Action action = new Action(() => Create(tb_ip.Text,port));
            //action.BeginInvoke(null, null);

            this.Hide();
        }
        void Create(string ip,int port)
        {
            TCP.ListenerView form = new ListenerView(tb_ip.Text, port);
            form.Show();
        }
    }
}
