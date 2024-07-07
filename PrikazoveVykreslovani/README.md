# Příkazové vykreslování

## 📜 Popis projektu

Tento projekt vykresluje objekty v **C#** pomocí **Windows Forms**. Objekty, které se mají vykreslit se uloží do skupiny a ta se potom vykresluje celá.

## 🎮 Funkce

- Nakreslení "prázných" nebo vyplněných tvarů.
- Volení barev.
- Ukládání do skupin tvarů, které se následně mohou vykreslit. (Funguje pouze pro Rectangle a Ellipse)
- Ukládání a načítání skupin.

## 🔧 Požadavky

- .NET Framework 4.7.2 nebo vyšší
- Visual Studio 2019 nebo novější

## 📂 Struktura projektu

- **PrikazoveVykreslovani.sln**: Hlavní řešení projektu.
- **Program.cs**: Hlavní vstupní bod aplikace.
- **Form1.cs**: Uživatelské rozhraní a ukládání/načítání skupin.
- **Groupe.cs**: Třída pro práci se skupinou tvarů.
- **GroupeManager.cs**: Grafické rozhraní pro vytváření tvarů a skládání skupin.
- **CommandForm.cs**: Grafické rozhraní pro kreslení tvarů.
- **Shapes.cs**: Třída pro dědění vlastností pro jednotlivé tvary a třídy tvarů.

## 📸 Ukázka aplikace

![Screenshot Kreslení Kruhů](PV_screenshot.png)

