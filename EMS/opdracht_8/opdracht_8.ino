const int ldelay = 1000; // 1 sec delay == 1 hz

void setup() {
  DDRB = B00111111;
}

void loop() {
  for(int i = 8; i <= 13; i++){
    digitalWrite(i, HIGH);
    delay(ldelay);
  }

  for(int i = 13; i >= 8; i--){
    digitalWrite(i, LOW);
    delay(ldelay);
  }
  PORTB = B00111111;
  delay(ldelay);
  
  PORTB = B00000000;
  delay(ldelay);

}
