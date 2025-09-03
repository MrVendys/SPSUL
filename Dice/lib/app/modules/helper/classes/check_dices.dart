//Trida na seskladani figur podle hozenych kostek
import 'figure.dart';

class CheckDices {
  ///Hozené kostky
  List<int> listOfDiceNumbers = [];

  ///Mapa figur (jmeno: figura)
  Map<String, Figure> mapOfFigures = {};

  final List<String> figureNames = [
    'jednicky',
    'dvojky',
    'trojky',
    'ctyrky',
    'petky',
    'sestky',
    'male',
    'velke',
    'sude',
    'liche',
    'rada',
    'dvojice',
    'trojice',
    'ctyriPlusDva',
    'petPlusJedna',
    'pyramida',
    'vrhcab',
    'general',
  ];

  //Zkusit, kdyz tak smazat
  //Konstruktor
  CheckDices(this.listOfDiceNumbers) {
  mapOfFigures = {
    for (var name in figureNames) name: Figure(name),
  };

    doCheck();
  }
 
  ///Pridej do prislusneho listu pocet kostek tolikrat, kolikrat se hodila
  ///
  ///"figure" -> figura
  ///
  ///"numberOfAdding" -> kolikrát se má přidat
  ///
  ///"number" -> cislo na kostce pro pridani
  addDiceToFigure(String figure, int numberOfAdding, int number) {
    for (var i = 0; i < numberOfAdding; i++) {
      mapOfFigures[figure]!.savedDices.add(number);
    }
  }

  ///Kontrola ciselne hodnoty kazde kostky a umisteni ji do spravne figury
  ///
  ///Hodil jsem kostku s 1 -> muze to byt figura jednicky, rada, male, liche
  doCheck() {
    // Mapa hozených čísel a počet výskytů.
    Map<int, int> numberAndCount = {};

    List<int> listOfDiceNumbersSorted = listOfDiceNumbers;
    listOfDiceNumbersSorted.sort();
    
    for (var hod in listOfDiceNumbersSorted) {
      numberAndCount[hod] = (numberAndCount[hod] ?? 0) + 1;
    }

    var nazvyFigur = {
      1: 'jednicky',
      2: 'dvojky',
      3: 'trojky',
      4: 'ctyrky',
      5: 'petky',
      6: 'sestky'
    };

    var minKey = numberAndCount.keys.reduce((a, b) => a < b ? a : b);
    var maxKey = numberAndCount.keys.reduce((a, b) => a > b ? a : b);

    //Kontrola slozitejsich figur, dvojice, trojice, pyramida, vrhcab, 4+2, 5+1, general
    for (var i in numberAndCount.keys) {
      addDiceToFigure(nazvyFigur[i]!, numberAndCount[i]!, i);

      if (!mapOfFigures['rada']!.savedDices.contains(i)) {
        addDiceToFigure('rada', 1, i);
      }

      if (i <= 3){
        addDiceToFigure('male', numberAndCount[i]!, i);
      }

      if (i > 3){
        addDiceToFigure('velke', numberAndCount[i]!, i);
      }

      if (i % 2 == 0){
        addDiceToFigure('sude', numberAndCount[i]!, i);
      }

      if (i % 2 == 1){
        addDiceToFigure('liche', numberAndCount[i]!, i);
      }
      
      //Pokud je hodnota 2x
      if (numberAndCount[i] == 2) {
        //dvojce
        addDiceToFigure(nazvyFigur[i]!, 2, i);
        addDiceToFigure('dvojice', 2, i);
        addDiceToFigure('trojice', 2, i);
        addDiceToFigure('ctyriPlusDva', 2, i);
        addDiceToFigure('petPlusJedna', 2, i);

        if (i > minKey && i < maxKey){
          //vrhcab dvojce
          addDiceToFigure('vrhcab', 2, i);
          addDiceToFigure('pyramida', 2, i);
          if (i + 1 == maxKey){
            if (numberAndCount[i + 1] == 1){
              addDiceToFigure('vrhcab', 1, i + 1);
            }
          }
          if (i - 1 == minKey){
            if (numberAndCount[i - 1] == 1){
              addDiceToFigure('pyramida', 1, i - 1);
            }
          }
        }
      }
      if (numberAndCount[i] == 3) {
        //trojce
        addDiceToFigure(nazvyFigur[i]!, 3, i);
        addDiceToFigure('trojice', 3, i);
        addDiceToFigure('ctyriPlusDva', 3, i);
        addDiceToFigure('petPlusJedna', 3, i);

        if (i == minKey){
          //vrhcab trojce
          addDiceToFigure('vrhcab', 3, i);
        }
        if (i == maxKey){
          //pyramida trojce
          addDiceToFigure('pyramida', 3, i);
        }
      }
      if (numberAndCount[i] == 4) {
        //čtveřice
        addDiceToFigure(nazvyFigur[i]!, 4, i);
        addDiceToFigure('ctyriPlusDva', 4, i);
        addDiceToFigure('petPlusJedna', 4, i);
      }
      if (numberAndCount[i] == 5) {
        //pětice
        addDiceToFigure(nazvyFigur[i]!, 5, i);
        addDiceToFigure('petPlusJedna', 5, i);
        if (numberAndCount.containsValue(1)) {
          addDiceToFigure('petPlusJedna', 1, numberAndCount.entries.firstWhere((e) => e.value == 1).key);
          break;
        }
      }
      if (numberAndCount[i] == 6) {
        //šestice
        addDiceToFigure(nazvyFigur[i]!, 6, i);
        if (i == 6){
          addDiceToFigure('gerenal', 6, i);
        }
      }
    }
  }
}