using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModel;

namespace WpfApp.View.MainContent
{
    /// <summary>
    /// FirstPageView.xaml 的交互逻辑
    /// 用户自定义控件参考
    /// https://www.cnblogs.com/zhouyinhui/archive/2007/10/27/939920.html
    /// </summary>
    public partial class FirstPageView : UserControl
    {
        public FirstPageView()
        {
            InitializeComponent();
            this.DataContext = new FirstPageViewModel();
        }
    }
}
