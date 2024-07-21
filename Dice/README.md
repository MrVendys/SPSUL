# Ročníkovka (Kostky)

## 📜 Popis projektu

Projekt vznikl v rámci splnění předmětu ve 4. ročníku na střední škole. Za úkol bylo za rok naprogramovat dostatečně složitý projekt.

Projekt je remakem deskové hry Kostky pro mobilní zařízení. Máte k dispozici 6 kostek, 2 hody a snažíte se sestavit dané figury s co možná nejvíce body. Kdo první má všechny figury sestavené, končí hru. Kdo nasbírá více bodů, vyhrává.

### Jednoduchá pravidla
- Hráč má ve svým tahu 2 hody.
- První hod hází všemi kostkami. Poté si zvolí, jakou figuru by chtěl hodit, odloží si případně kostky, které jsou součástí figury na stranu, a se zbylými hází.
- Pokud se mu po druhém hodu povedla hodit nějaká figura, může se rozhodnout, zda si jí nechá a zapíše si součet bodů na kostkách do patřičné figury nebo to vzdá a ukončí své kolo. Poté hraje další hráč.
- Pokud hráč nechce házet, nebo po prvním hodu hodil figuru, nebo nehodil na kostkách nic dobrého, z čeho by šla postavit nějaká chybějící figura, může si zbylé hody zapsat do hodech k dobru - "Dober".
- "Dobra" jsou nevyužité hody, které hráč může využít ve svých dalších kolech nad rámec 2 hodů za kolo. Po použití se dobra odeberou.  (Např. První kolo nehodím ani jednou -> zapíšu si dvě "Dobra" -> Další kolo můžu házet o dva hody víckrát)
- 
> **⚠️ Upozornění: Tento projekt není ve spustitelném tvaru.**

## ⚙️ Funkce

- Plné grafické prostředí.
- Házení kostek v aplikaci
- Implementován automatický systém "Hodů k dobru"
- Skenování reálné kostky
- Ukládání posledního hodu
- Možnost vybýrat si, kterými kosktami se bude hazet.
- "Pomocník". Pomocí pravdepodobnosti radí, která figura má největší šanci na postavení
- Nápověda v pravém horním rohu.
- Možnost hry pro více hráčů na jednom zařízení
- Záznamník bodů pro hráče

## 🧠 Použité techniky

- Widgety
- Rozdělení projektu na Controller, View
- Piužití fotoaparátu na skenování
  
## 🎮 Ovládání
- Aplikace se dělí na 3 stránky:
  - **Dices**: Hlavni stránka, kde se hraje.
  - **Home**: Zápisník bodů pro hráče
  - **Helper**: Z hozených kostek se pomocí pravděpodobnost vyberou 3 figury, které mají největší šanci na postavení
  - Přechod mezi stránkami je řešen pomocí tlačítek vespodu obrazovky
- **Dices**: Stránka se zeshora dělí na:
   - **Hrací kostky**: Kostky, se kterými se bude házet
   - **Kostky na straně**: Kostky, se kterými se nehází -> staví se z nich figura
   - Kliknutí na jedntlivou kostku lze měnit, jestli se s ní bude házet nebo ne
   - Jednotlivá tlačítka na **Hod kostkami**, **Resetování kostek**, **Konec kola**, **Zápis figury**
- **Home**: Stránka obsahuje seznam figur, hráčů a jejich bodů v nasbíraných figurách, celkový počet bodů a hodů k dobru
  - Možnost přidávat dalšího hráče po zapsání jména a kliknutí na tlačítko
- **Helper**: Stránka zobrazující 3 nejpravděpodobnější figury z hozených kostek

## 📂 Struktura projektu

- **2048.sln**: Hlavní řešení projektu.
- **Program.cs**: Hlavní vstupní bod aplikace.
- **Form1.cs**: Logika i grafické rozhraní pomocí Windows Forms.
- **Cell.cs**: Třída typu User control pro jednotlivou destičku
- **GameOver.cs** Třída typu Windows Forms. Okno konce hry.

## 🚀 Technologie

- **Dart**: Programovací jazyk
- **Flutter**: Programovací prostředí


