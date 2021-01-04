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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RRQMSkin;
using Views;

namespace ClientGUI
{
    /// <summary>
    /// NoteWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NoteWindow : RRQMWindow
    {
        public NoteWindow()
        {
            InitializeComponent();
            this.Deactivated += this.NoteWindow_Deactivated;
            this.Activated += this.NoteWindow_Activated;

            this.SizeChanged += this.NoteWindow_SizeChanged;
        }

      
        private void NoteWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.Width < 400)
            {
                this.menuPanel.IsDockShow(false);
            }
            else
            {
                this.menuPanel.IsDockShow(true);
            }

        }

        private void NoteWindow_Activated(object sender, EventArgs e)
        {
            if (this.header != null)
            {
                ThicknessAnimation animation = new ThicknessAnimation();
                animation.To = new Thickness(0);
                animation.Duration = TimeSpan.FromSeconds(0.3);
                header.BeginAnimation(MarginProperty, animation);

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.To = 1;
                doubleAnimation.Duration = TimeSpan.FromSeconds(0.3);
                this.bottomToolBar.BeginAnimation(OpacityProperty, doubleAnimation);
            }
        }

        private void NoteWindow_Deactivated(object sender, EventArgs e)
        {
            if (this.header != null)
            {
                this.menuPanel.IsOpen = false;

                ThicknessAnimation animation = new ThicknessAnimation();
                animation.To = new Thickness(0, -100, 0, 0);
                animation.Duration = TimeSpan.FromSeconds(0.3);
                header.BeginAnimation(MarginProperty, animation);

                DoubleAnimation doubleAnimation = new DoubleAnimation();
                doubleAnimation.To = 0;
                doubleAnimation.Duration = TimeSpan.FromSeconds(0.3);
                this.bottomToolBar.BeginAnimation(OpacityProperty, doubleAnimation);
            }
        }

        private Grid header;
        private Grid contentGrid;
        private Border bottomToolBar;
        private MenuPanel menuPanel;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            header = (Grid)this.Template.FindName("header", this);
            contentGrid = (Grid)this.Template.FindName("contentGrid", this);
            bottomToolBar = (Border)this.Template.FindName("bottomToolBar", this);
            menuPanel = (MenuPanel)this.Template.FindName("menuPanel", this);

            this.contentGrid.PreviewMouseDown += this.ContentGrid_PreviewMouseDown;
        }

        private void ContentGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.menuPanel.IsOpen = false;
        }
    }
}
