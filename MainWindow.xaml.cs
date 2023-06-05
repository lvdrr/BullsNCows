using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;

namespace BikiIKorovi
{
    public partial class MainWindow : Window
    {
        public string Name;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (Nickname.Text == string.Empty)
            {
                MessageBox.Show("Введите имя!", "Упс!",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            else
            {
                Name = Nickname.Text;
                Window1 Game = new Window1(Name);
                Game.Show();
                Close();
            }
        }


        private void Nickname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Greeting_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("help.chm");
            }
        }
    }
}
