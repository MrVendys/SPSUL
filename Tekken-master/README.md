# Tekken-master

## 📜 Popis projektu

Tento projekt je imitací 2D hry Tekken v jazyce **C#**. Hráč si vybere charakter, za který bude bojovat a za pomocí miniher sbírá score, které poté promění na poškození do protihráče.

> **⚠️ Upozornění: Tento projekt obsahuje legrační fotky žáků naší třídy. Vše je schválené.**

## ⚙️ Funkce

- Uřivatel si může zvolit charakter, za kterého bude bojovat.
- Náhodné zvolení protivníka.
- Bojování stylem miniher. Počet splněných miniher udává požkození soupeři.
- Obrazovka vítěze.

## 🧠 Použité techniky

- Timer
- Windows Forms
- Interface
- Dědění

## 🎮 Ovládání
- Hráč si nejdříve zvolí bojovníka ze seznamu kliknutím na něj. Dokud neklikne na tlkačítko **OK**, může ho změnit.
- Poté si náhodně vybere bojovníka počítač a po 3 sekundách začne boj v novém okně **Game**.
- Po kliknutí na tlačítko **Fight** se vybere náhodná minihra, kterou hřáč musí do časového limitu splnit. Podle toho, kolikrát ji úspěšně splní se vypočítá poškození, které utrží protivník.
- Minihry jsou následující:
  - **Letters**: Hráč musí zmáčknout příslišné písmeno na klávesnici.
  - **WaveMatch**: Hráč musí správně nastavit frekvenci a amplitudu dle červené předlohy.
  - **MathCalc**: Hráč musí odpověděd správně na matematický příklad, který se postupně rozšiřuje.
  - **Targets**: Hráč musí myší trefit náhodně objevující se a postupně mizící zelený terč.
  - **Pong**: Hráč musí co nejdéle držet míček v horní polovině hracího okna pomocí rakety, kterou ovládá myší.
  - **Circle**: Hráč musí správně trefit projíždící ukazatel na zelenou plochu na obvodu kola, kde ukazatel obíhá
- Komu klesnou životy na 0, prohrává


## 📂 Struktura projektu

- **Tekken.sln**: Hlavní řešení projektu.
- **Program.cs**: Hlavní vstupní bod aplikace.
- **FigherSelect.cs**: Grafické vybrání bojovníků.
- **Game.cs**: Hlavní hernígrafické rozhraní.
- **WaveMatch.cs**,**Targets.cs**,**MathCalc.cs**,**Letters.cs**,**Pong.cs**: Minihry
- **Fighters.cs**: Seznam bojovníků.
- **Fighter.cs**: Třída pro jednotlivého bojovníka

## 🔧 Požadavky

- .NET Framework 4.7.2 nebo vyšší
- Visual Studio 2019 nebo novější

## 🛠️ Instalace
### .exe souboru
- V této složce soubor Tekken.exe
- Kliknout na něj
- Vpravo nahoře tlačítko "Download raw file"
### Celé řešení
- Vrátit se zpět na [repozitář SPSUL](../)

## 📸 Ukázka aplikace

![Screenshot Tekken](Tekken_screenshot.png)
