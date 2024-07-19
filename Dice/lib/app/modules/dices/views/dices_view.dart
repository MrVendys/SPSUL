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
      title: 'Dices',
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
                  padding: const EdgeInsets.all(15.0),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        'Current player: ${controller.scoreService.players[controller.scoreService.currentPlayer.toInt()].name}',
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
                      'Available  dices:',
                      style: TextStyle(fontSize: 40.0),
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        ...controller.dices.where((x) => x.position < 3).map((t) {
                          int index = controller.dices.indexOf(t);
                          return RolledDice(
                            count: t.count.value,
                            onTap: () => controller.removeDice(index),
                          );
                        }).toList(),
                      ],
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        ...controller.dices.where((x) => x.position > 2).map((t) {
                          int index = controller.dices.indexOf(t);
                          return RolledDice(
                            count: t.count.value,
                            onTap: () => controller.removeDice(index),
                          );
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
                      'Stopped dices:',
                      style: TextStyle(fontSize: 40.0),
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                         ...controller.stoppedDices.where((x) => controller.stoppedDices.indexOf(x) < 3).map(
                              (d) {
                          int index = controller.stoppedDices.indexOf(d);
                          return RolledDice(
                            count: d.count.value,
                            onTap: () => controller.moveDice(index),
                          );
                        }).toList(),
                        /*To, co tam bylo pred tim
                        ...controller.stoppedDices.where((x) => controller.stoppedDices.indexOf(x) < 3).map(
                              (d) => RolledDice(count: d.count.value),
                            )
                            .toList(),*/
                      ],
                    ),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        ...controller.stoppedDices.where((x) => controller.stoppedDices.indexOf(x) > 2).map(
                              (d) {
                          int index = controller.stoppedDices.indexOf(d);
                          return RolledDice(
                            count: d.count.value,
                            onTap: () => controller.moveDice(index),
                          );
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
                      child: Text('ROLL!'),
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
                child: Text('SCAN DICE'),
                style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
              ),
              //Tlacitko zapsat
              ElevatedButton(
                onPressed: () {
                  controller.showAddRecordDialog(context);
                },
                child: Text('ADD RECORD'),
                style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
              ),
              //Tlacitko Ukoncit kolo
              ElevatedButton(
                onPressed: () {
                  controller.nextPlayer();
                },
                child: Text('END TURN'),
                style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
