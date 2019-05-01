// Location of all lights
const int lights[] = {3,5,6,9,10,11};
const int ln = sizeof(lights) / sizeof(lights[0]);

void setup() {
  for(int pin : lights){
    pinMode(pin, OUTPUT);
  }
}

void fade(int pin, bool toBeOn){
  if(toBeOn){
    for(int i = 0; i < (255 / 3); i++){
      analogWrite(pin, (i * 3)); 
      delay(1);
    }
  }
  else {
    for(int i = (255 / 3); i > 0; i--){
      analogWrite(pin, (i * 3)); 
      delay(1);
    }
    digitalWrite(pin, LOW);
  }
}

void loop() {
  for(int i = 0; i < ln; i++){
    fade(lights[i], HIGH);
  }

  for(int i = 0; i < ln; i++){
    fade(lights[i], LOW);
  }
  
  for (int i = ln - 1; i >= 0; i--){
     fade(lights[i], HIGH);
  }
  for (int i = ln - 1; i >= 0; i--){
     fade(lights[i], LOW);
  }
}
