# Půlročníkovka (Záznamník)

## 📜 Popis projektu

Projekt vznikl v rámci splnění předmětu na střední škole. Za úkol bylo za půl roku vytvořit projekt s následujícími požadavky:
Projekt musí využívat databáze (**MySQL** pomocí XAMPP)
Projekt musí být zrealizován v **C# .NET** nebo **HTML + PHP**

V tomto projektu jsem využil **C# .NET**

> **⚠️ Upozornění: Tento projekt není ve spustitelném tvaru. Je plně závislý na souběžném chodu s databází, která zde není**

## ⚙️ Funkce

- Vytvoření, ukázání, upravení, smazání záznamu.
- Vyhledávání jednotlivého záznamu.
- Vypočítání všechn záznamů dle hledaného výrazu.

## 🧠 Použité techniky

- Pracování s CRUD operacemi v MySQL databázi
- Windows forms

## 🎮 Ovládání
- Projekt nejde spustit. Vyhodí chybovou hlášku s databází
- První část okna tvoří textBoxy, které slouží jako inputy pro uživatele, kde vyplní údaje o zakázce a zákazníkovi.
- Následně dole je několik tlačítek pro pokyny pro databázi:
- **Create**: Vytvoří záznam a uloží do db
- **Show**: Ukáže všechny záznamy a zákazníky
- **Update**: Aktualizuje záznam
- **Delete**: Smaže záznam
- **Search**: Vyhledá záznam, který obsahuje text ze souvisícího inputu

## 📂 Struktura projektu

- **Projekt.sln**: Hlavní řešení projektu.
- **Program.cs**: Hlavní vstupní bod aplikace.
- **Form1.cs**: Grafické rozhraní a logika pro práci s databází.
- **Edit.cs**: UserControl pro upravování záznamu.

## 🔧 Požadavky

- .NET Framework 4.7.2 nebo vyšší
- Visual Studio 2019 nebo novější

## 🛠️ Instalace
### .exe souboru
- Neintalovat, nespustí se
### Celé řešení (kód)
- Vrátit se zpět na [repozitář SPSUL](../)


## 📸 Ukázka aplikace

![Screenshot Pulrocnikovky](PulRocnikovka_screenshot.png)

