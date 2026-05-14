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
        private bool English = false;
        public MainWindow()
        {
            InitializeComponent();
            LoadArticles("Obsah.json");
        }

        private void LoadArticles(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(path))
            {
                MessageBox.Show($"{fileName} nebyl nalezen:\n{path}");
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

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (!English)
            {
                LoadArticles("ObsahEN.json");

                button.Content = "EN";
                LanguageTextBox.Text = "Change language to CZ";

                ArticleTitle.Text = "Select a course";
                ArticleContent.Text = "Select a course from the modules.";

                Module1.Header = "Module 1: Introduction to Arduino";
                Item10.Header = "1.0 What is Arduino?";
                Item11.Header = "1.1 History and Uses of Arduino";
                Item12.Header = "1.2 Arduino Boards";

                Module2.Header = "Module 2: Electronics Revision";
                Item20.Header = "2.0 Voltage, Current and Resistance";
                Item21.Header = "2.1 Ohm's Law";
                Item22.Header = "2.2 Basic Components";

                Module3.Header = "Module 3: Communication Protocols";

                Module4.Header = "Module 4: Programming in Arduino";
                Item40.Header = "4.0 The Structure of a Sketch";
                Item41.Header = "4.1 Inputs and Outputs";
                Item42.Header = "4.2 Data Types";
                Item43.Header = "4.3 Cycles and Conditions";
                Item44.Header = "4.4 Functions";

                English = true;
            }
            else
            {
                LoadArticles("Obsah.json");

                button.Content = "CZ";
                LanguageTextBox.Text = "Změnit jazyk na EN";

                ArticleTitle.Text = "Vyberte si kurz";
                ArticleContent.Text = "Vyberte si kurz z modulů a začněte.";

                Module1.Header = "Modul 1: Úvod do Arduina";
                Item10.Header = "1.0 Co je to Arduino?";
                Item11.Header = "1.1 Historie a využití Arduina";
                Item12.Header = "1.2 Arduino desky";

                Module2.Header = "Modul 2: Opakování elektrotechniky";
                Item20.Header = "2.0 Napětí, proud a odpor";
                Item21.Header = "2.1 Ohmův zákon";
                Item22.Header = "2.2 Základní součástky";

                Module3.Header = "Modul 3: Komunikační protokoly";

                Module4.Header = "Modul 4: Programování v Arduino";
                Item40.Header = "4.0 Struktura skicy";
                Item41.Header = "4.1 Vstupy a výstupy";
                Item42.Header = "4.2 Datové typy";
                Item43.Header = "4.3 Cykly a podmínky";
                Item44.Header = "4.4 Funkce";

                English = false;
            }
        }
    }
}