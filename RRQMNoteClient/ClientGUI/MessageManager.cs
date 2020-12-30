using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using RRQMMVVM;

namespace ClientGUI
{
    public class MessageManager : IMessageManager
    {

        [RegistMethod]
        public void NewCreatNote()
        {
            WindowsManager.CreatWindow(typeof(NoteWindow));
        }


        [RegistMethod]
        public void ShowSettingPage()
        {
            MainWindow.NavigationService.Navigate(new Uri("SettingPage.xaml", UriKind.Relative));
        }
    }
}
