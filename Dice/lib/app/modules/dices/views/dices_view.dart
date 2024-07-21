// ignore_for_file: prefer_const_constructors

import 'package:dices/app/modules/dices/views/widgets/rolled_dice.dart';
import 'package:dices/app/shared/widgets/layout/custom_layout.dart';
import 'package:flutter/material.dart';

import 'package:get/get.dart';

import '../controllers/dices_controller.dart';
//Trida stavejici vzhled stranky "Dices"
class DicesView extends GetView<DicesController> {
  const DicesView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return CustomLayout(
      title: 'Hra',
      child: SizedBox(
        width: double.infinity,
        height: double.infinity,
        child: SingleChildScrollView(
          padding: const EdgeInsets.only(bottom: 25),
          scrollDirection: Axis.vertical,
          child: Column(
            children: [
              Obx(
                () => Padding(
                  padding: const EdgeInsets.all(25.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        'Aktuální hráč: ${controller.scoreService.players[controller.scoreService.currentPlayer.toInt()].name}',
                        style: TextStyle(fontSize: 28.0),
                      ),
                    ],
                  ),
                ),
              ),
              Obx(
                () => Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(
                      'Dostupné kostky:',
                      style: TextStyle(fontSize: 40.0),
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        ...controller.dices.where((x) => x.position < 3).map((t) {
                          int index = controller.dices.indexOf(t);
                          return controller.scoreService.numberOfRolls < 3 ? RolledDice(
                            count: t.count.value,
                            onTap: () => controller.removeDice(index),
                          ): RolledDice(count: t.count.value);
                        }).toList(),
                      ],
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        ...controller.dices.where((x) => x.position > 2).map((t) {
                          int index = controller.dices.indexOf(t);
                          return controller.scoreService.numberOfRolls < 3 ? RolledDice(
                            count: t.count.value,
                            onTap: () => controller.removeDice(index),
                          ): RolledDice(count: t.count.value);
                        }).toList(),
                      ],
                    ),
                  ],
                ),
              ),
              SizedBox(height: 50),
              Obx(
                () => Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Text(
                      'Odložené kostky:',
                      style: TextStyle(fontSize: 40.0),
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                         ...controller.stoppedDices.where((x) => controller.stoppedDices.indexOf(x) < 3).map(
                              (d) {
                                    int index = controller.stoppedDices.indexOf(d);
                                    return d.alreadyStopped == false ? RolledDice(
                                    count: d.count.value, 
                                    onTap: () => controller.moveDice(index),
                                    ) : RolledDice(count: d.count.value);
                                
                        }).toList(),
                      ],
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        ...controller.stoppedDices.where((x) => controller.stoppedDices.indexOf(x) > 2).map(
                              (d) {
                                    int index = controller.stoppedDices.indexOf(d);
                                    return d.alreadyStopped == false ? RolledDice(
                                    count: d.count.value, 
                                    onTap: () => controller.moveDice(index),
                                    ) : RolledDice(count: d.count.value);
                        }).toList(),
                      ],
                    )
                  ],
                ),
              ),
              SizedBox(
                height: 12,
              ),
              //Widget s tlacitky
              Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  //Tlacitko "Hazej" a reseni poctu probehlich hodu
                  Obx(
                    () => ElevatedButton(
                      onPressed: () {
                        if (controller.isRollDisabled.value ||
                            controller.numberOfRolls == 0.obs) {
                          return;
                        }
                        controller.scoreService.numberOfRolls--;
                        controller.roll();
                        
                      },
                      child: Text('HOD!'),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: controller.isRollDisabled.value
                            ? Colors.grey
                            : Colors.green,
                      ),
                    ),
                  ),
                  SizedBox(
                    width: 12,
                  ),
                  //Tlacitko "Reset"
                  ElevatedButton(
                    onPressed: () => controller.reset(),
                    child: Text('RESET!'),
                    style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
                  ),
                ],
              ),
              //Tlacitko "Naskenuj kostky"
              ElevatedButton(
                onPressed: () {
                  controller.scan();
                },
                child: Text('SKENOVAT'),
                style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
              ),
              //Tlacitko zapsat
              ElevatedButton(
                onPressed: () {
                  controller.showAddRecordDialog(context);
                },
                child: Text('ZAPSAT'),
                style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
              ),
              //Tlacitko Ukoncit kolo
              ElevatedButton(
                onPressed: () {
                  controller.nextPlayer();
                },
                child: Text('UKONČIT KOLO'),
                style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
