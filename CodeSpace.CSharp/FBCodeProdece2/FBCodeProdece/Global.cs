﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBCodeProduce
{
    public static class Global
    {
        public readonly static string USER_SETTING_PATH = Application.StartupPath + "\\UserSetting.json";
        public readonly static string APP_SETTING_PATH = Application.StartupPath + "\\AppSetting.json";
    }
}
