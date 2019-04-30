// Met deze variant van opdracht 7 kun je elke radius (met of zonder decimalen) sturen via serieel.
// Haal de comment tekens weg om een arbitraire limiet toe te voegen zoals in de opdracht 

#include <math.h>

float oppervlakte(float radius) {
  return M_PI * radius * radius;
}

void forloop(){

  for(int i = 1; i <= 10; i++) {
    Serial.println(oppervlakte(i));
  }
  Serial.flush();
}

float algebra() {
  const float px = 6;
  const float py = 8;
  const float pz = 4;
  const float mx = 3;
  const float my = 4;
  const float mz = 2;

  float straal = sqrt(sq(px-mx) + sq(py-my) + sq(pz-mz));
  return straal;
}


void setup() {
  Serial.begin(9600);
  
  Serial.println("Oppervlakte van cirkels met een radius van 1 t/m 10 (Opdracht B):");
  forloop();
  Serial.println("Berekening van opdracht C:");
  Serial.println(algebra());
}

void loop() {
  if (Serial.available()){
    float n = Serial.parseFloat();
    
    // Voorkomt dat de null-terminator elke keer wordt weergegeven.
    if(n == 0.0 /* && n <= 10.0*/) {return;}
    
    Serial.println(oppervlakte(n));
    Serial.flush();
  }
}
