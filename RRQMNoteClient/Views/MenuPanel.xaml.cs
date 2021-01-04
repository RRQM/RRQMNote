using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Views
{
    /// <summary>
    /// MenuPanel.xaml 的交互逻辑
    /// </summary>
    public partial class MenuPanel : Grid
    {
        public MenuPanel()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

        }

        public bool? IsOpen
        {
            get { return (bool?)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool?), typeof(MenuPanel), new PropertyMetadata(null, IsOpenChanged));

        private static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MenuPanel menuPanel = (MenuPanel)d;
            if (menuPanel.IsOpen==true)
            {
                ThicknessAnimation animation = new ThicknessAnimation();
                animation.To = new Thickness(0);
                animation.Duration = TimeSpan.FromSeconds(0.3);
                menuPanel.BeginAnimation(MarginProperty,animation);
            }
            else
            {
                ThicknessAnimation animation = new ThicknessAnimation();
                animation.To = new Thickness(0,-120,0,0);
                animation.Duration = TimeSpan.FromSeconds(0.3);
                menuPanel.BeginAnimation(MarginProperty, animation);
            }
        }

        public void IsDockShow(bool isDock)
        {
            if (isDock)
            {
               
                this.Width = 250;
                this.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                this.Width = double.NaN;
               
                this.Width = double.NaN;
                this.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
        }
    }
}
