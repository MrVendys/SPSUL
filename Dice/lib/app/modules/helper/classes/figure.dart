class Figure {
  List<int> savedDices = [];

  String name;
  double percent = 0;
  int score = 0;

  Figure(this.name);

  setScoreAndPercent(double percent, int score){
    this.percent = percent;
    this.score = score;
  }

  setRolledDices(List<int> savedDices){
    this.savedDices = savedDices;
  }
}