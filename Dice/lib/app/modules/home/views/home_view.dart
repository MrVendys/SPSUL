// ignore_for_file: prefer_const_constructors
import 'dart:math';

import 'package:dices/app/modules/home/views/widgets/index.dart';
import 'package:dices/app/shared/data/figures.dart';
import 'package:dices/app/shared/widgets/layout/custom_layout.dart';
import 'package:flutter/material.dart';

import 'package:get/get.dart';

import '../../../models/player.dart';
import '../controllers/home_controller.dart';

//Trida stavejici vzhled stranky "HomeView" (Zapisnik)
class HomeView extends GetView<HomeController> {
  HomeView({Key? key}) : super(key: key);
  final List<String> names = [
    "Dan",
    "Honza",
    "Matěj",
    "Pavel",
    "Jirka",
    "Štěpán",
    "Sára",
    "Vratislav",
    "Kuba",
    "Tomáš",
    "Květuše",
  ];
  //Nahodna jmena pro pripad, ze uzivatel nezada svoje
  @override
  Widget build(BuildContext context) {
    return CustomLayout(
      title: 'Skóre',
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: SingleChildScrollView(
          scrollDirection: Axis.vertical,
          child: Padding(
            padding: const EdgeInsets.only(left: 32),
            child: Obx(
              () => Row(
                children: [
                  Column(
                    children: [
                      ScoreRow(
                        title: "Figury",
                        values: controller.players
                            .map((player) => player.name)
                            .toList(),
                      ),
                      ...figuresDictionary
                          .map(
                            (figure) => ScoreRow(
                              title: figure,
                              values: controller.players
                                  .map((player) => player.records
                                      .firstWhere(
                                          (record) => record.figure == figure)
                                      .value
                                      .toString())
                                  .toList(),
                            ),
                          )
                          .toList(),
                    ],
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 12.0, right: 12.0),
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        SizedBox(
                          height: 100,
                          width: 100,
                          child: TextField(controller: controller.nameController),
                        ),
                        ElevatedButton(
                          onPressed: () {
                            controller.scoreService.players.add(Player(
                                controller.nameController.text == ""
                                    ? names[Random().nextInt(names.length)]
                                    : controller.nameController.text));
                            controller.nameController.text = "";
                          },
                          child: Text('Přidat hráče'),
                          //style: ElevatedButton.styleFrom(backgroundColor: Colors.green),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
