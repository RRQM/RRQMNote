using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRQMMVVM;

namespace ViewModels.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.NewCreatNoteCommand = new ExecuteCommand(NewCreatNote);
            this.SettingPageCommand = new ExecuteCommand(SettingPage);
        }

        #region 变量（Variable）

        #endregion

        #region 命令（Command）
        public ExecuteCommand NewCreatNoteCommand { get; set; }
        public ExecuteCommand SettingPageCommand { get; set; }
        #endregion

        #region 属性（Attribute）

        #endregion

        #region 公共方法（publicMethod）

        #endregion

        #region 私有方法（PrivateMethod）
        private void NewCreatNote()
        {
            Messenger.Default.Send("NewCreatNote");
        }

        private void SettingPage()
        {
            Messenger.Default.Send("ShowSettingPage");
        }
        #endregion

        #region 事件方法（EventMethod）

        #endregion
    }
}
