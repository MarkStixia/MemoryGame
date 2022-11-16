using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace MemoryGame
{
    public partial class MainWindow : Window
    {
        private List<int> CurrentArray = new List<int>();
        private List<int> InputArray = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            NewColor();
            ShowArray();
            ButtonDefence.Visibility = Visibility.Hidden;
        }
        private void NewColor()
        {
            Random rnd = new Random();
            CurrentArray.Add(rnd.Next(0,4));
        }
        private async void ShowArray()
        {
            ButtonDefence.Visibility = Visibility.Visible;
            foreach (var item in CurrentArray)
            {
                await Task.Delay(300);
                switch(item)
                {
                    case 0:
                        SetColor(Button1, Color.FromRgb(255, 0, 0));
                        await Task.Delay(500);
                        SetColor(Button1, Color.FromRgb(212, 175, 175));
                        break;
                    case 1:
                        SetColor(Button2, Color.FromRgb(255, 255, 0));
                        await Task.Delay(500);
                        SetColor(Button2, Color.FromRgb(203, 204, 175));
                        break;
                    case 2:
                        SetColor(Button3, Color.FromRgb(0, 255, 0));
                        await Task.Delay(500);
                        SetColor(Button3, Color.FromRgb(177, 204, 175));
                        break;
                    case 3:
                        SetColor(Button4, Color.FromRgb(0, 0, 255));
                        await Task.Delay(500);
                        SetColor(Button4, Color.FromRgb(175, 199, 204));
                        break;
                }
            }
            ButtonDefence.Visibility = Visibility.Hidden;
        }
        private void SetColor(Button button, Color color)
        {
            SolidColorBrush brush = new SolidColorBrush(color);
            button.Background = brush;
        }
        private void Check()
        {
            for (int i = 0; i < InputArray.Count; i++)
            {
                if (CurrentArray[i] != InputArray[i])
                {
                    ReloadGame();
                    return;
                }
            }
            if (InputArray.Count == CurrentArray.Count)
            {
                NewColor();
                ShowArray();
                InputArray.Clear();
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
                InputArray.Add(int.Parse(((Button)sender).Uid));
                Check();
        }
        private async void ReloadGame()
        {
            Button1.Background = new SolidColorBrush(Color.FromRgb(212, 175, 175));
            Button2.Background = new SolidColorBrush(Color.FromRgb(203, 204, 175));
            Button3.Background = new SolidColorBrush(Color.FromRgb(177, 204, 175));
            Button4.Background = new SolidColorBrush(Color.FromRgb(175, 199, 204));
            MessageBox.Show("Вы проиграли, счет " + CurrentArray.Count);
            CurrentArray.Clear();
            InputArray.Clear();
            await Task.Delay(300);
            NewColor();
            ShowArray();
        }
    }
}
