void setup() {
  DDRB = B00111111;
  }

byte appendOne(byte b){
  if(b == 0){
    b++;
  }
  else {
    b = b << 1;
    bitWrite(b, 0, 1);
  }
  return b;
}

byte intToByteLength(int i){
  byte r = 0;
  while(i > 0){
    r = appendOne(r);
    i--;  
  }
  return r;
}


void loop() {
  int z = analogRead(A0);
  int numberOfLeds = z / (1023 / 6);
  byte output = intToByteLength(numberOfLeds);
  PORTB = output;
}
