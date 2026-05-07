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
                    "Skládá se z různých desek mikrořadičů, které běžně používají začátečníci, vysokoškoláci a fandové pro vytváření interaktivních elektronických zařízení.\n\n" +

                    "Systém Arduino obsahuje programovatelnou obvodovou desku, která je schopna interpretovat digitální vstupní signály a generovat výstupní akce. " +
                    "Desky Arduino přijímají vstupy přes senzory nebo tlačítka a ovládají výstupní zařízení pomocí vestavěných příkazů nebo externích programů napsaných uživatelem.\n\n" +

                    "Za prvé a především, Arduino zjednodušuje proces připojení elektroniky k vašemu počítači, protože k sestavení zařízení nepotřebujete mnoho vědět o programování. " +
                    "Uživatelé potřebují pouze připojit mikrořadič k počítači a nahrát skript, aby vynález fungoval.\n\n" +

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

                    "Před vynálezem Arduina vyžadovala práce s mikrořadiči drahé vybavení a speciální kódovací dovednosti. " +
                    "S Arduinem se tyto procesy staly mnohem dostupnějšími.\n\n" +

                    "Postupem času se Arduino stalo velmi populárním po celém světě. V současné době se používá pro: \n\n" +
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
                    "Mezi běžně používanými deskami Arduino můžeme zdůraznit následující:\n\n" +
                    "- Arduino Uno: nejoblíbenější deska, vhodné pro začátečníky. Použitá v předmětu Hardware a sítě - cvičení v druhém ročníku IT.\n" +
                    "- Arduino Nano: malá velikost, vhodné pro kompaktní projekty.\n" +
                    "- Arduino Mega: deska, která poskytuje více I/O pinů a paměti než jiné desky.\n" +
                    "- Arduino Due: pokročilejší deska, která využívá architekturu jiného mikrořadiče.\n" +
                    "- Arduino Leonardo: deska, která lze použít jako klávesnici nebo myš.\n\n" +

                    "Každá deska Arduino obsahuje následující komponenty:\n\n" +
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
                    "Všechny programy Arduino zahrnují dvě základní a hlavní funkce:\n\n" +
                    "- void setup(): Tato funkce se provede na začátku projektu. Slouží např: na startování sériové komunikace nebo konfigurace pinů.\n" +
                    "- void loop(): Tato funkce se opakovaně provádí.\n\n" +

                    "Arduino IDE také obsahuje:\n\n" +
                    "- Editor kódu\n" +
                    "- Kompilátor\n" +
                    "- Sériový monitor\n" +
                    "- Externí knihovny (např: LiquidCrystalI2C)\n\n" +

                    "Kompilace kódu v Arduino IDE je velice jednoduché. Funguje ve 3 krocích:\n\n" +
                    "- Napojte Arduino desku pomocí USB konektoru do PC.\n" +
                    "- V Arduino IDE vyberte správnou desku.\n" +
                    "- Naprogramujte svůj program.\n" +
                    "- Vyberte možnost 'Nahrát' (ovšem existuje taky možnost 'Ověřit', který ověří funkcionalitu kódu před nahraním do desky.\n\n" +

                    "Vysokou nevýhodou Arduina IDE je, že oproti známějších IDE (např: Visual Studio Code) neodkazuje, kde je v kódu chyba. " +
                    "Váš kód může být zcela špatný, a Arduino IDE by vás ani neupozornil. Chybu zjistíte, až jí zkusíte nahrát nebo ověřit. " +
                    "Ale na druhé straně má Arduino IDE výhodu v tom, že něhem několika sekund váš program začne pracovat na desce. Samozřejmě záleží na velikost a komplexitu kódu, ale běžně se Arduino kód rychle nahrává."
                ),
                // MODUL 2
                ["2.0"] =
                (
                    "2.0 Napětí, proud a odpor",
                    "Všichni víme nebo jsme už slyšeli tyto termíny: napětí, odpor a proud. Tyto tři veličiny tvoří základ toho, jak se elektřina chová v obvodu. " +
                    "Každý, kdo pracuje v elektronice, ať už staví jednoduché obvody nebo vyvíjí složitější systémy, jako jsou projekty založené na mikrořadičích, musí těmto konceptům důkladně rozumět.\n\n" +

                    "Napětí je rozdíl elektrického potenciálu mezi dvěma body v obvodu. Značí se písmenem U a jednotkami napětí jsou volty [V]. Představte si to jako tlak ve vodovodním systému. Stejně jako tlak vody tlačí vodu potrubím, napětí tlačí elektrické náboje vodičem. " +
                    "Napětí je obvykle dodáváno zdroji, jako jsou baterie, napájecí adaptéry nebo generátory. Různá zařízení mají různé požadavky na napětí a použití nesprávného napětí může poškodit součástky.\n\n" +

                    "Proud je rychlost toku elektrického náboje vodičem. Značí se písmenem I a jednotkami proudu jsou ampéry [A]. Přivedení napětí na obvod způsobí, že se elektrony začnou pohybovat. Tím vzniká proud. Síla proudu je určena napětím a odporem v obvodu.\n\n" +

                    "Odpor, jak název napovídá, je odpor vůči toku elektrického proudu. Značí se písmenem R a jednotkami odporu jsou ohmy [Ω]. Všechny materiály mají určitý odpor, ale pomocí rezistorů můžeme libovolně regulovat odpor. " +
                    "Vysoký odpor znamená, že protéká menší proud, a nízký odpor znamená, že může procházet větší proud. Odpor je nezbytný pro ochranu citlivých součástek, řízení jasu LED diod a udržování bezpečnosti obvodů. \n\n" +
                    "Užitečná pomůcka na vizualizaci všech třech konceptech je představit si elektřinu jako vodu proudící potrubím. \n" +
                    "- napětí: tlak vody\n" +
                    "- proud: rychlost toku vody\n" +
                    "- odpor: velikost potrubí\n" +
                    "Pokud rozumíte tomu, jak tyto tři faktory fungují společně, můžete předpovědět, jak se bude obvod chovat, a vyhnout se běžným chybám, jako jsou zkraty nebo přehřátí součástí."
                ),
                ["2.1"] =
                (
                    "2.1 Ohmův zákon",
                    "Diskutabilně nejlehčí, nejznámější a nejzásadnější princip elektroniky je Ohmův zákon, protože přímo dává do souvislosti napětí, proud a odpor. " +
                    "Poskytuje jednoduchý matematický vztah, který lze použít k analýze a návrhu obvodů. Zákon je vyjádřen vzorcem:\n\n" +

                    "U = I * R\n\n" +

                    "Tuto rovnici můžeme také upravit v závislosti na tom, co chceme zjistit:\n\n" +

                    "I = U/R\n" +
                    "R = U/I\n\n" +

                    "Ohmův zákon říká, že zvyšováním napětí a udržováním konstantního odporu se proud zvyšuje, a pokud zvýšíme odpor při konstantním napětí, proud se sníží. " +
                    "Tento vztah je velmi důležitý při návrhu obvodů. Například musíte vložit rezistor, abyste omezili proud pomocí LED. " +
                    "Jinak by mohl protékat příliš mnoho proudu a trvale poškodit LED. \n\n" +

                    "Ohmův zákon se běžně používá k identifikaci a řešení problémů. Pokud obvod nefunguje tak, jak by měl, měření napětí a proudu vám může říct, zda je odpor příliš vysoký nebo příliš nízký, nebo zda se jedná o chybu, například přerušené spojení.\n" +
                    "Na pokročilejších úrovních se Ohmův zákon používá v kontextu pochopení spotřeby energie a účinnosti. Často se používá se vzorcem pro výkon: \n\n" +
                    "P = U * I \n\n" +
                    "To je užitečné pro zjištění, kolik energie součástka spotřebovává. " +
                    "Stručně řečeno, znalost používání Ohmova zákona znamená, že můžete vytvářet obvody, které fungují a jsou bezpečné, což z něj činí základ elektrotechniky a elektroniky."
                ),
                ["2.2"] =
                (
                    "2.2 Základní součástky",
                    "Elektronické obvody obsahují mnoho součástek. Každá z nich hraje nějakou roli a plní specifický účel. Je důležité se naučit tyto základní komponenty, abyste pochopili, jak obvody fungují, a mohli si vytvářet vlastní projekty. " +
                    "Zde jsou některé běžné součástky, se kterým se určitě setkáte během hodiny Hardwaru a sítě - cvičení:\n\n" +

                    "Rezistor se používá k omezení nebo řízení toku proudu v obvodu. Zajišťuje, aby součástky dostávaly správné množství proudu, a zabraňuje poškození. Rezistory mají různé hodnoty, obvykle označené barevnými proužky.\n\n" +

                    "Kondenzátor je zařízení, které krátkodobě ukládá elektrickou energii a poté ji v případě potřeby uvolňuje. \n" +
                    "Široce se používá k vyhlazení napájecích signálů, filtrování šumu a pro časovací aplikace. Existuje řada různých typů kondenzátorů, například keramické, elektrolytické atd., každý z nich je vhodný pro jiné účely.\n\n" +

                    "LED (Light Emitting Diode) je speciální typ diody, která vyzařuje světlo, když jí prochází proud. LED diody jsou energeticky úsporné a často se používají pro indikátory, displeje a osvětlení. Pro omezení proudu potřebují rezistor.\n\n" +

                    "Potenciometr je typ proměnného rezistoru, který lze ručně nastavit obvykle otáčením knoflíku nebo posunutím ovládacího prvku. Často se používá k ovládání věcí, jako je hlasitost, jas nebo prahové hodnoty senzorů. " +
                    "V obvodu může být použit jako dělič napětí, který poskytuje proměnné výstupní napětí v závislosti na jeho poloze.\n\n" +

                    "Tlačítko je základní vstupní zařízení, které po stisknutí dočasně otevírá nebo zavírá obvod. Často se používá ke spuštění akce, jako je zapnutí nebo vypnutí zařízení, nebo k odeslání signálu do mikrořadičů. " +
                    "Tlačítka obvykle vyžadují další komponenty (např: rezistory), aby se chovala stabilně a předvídatelně. \n\n" +

                    "Ve světě elektrotechniky samozřejmě existuje mnoho dalších součástek (např: LCD displej), ale tyto součástky tvoří fundamentální základ běžných projektů s Arduinem, které se dělají ve škole."
                ),
                // MODUL 3
                ["3.0"] =
                (
                    "3.0 UART",
                    "UART (Universal Asynchronous Reciever Transmitter) je jednou z nejběžnějších metod sériové komunikace v elektronice a mikrokontrolérech.  " +
                    "Jak název napovídá, jedná se o asynchronní komunikační protokol, který umožňuje dvěma zařízením vyměňovat si data bez nutnosti společného hodinového signálu. \n" +
                    "UART se velmi často používá v deskách Arduino, počítačích, GPS modulech, Bluetooth/WiFi modulech a mnoha dalších zařízeních. \n\n" +
                    "Komunikace UART probíhá pomocí dvou hlavních vodičů. Jeden vodič se používá pro data a nazývá se transmitter - TX (vysílání). Druhý vodič se používá pro příjem dat a nazývá se reciever - RX (příjem). \n" +
                    "Komunikace mezi zařízeními musí být křížená. To znamená, že vysílač jednoho zařízení je připojen k přijímači druhého zařízení a naopak. Obě zařízení musí mít také společný uzemňovací vodič (GND). \n\n" +
                    "UART je asynchronní komunikace. Zařízení nepoužívají samostatný hodinový signál k synchronizaci přenosu dat. Místo toho se obě zařízení musí předem dohodnout na stejné přenosové rychlosti. \n" +
                    "Tato rychlost je známá jako přenosová rychlost (baud rate). Nejběžnější rychlosti jsou 9600, 57600 nebo 115200 bps. Pokud obě zařízení nejsou nastavena na stejnou rychlost, data budou přijata nesprávně. \n\n" +
                    "Data se během přenosu pomocí UART odesílají bit po bitu. Každý přenášený znak má startovací bit, datové bity a jeden nebo více stop bitů. " +
                    "Startovací bit se používá k signalizaci začátku přenosu a stop bit k signalizaci konce datového rámce. Někdy se do přenosu přidává další paritní bit pro kontrolu chyb. \n\n" +
                    "Jednou z klíčových silných stránek UART komunikace je její jednoduchost. Proces implementace je poměrně přímočarý a většina mikrokontrolérů má v sobě zabudovaný hardware UART. " +
                    "UART se nejlépe hodí pro komunikaci mezi dvěma zařízeními, například mezi zařízením Arduino a počítačem. UART se také často používá pro ladění aplikací pomocí sériového monitoru. \n\n" +
                    "Hlavní nevýhodou UART komunikace je její neschopnost podporovat mnoho zařízení současně. UART je primárně navržen pro komunikaci mezi dvěma zařízeními. Další slabinou UART je jeho relativně nízká rychlost ve srovnání s jinými rychlejšími způsoby komunikace, jako jsou protokoly SPI nebo novější technologie. " +
                    "UART komunikace se důrazně doporučuje pro jednoduché komunikační úlohy, textový přenos dat, ladění aplikací a komunikaci s moduly, u kterých není rychlost kritická."
                ),
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