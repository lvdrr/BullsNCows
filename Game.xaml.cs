using System;
using System.Windows;
using System.IO;
using System.Windows.Input;
using System.Linq;
using System.Windows.Forms;

namespace BikiIKorovi
{
    public partial class Window1 : Window
    {
        string Name;
        static Random rand = new Random();
        static string randNum;
        static int statvis = 1;
        static string numarray;
        static string yourNum;
        public Window1(string Name)
        {
            InitializeComponent();
            this.Name = Name;
            System.Windows.MessageBox.Show($"Привет, {Name}, это игра \"Быки и коровы\"!");
        }
        public int atts = 0;
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            statvis++;
            if (statvis % 2 == 0)
            {
                Statistika.Visibility = Visibility.Visible;
            }
            else
            {
                Statistika.Visibility = Visibility.Hidden;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult newgame = System.Windows.MessageBox.Show("Вы хотите начать новую игру?", "Новая игра",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (newgame == MessageBoxResult.Yes)
            {
                MainWindow NewGame = new MainWindow();
                NewGame.Show();
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Продолжаем играть!", "Ура! :)");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult exit = System.Windows.MessageBox.Show("Вы хотите выйти?", "Выход",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (exit == MessageBoxResult.Yes)
            {
                System.Windows.MessageBox.Show("Выход из программы...", "Грустно... :'(");
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Продолжаем играть!", "Ура! :)");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            randNum = Convert.ToString(rand.Next(1000, 9999));
            numarray = randNum[0].ToString() + randNum[1] + randNum[2] + randNum[3];
            vivod_chisla.Text = randNum;
            vivod_chisla.Text = null;
            for (int i = 0; i < randNum.Length; i++)
            {
                vivod_chisla.Text += "*";
            }
        }

        private void guess_Click(object sender, RoutedEventArgs e)
        {
            if (number.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("Введите число!", "Упс!",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (number.Text.Length != 4)
            {
                System.Windows.MessageBox.Show("Число должно быть четырехзначным!", "Введите четырехзначное число!",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            int bulls = 0;
            int cows = 0;
            yourNum = number.Text;
            char[] ch = number.Text.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                if (numarray.Contains(ch[i]))
                {
                    if (numarray[i] == ch[i])
                    {
                        bulls++;
                    }
                    else
                    {
                        cows++;
                    }
                }
            }
            atts++;
            System.Windows.MessageBox.Show($"В введенном числе {yourNum}: быков: {bulls}, коров: {cows}");
            if (randNum == number.Text)
            {
                System.Windows.MessageBox.Show($"Поздравляю, ты угадал число {randNum} за {atts} попыток!", "Молодец!");
                vivod_chisla.Text = randNum;
                using (StreamWriter sw = new StreamWriter("Stats.txt", true))
                {
                    sw.WriteLine(Name + ", " + "загаданное число: " + vivod_chisla.Text + "угадано за " + atts + "попыток.");
                    Statistika.Items.Add(Name + ", " + "загаданное число: " + vivod_chisla.Text + " угадано за " + atts + " попыток.");
                }
            }
        }

        private void Spravka_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Компьютер генерирует случайное четырехзначное число (нули включены).\nВаша задача - его угадать.\nЕсли вы угадываете цифру и её позицию - получаете одного быка.\nЕсли позиция неверная, но цифра присутствует в четырёхзначном числе — получаете одну корову.", "Справка об игре.");
        }

        private void Game_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Help.ShowHelp(null, "help.chm");
            }
        }
    }
}