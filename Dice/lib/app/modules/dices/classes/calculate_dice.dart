import 'dart:typed_data';
import 'package:file_picker/file_picker.dart';
import 'package:image/image.dart' as img;


/// Spočítá puntíky na bílé kostce s černými puntíky.
Future<int> countDiceDotsFromBytes(Uint8List bytes) async {
  final decoded = img.decodeImage(bytes);
  if (decoded == null) throw Exception('Nelze dekódovat obrázek.');

  // 1) grayscale
  final gray = img.grayscale(decoded);

  // 2) Otsu práh nad celým obrázkem
  final threshold = _otsuThreshold(gray);

  // 3) Binarizace: tmavé pixely (puntíky) = foreground (1), jinak 0
  final w = gray.width, h = gray.height;
  final mask = Uint8List(w * h);
  for (int y = 0; y < h; y++) {
    for (int x = 0; x < w; x++) {
      final c = gray.getPixel(x, y);
      final l = _luma(c);
      mask[y * w + x] = (l < threshold) ? 1 : 0;
    }
  }

  // 4) Connected components (8-sousednost) + filtry tvaru/velikosti
  final visited = Uint8List(w * h);
  int dots = 0;

  // Heuristiky (relativní k velikosti obrázku)
  final totalArea = (w * h).toDouble();
  final minArea = (totalArea * 0.00002).clamp(15, 999999).toInt(); // spodní limit
  final maxArea = (totalArea * 0.02).toInt();                     // horní limit

  final neighbors = const [
    -1, -1,  0, -1,  1, -1,
    -1,  0,          1,  0,
    -1,  1,  0,  1,  1,  1,
  ];

  for (int y = 0; y < h; y++) {
    for (int x = 0; x < w; x++) {
      final idx = y * w + x;
      if (mask[idx] == 0 || visited[idx] == 1) continue;

      // BFS/DFS
      int minX = x, maxX = x, minY = y, maxY = y, area = 0;
      final stack = <int>[idx];
      visited[idx] = 1;

      while (stack.isNotEmpty) {
        final cur = stack.removeLast();
        final cy = cur ~/ w, cx = cur - cy * w;

        area++;
        if (cx < minX) minX = cx;
        if (cx > maxX) maxX = cx;
        if (cy < minY) minY = cy;
        if (cy > maxY) maxY = cy;

        for (int k = 0; k < neighbors.length; k += 2) {
          final nx = cx + neighbors[k];
          final ny = cy + neighbors[k + 1];
          if (nx < 0 || ny < 0 || nx >= w || ny >= h) continue;
          final nidx = ny * w + nx;
          if (visited[nidx] == 1 || mask[nidx] == 0) continue;
          visited[nidx] = 1;
          stack.add(nidx);
        }
      }

      // Filtry komponenty (aby se nepočítal šum)
      final bbW = maxX - minX + 1;
      final bbH = maxY - minY + 1;
      final bbArea = bbW * bbH;

      if (area < minArea || area > maxArea) continue;

      final aspect = bbW / bbH;
      if (aspect < 0.5 || aspect > 1.6) continue; // puntík ~ skoro kruh → bbox ~ čtverec

      final fill = area / bbArea;                  // jak „plný“ je bbox
      if (fill < 0.2 || fill > 0.9) continue;      // kruh ~ 0.5–0.8, odfiltruje čáry/šmouhy

      dots++;
    }
  }
  
  return dots;
}

/// Otsu threshold (0–255) nad grayscale obrázkem (balíček `image`).
int _otsuThreshold(img.Image gray) {
  final hist = List<int>.filled(256, 0);
  final w = gray.width, h = gray.height;
  final total = w * h;

  for (int y = 0; y < h; y++) {
    for (int x = 0; x < w; x++) {
      hist[_luma(gray.getPixel(x, y))]++;
    }
  }

  // celkový součet intenzit
  int sumAll = 0;
  for (int i = 0; i < 256; i++) sumAll += i * hist[i];

  int sumB = 0, wB = 0;
  double maxVar = -1.0;
  int threshold = 127;

  for (int t = 0; t < 256; t++) {
    wB += hist[t];
    if (wB == 0) continue;
    final wF = total - wB;
    if (wF == 0) break;

    sumB += t * hist[t];

    final mB = sumB / wB;             // průměr background
    final mF = (sumAll - sumB) / wF;  // průměr foreground
    final between = wB * wF * (mB - mF) * (mB - mF);

    if (between > maxVar) {
      maxVar = between;
      threshold = t;
    }
  }
  return threshold;
}

/// Vypočet jasu (luminance) z ARGB pixelu (int).
int _luma(int c) {
  final r = img.getRed(c);
  final g = img.getGreen(c);
  final b = img.getBlue(c);
  return (0.299 * r + 0.587 * g + 0.114 * b).round();
}