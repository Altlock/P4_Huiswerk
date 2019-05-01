/* NOTE:

Eerst heb ik een versie gemaakt zonder fading, deze heb ik toen aangepast om ze te faden tijdens het aan/uit zetten.
Daarna heb ik op YouTube gezien dat de auto van 'Knight Rider' een andere soort fade heeft:
https://www.youtube.com/watch?v=oNyXYPhnUIs

Dit is een compleet nieuwe versie van het programma wat de echte look van Kitt nabootst.
*/

// Location of all lights
const int lights[] = {3,5,6,9,10,11};
const int ln = sizeof(lights) / sizeof(lights[0]);

const int block = (255 / 5); // Decides amount of fading (How many steps leds stay partially alive after being brightened)
const int fdelay = 100; // Decides speed

int lightvalues[] = {0,0,0,0,0,0};

void setup() {
  // Enable the lights
  for(int pin : lights){
    pinMode(pin, OUTPUT);
  }
}

void brighten(int light){
  // Bright led 'light', and lower all other lights by an amount of 'block'
  for(int i = 0; i < ln; i++){
    if (lightvalues[i] > 0){lightvalues[i] = lightvalues[i] - block;}
  }
  lightvalues[light] = 255;
}

void applyValues() {
  // Apply values of the array to the actual lights
  for(int i = 0; i < ln; i++){
    analogWrite(lights[i], lightvalues[i]);
  }
}

void loop() {
  // loop through all lights, back and forth
  for(int i = 0; i < ln; i++){
    brighten(i);
    applyValues();
    delay(fdelay);
  }
  for(int i = ln - 1; i >= 0; i--){
    brighten(i);
    applyValues();
    delay(fdelay);
  }
}
