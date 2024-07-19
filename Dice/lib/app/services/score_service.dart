import 'package:dices/app/models/dice.dart';
import 'package:dices/app/models/player.dart';

import 'package:get/get.dart';
//Pomocna trida na udrzovani hodnot a komunikaci stranek
class ScoreService {
  RxList<Dice> rolledDices = <Dice>[].obs;
  RxList<Dice> stoppedDices = <Dice>[].obs;
  //Natvrdo definovani prvni 2 hraci
  RxList<Player> players = <Player>[
    Player("Venca"),
    Player("Petr"),
  ].obs;

  bool hasFirstRolled = false;
  int value = 1;
  String figureName = "1";
  RxInt currentPlayer = 0.obs;
  bool doAddRecord = false;
  int numberOfRolls = 3;
  //Funkce na zmenu zapisu v zapisniku po kliknuti na tlacitko "Zapsat"
  changeRecord(String figureToChange, String value) {
    //Kontrola prazdne hodnoty
    if (value != "") {
      players[currentPlayer.value]
          .records
          .firstWhere((record) => record.figure == figureToChange)
          .value = int.parse(value);
      bool hasEverything = false;
      for (var value in players[currentPlayer.value].records.value) {
        if (value != 0) {
          hasEverything = true;
        }
      }
      if (hasEverything) {
        for (Player p in players) {
          p.sumRecords();
        }
      }
    }
  }
}
