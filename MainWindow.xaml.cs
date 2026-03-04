using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VizsgaAsztali
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<[Class_name]> [list_name];

		public MainWindow()
        {
            InitializeComponent();
            LoadItems();
		}

        private void LoadItems()
        {
            try
            {
                [list_name] = Database.GetItems();
                dgExample.ItemsSource = [list_name];
			}
            catch (Exception ex)
            {
                MessageBox.Show("Adatbázis kapcsolat hiba!\n" + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
			    Application.Current.Shutdown();
			}
        }

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (dgExample.SelectedItem == null)
			{
				MessageBox.Show("Törléshez válasszon ki egy elemet", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			[Class_name] selectedItem = ([Class_name])dgExample.SelectedItem;

			var result = MessageBox.Show("Biztos törölni szeretné a kiválasztott elemet?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);

			if (result != MessageBoxResult.Yes)
			{
				return;
			}

			try
			{
				bool success = Database.DeleteItem(selectedItem.Id);
				if (success)
				{
					[list_name].Remove(selectedItem);
					dgExample.Items.Refresh();
					MessageBox.Show("Az elem sikeresen törölve lett.", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				else
				{
					MessageBox.Show("A törlés nem sikerült!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hiba történt a törlés során!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}