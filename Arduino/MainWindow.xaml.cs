using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Arduino
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, Article> articles =
            new Dictionary<string, Article>();

        private bool LightMode = true;

        public MainWindow()
        {
            InitializeComponent();
            LoadArticles();
        }

        private void LoadArticles()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Obsah.json");

            if (!File.Exists(path))
            {
                MessageBox.Show($"Obsah.json nebyl nalezen:\n{path}");
                return;
            }

            try
            {
                string json = File.ReadAllText(path);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                List<Article>? articleList =
                    JsonSerializer.Deserialize<List<Article>>(json, options);

                if (articleList == null)
                {
                    MessageBox.Show("JSON se načetl, ale je prázdný nebo neplatný.");
                    return;
                }

                articles = articleList.ToDictionary(a => a.Id, a => a);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba JSON:\n{ex.Message}");
            }
        }

        private void CourseTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CourseTree.SelectedItem is TreeViewItem item)
            {
                if (item.Tag is string key &&
                    articles.TryGetValue(key, out Article? article))
                {
                    ArticleTitle.Text = article.Title;
                    ArticleContent.Text = article.Content;
                }
            }
        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (LightMode)
            {
                this.Resources["Background"] =
                    new SolidColorBrush(Color.FromRgb(29, 31, 46));

                this.Resources["Foreground"] =
                    new SolidColorBrush(Color.FromRgb(36, 39, 61));

                this.Resources["Text"] =
                    new SolidColorBrush(Color.FromRgb(255, 255, 255));

                this.Resources["Text2"] =
                    new SolidColorBrush(Color.FromRgb(155, 155, 155));

                ModeTextBlock.Text = "Světlý režim";
                button.Content = "☀︎";

                LightMode = false;
            }
            else
            {
                this.Resources["Background"] =
                    new SolidColorBrush(Color.FromRgb(255, 255, 255));

                this.Resources["Foreground"] =
                    new SolidColorBrush(Color.FromRgb(233, 227, 255));

                this.Resources["Text"] =
                    new SolidColorBrush(Color.FromRgb(0, 0, 0));

                this.Resources["Text2"] =
                    new SolidColorBrush(Color.FromRgb(135, 135, 135));

                ModeTextBlock.Text = "Tmavý režim";
                button.Content = "⏾";

                LightMode = true;
            }
        }
    }
}