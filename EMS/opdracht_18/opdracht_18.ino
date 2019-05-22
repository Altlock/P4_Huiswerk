#include <Servo.h>

const int servoPin = 9; // Must be PWM
const int analogPin = 0;

Servo s;

void setup() {
  
  s.attach(9);
  
  Serial.begin(9600);
}

void loop() {
  int sensorVal = analogRead(analogPin);
  Serial.println(sensorVal);
  int servoVal = map(sensorVal, 0, 1024, 0, 179);
  Serial.println(servoVal);
  s.write(servoVal);
}
