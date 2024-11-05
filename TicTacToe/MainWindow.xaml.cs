using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string next = "X";
		List<Button> buttons = new List<Button>();
		string Color_O = "Black";
		public MainWindow()
		{
			InitializeComponent();
			InitializeButtons();
		}

		private void InitializeButtons()
		{
			for (int sor = 0; sor < 3; sor++)
			{
				for (int oszlop = 0; oszlop < 3; oszlop++)
				{
					Button button = new Button();
					button.Click += Button_Click;
					button.FontSize = 70;
					button.Content = "";
					Grid.SetRow(button, sor);
					Grid.SetColumn(button, oszlop);
					GameGrid.Children.Add(button);
					buttons.Add(button);
				}
			}
		}

		private void ChangeNextValue()
		{
			if (next == "X")
			{
				next = "O";
			}
			else
			{
				next = "X";
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button.Content == "")
			{
				if (next == "O")
				{
					button.Content = next;
					button.Foreground = (Brush)new BrushConverter().ConvertFrom(Color_O);
					ChangeNextValue();
					RadioButtonX.IsChecked = true;
				}
				else
				{
					// Color_X
					button.Content = next;
					ChangeNextValue();
					RadioButtonO.IsChecked = true;
				}
			}
			CheckWin();
		}

		private void ListBox_SelectionChanged_O(object sender, SelectionChangedEventArgs e)
		{
			ListBox listBox = sender as ListBox;
			ListBoxItem listBoxItem = (listBox.SelectedItem as ListBoxItem);
			if (listBoxItem != null && listBoxItem.Content != null)
			{
				Color_O = listBoxItem.Content.ToString();
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			foreach (var button in buttons)
			{
				button.Content = "";
			}
		}

		private void RadioButton_Checked_O(object sender, RoutedEventArgs e)
		{
			next = "O";
		}

		private void RadioButton_Checked_X(object sender, RoutedEventArgs e)
		{
			next = "X";
		}

		private bool CheckEqual(Button button1, Button button2, Button button3)
		{
			if (button1.Content.ToString() == "")
			{
				return false;
			}
			return button1.Content == button2.Content && button2.Content == button3.Content;
		}

		private void NewGame_Click(object sender, RoutedEventArgs e)
		{
			foreach (var Button in buttons)
			{
				Button.Content = null;
			}
		}

		private void CheckWin()
		{
			//soronként
			for (int i = 0; i < 3; i++)
			{
				if (CheckEqual(buttons[i], buttons[i + 1], buttons[i + 2]))
				{
					MessageBox.Show($"{buttons[i].Content} játékos nyert.");
				}
			}
			//oszloponként
			for (int i = 0; i < 3; i++)
			{
				if (CheckEqual(buttons[i], buttons[i + 3], buttons[i + 6]))
				{
					MessageBox.Show($"{buttons[i].content} játékos nyert.");
				}
			}
			//atlo1
			if (CheckEqual(buttons[0], buttons[4], buttons[8]))
			{
				MessageBox.Show($"{buttons[0].content}");
			}
			//atlo2
			if (CheckEqual(buttons[2], buttons[4], buttons[6]))
			{
				MessageBox.Show($"{buttons[2].content} játékos nyert");
			}
		}
	}
}

