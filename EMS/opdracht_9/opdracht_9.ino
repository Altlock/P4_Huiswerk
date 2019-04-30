void printParts(String s) {
  // prints every char of string s on a seperate line

  Serial.println(s[0]);
  Serial.println(s[s.length() - 1]);

  // More efficient use of memory with small strings
  if(s.length() <= 256){
    for(byte i = 1; i < s.length() - 1; i++){
      Serial.println(s[i]);
    }
  }
  else {
    for(int i = 1; i < s.length() - 1; i++){
      Serial.println(s[i]);
    }
  }
}

void printFormats(char c) {
  // prints char c in all formats noted in types[].
  
  Serial.print(c);
  
  //Octal and Ternary added for fun.
  int types[] = {DEC, HEX, BIN, OCT, 3};
  
  for(int i : types){
    Serial.print(' ');
    Serial.print(c, i);
  }
  Serial.println();
}

void charToLed(char c){
  // Displays binary value of char on 6 leds,
  // discarding the 2 least significant bits.
  
  DDRB = B00111111;
  // Shift the 2 least significant bits out of the char,
  // since we only have 6 leds
  char bitshifted = c >> 2; 
  printFormats(c);
  printFormats(bitshifted);
  PORTB = bitshifted;
}

void stringToLed(String s){
  // Prints every char of the string s to the leds, at 1 hz.
  
  for(char c : s){
      charToLed(c);
      delay(1000);
    };
}

void setup() {
  // put your setup code here, to run once:
  const String s1 = "0123456789";
  const String c1 = "a";
  const String c2 = String(c1);
  
  String s2 = String("bcdefghij");

  Serial.begin(9600);
  Serial.println(s1);
  Serial.println(c1);
  Serial.println(s2);
  Serial.println(c2);

  s2 = c1 + s2 + "j";
  Serial.println(s2);

  printParts(s1);
  printParts(s2);

  for(char c : s1){printFormats(c);}
  for(char c : s2){printFormats(c);}

  charToLed(s1[5]);
  delay(5000);
  
  stringToLed(s1);
  stringToLed(s2);
}

void loop() {
  // put your main code here, to run repeatedly:

}
