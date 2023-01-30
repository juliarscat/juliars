# a simple data visualizer for the neurosky mobile 2
import processing.serial.*;

Serial port;
int[] values = {0, 0, 0, 0};

void setup() {
  size(800, 400);
  port = new Serial(this, "COM3", 9600);
  port.bufferUntil('\n');
}

void draw() {
  background(255);
  noFill();
  stroke(0);
  int delta = height/5;
  for (int i = 0; i < 4; i++) {
    int y = height - (i * delta);
    rect(0, y, width, delta);
    line(0, y + delta/2, width, y + delta/2);
    ellipse(map(values[i], 0, 100, 0, width), y + delta/2, 5, 5);
  }
}

void serialEvent(Serial p) {
  String data = p.readStringUntil('\n');
  if (data != null) {
    String[] parts = split(data, ",");
    if (parts.length == 4) {
      for (int i = 0; i < 4; i++) {
        values[i] = int(parts[i]);
      }
    }
  }
}
