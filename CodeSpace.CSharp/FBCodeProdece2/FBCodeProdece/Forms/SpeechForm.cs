using FBCodeProduce.Forms.basic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBCodeProduce.Forms
{
    public partial class SpeechForm : BaseForm
    {
        public SpeechForm()
        {
            InitializeComponent();
        }

        private void btn_speak_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            // 语速[-10,10]
            speech.Rate = -2;
            // 音量[0,100]
            //this.speech.Volume = 100
            // 播放当前时间
            string val = tb_val.Text;
            // 这里使用异步播放. 同步播放时,会卡死窗体(如果用WINFORM)
            speech.SpeakAsync(val);
            // 播放完毕之后,执行一个方法
            speech.SpeakCompleted += Speech_SpeakCompleted;
        }

        private void Speech_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
