// ignore_for_file: unnecessary_overrides

import 'dart:math';

import 'package:dices/app/models/dice.dart';
import 'package:dices/app/modules/helper/classes/check_dices.dart';
import 'package:dices/app/modules/helper/classes/figure.dart';
import 'package:dices/app/services/score_service.dart';

import 'package:get/get.dart';

class HelperController extends GetxController {
  final scoreService = Get.find<ScoreService>();
  RxList<Dice> rolledDices = <Dice>[].obs;
  List<Figure> figures = [];

  @override
  void onInit() {
    rolledDices = [scoreService.rolledDices, scoreService.stoppedDices]
        .expand((x) => x)
        .toList()
        .obs;

    calculate(rolledDices);
    super.onInit();
  }

  @override
  void onReady() {
    super.onReady();
  }

  @override
  void onClose() {}

  calculate(RxList<Dice> dices) {
    List<int> values = [];
    for (final dice in dices) {
      values.add(dice.number);
    }
    CheckDices checkDices = CheckDices(values);

    List<Figure> diceFigures = checkDices.mapOfFigures.values.toList();

    for (var i = 0; i < diceFigures.length; i++) {
      //Hodnota kostek v figure
      int diceCount = 0;
      for (int diceNumber in diceFigures[i].savedDices) {
        diceCount += diceNumber;
      }
      int possibilitys = 1;
      int goodPossibilitys = 1;
      // počet kostek v první a druhé části figury
      Map<int, List<int>> groups = {
        11: [2, 2, 2], // 2+2+2
        12: [3, 3], // 3+3
        13: [4, 2], // 4+2
        14: [5, 1], // 5+1

      };
      for (var j = 0; j < 6 - diceFigures[i].savedDices.length; j++) {
        possibilitys *= 6;
        if (i == 10){
          print("tady");
        }
        if (i <= 5 || diceFigures[i].name == 'řada') {
          // Jedničky až šestky – konkrétní číslo (1 možnost z 6)
          // Chybí jen 1 kostka nebo řada – jen 1 konkrétní hod
          goodPossibilitys *= 1;
        }
        else if (i > 5 && i < 10) {
          // Sudé, liché, malé, velké – 3 možnosti (2, 4, 6) (3 možnosti z 6)
          goodPossibilitys *= 3;
        }
        else if (groups.containsKey(i)) {
          var need = groups[i]!; // [první_skupina, druhá_skupina]
          int have = diceFigures[i].savedDices.length + j;

          if (have < need[0]) {
          // doplňujeme první skupinu → první kostka má 6 možností, zbytek jen 1
            if (have % need[0] == 0) {
              goodPossibilitys *= 6;
            } else {
              goodPossibilitys *= 1;
            }
          }
          else {
            // doplňujeme druhou skupinu
            int haveInSecond = have - need[0];
            if (haveInSecond == 0) {
              goodPossibilitys *= 6; // první kostka druhé skupiny
            } else {
              goodPossibilitys *= 1;
            }
          }
        }
        print('Name: ${diceFigures[i].name}, goodPoss: $goodPossibilitys, poss: $possibilitys');
      }
      diceFigures[i].setScoreAndPercent((goodPossibilitys / possibilitys) * 100, diceCount);

      figures.add(diceFigures[i]);
    }
    figures.sort((a, b) => b.percent.compareTo(a.percent));
    scoreService.figureName = figures.first.name;
    scoreService.value = figures.first.score;
  }
}
