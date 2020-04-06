using FBCodeProduce.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBCodeProduce.Forms.basic
{
    public partial class BaseForm : Form
    {
        public JToken appSetting;
        public JToken userSetting;
        public BaseForm()
        {
            appSetting = NewtonjsonHelper.ReadFile(@"D:\CodeSpace\Git\CodeSpace.CSharp\FBCodeProdece2\FBCodeProdece\AppSetting.json");
            userSetting = NewtonjsonHelper.ReadFile(@"D:\CodeSpace\Git\CodeSpace.CSharp\FBCodeProdece2\FBCodeProdece\UserSetting.json");
        }
    }
}
