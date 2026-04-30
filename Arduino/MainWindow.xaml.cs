using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Arduino
{
    public partial class MainWindow : Window
    {
        Dictionary<string, (string title, string content)> articles;
        bool LightMode = true;

        public MainWindow()
        {
            InitializeComponent();

            /* VZOR na kurzy:
             * 
                ["číslo kurzu (např: 1.1)"] =
                (
                    "titul kurzu (název: 1.1 Úvod do Arduina)",
                    "obsah kurzu"
                ), 

             */
            articles = new Dictionary<string, (string, string)>
            {
                ["0.0"] =
                (
                    "0.0 Lorem ipsum dolor sit amet",
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                ),
                // MODUL 1
                ["1.0"] =
                (
                    "1.0 Co je to Arduino?",
                    "Arduino je open-source vývojová platforma, která byla vytvořena, aby umožnila všem zájemcům o programování elektroniky vyvíjet softwarové a hardwarové aplikace. " +
                    "Skládá se z různých desek mikrokontrolérů, které běžně používají začátečníci, vysokoškoláci a fandové pro vytváření interaktivních elektronických zařízení.\n\n" +

                    "Systém Arduino obsahuje programovatelnou obvodovou desku, která je schopna interpretovat digitální vstupní signály a generovat výstupní akce. " +
                    "Desky Arduino přijímají vstupy přes senzory nebo tlačítka a ovládají výstupní zařízení pomocí vestavěných příkazů nebo externích programů napsaných uživatelem.\n\n" +

                    "Za prvé a především, Arduino zjednodušuje proces připojení elektroniky k vašemu počítači, protože k sestavení zařízení nepotřebujete mnoho vědět o programování. " +
                    "Uživatelé potřebují pouze připojit mikrokontrolér k počítači a nahrát skript, aby vynález fungoval.\n\n" +

                    "Výhodou Arduina je, že je open-source, což znamená, že jeho hardwarová a softwarová architektura je dostupná široké veřejnosti. " +
                    "Každý, kdo se chce učit a používat stávající technologie, to může udělat bez jakýchkoli poplatků.\n\n" +

                    "Mezi některá základní zařízení Arduino lze zmínit následující:\n\n" +
                    "- Systém domácí automatizace\n" +
                    "- Robot ovládaný z aplikace chytrého telefonu\n" +
                    "- Automatická meteostanice\n\n" +

                    "Arduino tak propojuje digitální sféru s reálným světem a slouží jako vynikající vzdělávací technologie."
                ),
                ["1.1"] =
                (
                    "1.1 Historie a využití Arduina",
                    "Arduino bylo vynalezeno v roce 2005 v Itálii několika vysokoškolskými profesory a studenty. " +
                    "Zaměřili se na vývoj dostupného a snadno použitelného zařízení pro výuku elektroniky a programování.\n\n" +

                    "Před vynálezem Arduina vyžadovala práce s mikrokontroléry drahé vybavení a speciální kódovací dovednosti. " +
                    "S Arduinem se tyto procesy staly mnohem dostupnějšími.\n\n" +

                    "Postupem času se Arduino stalo velmi populárním po celém světě. V současné době se používá pro: \n" +
                    "- Vzdělávací účely ve školách a vysokých školách/univerzitách\n" +
                    "- DIY projekty (Do It Yourself - sám si to udělej)\n" +
                    "- Prototypování produktu\n" +
                    "- IoT (Internet of Things)\n" +
                    "- Jednodušší průmyslová automatizace\n\n" +

                    "Arduino komunita se stala jednou z hlavních výhod technologie Arduino. Mnoho majitelů Arduina sdílí své zkušenosti na fórech; na internetu jsou k dispozici miliony výukových programů. Nalezení řešení téměř jakéhokoli problému spojeného s Arduinem je tedy poměrně snadné.\n" +
                    "Kromě toho, že je Arduino produktem, sloužilo jako inspirace pro další společnosti a hrálo důležitou roli ve vývoji hnutí tvůrců."
                ),
                ["1.2"] =
                (
                    "1.2 Arduino desky",
                    "Desky Arduino jsou hardwarová zařízení používaná ke spouštění programů, které budete psát. Existuje mnoho různých modelů desek Arduino. Každá deska je specializovaná na plnění určitých úkolů. " +
                    "Mezi běžně používanými deskami Arduino můžeme zdůraznit následující:\n" +
                    "- Arduino Uno: nejoblíbenější deska, vhodné pro začátečníky. Použitá v předmětu Hardware a sítě - cvičení v druhém ročníku IT.\n" +
                    "- Arduino Nano: malá velikost, vhodné pro kompaktní projekty.\n" +
                    "- Arduino Mega: deska, která poskytuje více I/O pinů a paměti než jiné desky.\n" +
                    "- Arduino Due: pokročilejší deska, která využívá architekturu jiného mikrořadiče.\n" +
                    "- Arduino Leonardo: deska, která lze použít jako klávesnici nebo myš.\n\n" +

                    "Každá deska Arduino obsahuje následující komponenty:\n" +
                    "- Mikrořadič\n" +
                    "- Digitální I/O piny\n" +
                    "- Analogové input piny\n" +
                    "- Napájecí zdroje\n" +
                    "- USB konektor\n\n" +

                    "Při výběru vhodné desky Arduino je třeba si uvědomit, jaká deska plní naše požádavky. Pro běžné využití se vždy doporučuje Arduino Uno."
                ),
                ["1.3"] =
                (
                    "1.3 Arduino IDE",
                    "Arduino IDE je software používaný k vytváření a nahrávání kódu na hardware Arduino." +
                    "Je uživatelsky přívětivý a vhodný pro všechny úrovně pokročilosti, přesto dostatečně efektivní pro nejpokročilejší uživatele. IDE využívá programovací jazyk odvozený z C/C++. Ovšem se liší vlastními způsoby.\n" +
                    "Všechny programy Arduino zahrnují dvě základní a hlavní funkce:" +
                    "- void setup(): Tato funkce se provede na začátku projektu. Slouží např: na startování sériové komunikace nebo konfigurace pinů.\n" +
                    "- void setup(): Tato funkce se opakovaně provádí.\n\n" +

                    "Arduino IDE také obsahuje:\n" +
                    "- Editor kódu\n" +
                    "- Kompilátor\n" +
                    "- Sériový monitor\n" +
                    "- Externí knihovny (např: LiquidCrystalI2C)\n\n" +

                    "Kompilace kódu v Arduino IDE je velice jednoduché. Funguje ve 3 krocích:\n" +
                    "- Napojte Arduino desku pomocí USB konektoru do PC.\n" +
                    "- V Arduino IDE vyberte správnou desku.\n" +
                    "- Naprogramujte svůj program.\n" +
                    "- Vyberte možnost 'Nahrát' (ovšem existuje taky možnost 'Ověřit', který ověří funkcionalitu kódu před nahraním do desky.\n\n" +

                    "Vysokou nevýhodou Arduina IDE je, že oproti známějších IDE (např: Visual Studio Code) neodkazuje, kde je v ködu chyba." +
                    "Váš kód může být zcela špatný, a Arduino IDE by vás ani neupozornil. Chybu zjistíte, až jí zkusíte nahrát nebo ověřit." +
                    "Ale na druhé straně má Arduino IDE výhodu v tom, že něhem několika sekund váš program začne pracovat na desce. Samozřejmě záleží na velikost a komplexitu kódu, ale běžně se Arduino kód rychle nahrává."
                )
            };
        }

        private void CourseTree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CourseTree.SelectedItem is TreeViewItem item)
            {
                if (item.Tag is string key && articles.TryGetValue(key, out var article))
                {
                    ArticleTitle.Text = article.title;
                    ArticleContent.Text = article.content;
                }
            }
        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            if (LightMode)
            {
                this.Resources["Background"] = new SolidColorBrush(Color.FromRgb(29, 31, 46));
                this.Resources["Foreground"] = new SolidColorBrush(Color.FromRgb(36, 39, 61));
                this.Resources["Text"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.Resources["Text2"] = new SolidColorBrush(Color.FromRgb(155, 155, 155));
                ModeTextBlock.Text = "Světlý režim";
                button.Content = "☀︎";
                LightMode = false;
            }
            else
            {
                this.Resources["Background"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                this.Resources["Foreground"] = new SolidColorBrush(Color.FromRgb(233, 227, 255));
                this.Resources["Text"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.Resources["Text2"] = new SolidColorBrush(Color.FromRgb(135, 135, 135));
                ModeTextBlock.Text = "Tmavý režim";
                button.Content = "⏾";
                LightMode = true;
            }
        }
    }
}