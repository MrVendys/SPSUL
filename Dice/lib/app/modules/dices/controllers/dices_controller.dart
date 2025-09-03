// ignore_for_file: prefer_const_constructors
import 'dart:io';
import 'dart:typed_data';

import 'package:dices/app/models/dice.dart';
import 'package:dices/app/modules/dices/classes/calculate_dice.dart';
import 'package:image/image.dart' as img;
import 'package:dices/app/services/score_service.dart';
import 'package:dices/app/shared/data/figures.dart';
import 'package:dices/app/shared/widgets/dropdown_button.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:image_picker/image_picker.dart';

import '../../../models/player.dart';

//Ridici trida pro stranku "Dices"
class DicesController extends GetxController {
  //Promenna pro komunikaci s tridou "ScoreService"
  final scoreService = Get.find<ScoreService>();
  //Listy s kostkami (Se kterymi se bude hazet a se kterymi ne)
  RxList<Dice> dices = <Dice>[].obs;
  RxList<Dice> stoppedDices = <Dice>[].obs;

  //Kontrola poctu hodu
  RxBool get isRollDisabled => dices.isEmpty.obs;
  RxInt get numberOfRolls => scoreService.numberOfRolls.obs;

  //Controller pro poslani dat do stranky "Home"
  TextEditingController figureValueController = TextEditingController();
  //Hrac ktery je narade
  RxInt get currentPlayer => scoreService.currentPlayer;

  Player? playingPlayer;

  int numberOnDice = 0;
  int numberOfScan = 0;

  AssetImage? image;
  RxDouble dotCount = 0.0.obs;
  @override
  void onInit() {
    //Naplneni promenych a nastaveni kostek na 1
    playingPlayer = scoreService.players[currentPlayer.value];
    dices = scoreService.rolledDices;
    stoppedDices = scoreService.stoppedDices;
    if (!scoreService.hasFirstRolled) {
      fillDices();
      scoreService.hasFirstRolled = true;
    }

    super.onInit();
  }

  @override 
  void onReady() {}
  @override
  void onClose() {
    scoreService.stoppedDices = stoppedDices;
  }

  //Funkce pro hozeni kostek
  void roll() {
    
    for (var d in stoppedDices){
      d.alreadyStopped = true;
    }
    scoreService.stoppedDices = stoppedDices;

    if (numberOfRolls == 0.obs && playingPlayer!.records[18].value != 0) {
      scoreService.numberOfRolls++;
      playingPlayer!.records[18].value--;
    }

    for (var d in dices) {
      
      d.rollNumber(); 
    } 
    scoreService.rolledDices = dices;
  }

  //Smazat
  Future<void> addDices() async {}

  //Presunuti kostky "Na stranu" z "Hazecich", aby se s ni nehazelo
  removeDice(int index) {
    stoppedDices.add(dices[index]);
    dices.removeAt(index);
    scoreService.rolledDices = dices;
  }
  //Presunuti kostky "Na strane" do "Hazecich" pro hazeni
  moveDice(int index) {
    dices.add(stoppedDices[index]);
    stoppedDices.removeAt(index);
    scoreService.rolledDices = dices;


    /*To, co tu bylo pred tim
    stoppedDices.add(dices[index]);
    dices.removeAt(index);
    scoreService.rolledDices = dices;
    */
  }
  //Nacteni kostek po skenovani
  updateDices() {
    Dice d = Dice(numberOfScan);
    d.count = numberOnDice.obs;
    d.number = numberOnDice;
    dices[numberOfScan] = d;
    scoreService.rolledDices = dices;
    numberOfScan == 5 ? numberOfScan = 0 : numberOfScan++;
  }
  //Pocatecni nastaveni kostek na 1
  fillDices() {
    dices.value = [];
    scoreService.rolledDices.value = [];
    for (var i = 0; i < 6; i++) {
      dices.add(Dice(i));
    }
    scoreService.rolledDices = dices;
  }
  //Konec kola, vyresetovani kostek a presun na dalsiho hrace
  nextPlayer() {
    scoreService.players[scoreService.currentPlayer.value].records[18].value += scoreService.numberOfRolls;
    scoreService.currentPlayer.value++;
    if (currentPlayer.value >= scoreService.players.length) {
      currentPlayer.value = 0;
    }
    scoreService.numberOfRolls = 3;
    reset();
  }
  //Reset kostek
  void reset() {
    stoppedDices.value = [];
    fillDices();
  }
  //Skenovani kostek z fotoaparatu podle barvy pixelu. (Test na jedne zlute kostce)
  void scan() async {
    
    dotCount = 0.0.obs;
    final tempImage = await ImagePicker().pickImage(source: ImageSource.camera);
    if (tempImage == null) return;

    // Ulož cestu
    final file = File(tempImage.path);
/*
    final result = await FilePicker.platform.pickFiles(
      type: FileType.image,
    );

    if (result == null) return;
*/
    Uint8List bytes = await file.readAsBytes();

    await countDiceDotsFromBytes(bytes).then((value) => numberOnDice = value);
    print("Počet: $numberOnDice");

    if (numberOnDice > 6){
      numberOnDice = 6;
    }
    if (numberOnDice < 1){
      numberOnDice = 1;
    }
    
    updateDices();
  }

  Color getFlutterColor(int abgr) {
    int argb = abgrToArgb(abgr);
    return Color(argb);
  }

  int abgrToArgb(int argbColor) {
    int r = (argbColor >> 16) & 0xFF;
    int b = argbColor & 0xFF;
    return (argbColor & 0xFF00FF00) | (b << 16) | r;
  }
  //Otevreni okna pro zapsani hodnoty
  void showAddRecordDialog(
    BuildContext context,
  ) {
    RxString selectedFigure = figuresDictionary.first.obs;
    onSelectedFigureChanged(String figure) {
      selectedFigure(figure);
    }

    List<String> figures = figuresDictionary.getRange(0, 18).toList();
    Get.dialog(
      AlertDialog(
        title: Text('Add record'),
        content: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Obx(
              () => DropDownButton<String>(
                items: figures
                    .map(
                      (figure) => DropdownMenuItem<String>(
                        child: Text(figure),
                        value: figure,
                      ),
                    )
                    .toList(),
                onValueChanged: (figure) => onSelectedFigureChanged(figure),
                value: selectedFigure.value,
              ),
            ),
            TextField(
              controller: figureValueController,
            )
          ],
        ),
        actions: [
          ElevatedButton(
            onPressed: () => {
              scoreService.changeRecord(
                  selectedFigure.value, figureValueController.text),
              Get.back(),
              nextPlayer(),
            },
            child: Text('Ok'),
            style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
          )
        ],
      ),
    );
  }
}
