#include <SPI.h>
#include <Ethernet.h>

// network configuration.  gateway and subnet are optional.

// the media access control (ethernet hardware) address for the shield:
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };  
// the IP address for the shield:
IPAddress ip(192, 168, 1, 6);    

byte dns[] = {192,168,1,1};
// the router's gateway address:
byte gateway[] = { 192, 168, 1, 1 };
// the subnet:
byte subnet[] = { 255, 255, 255, 0 };

EthernetServer server(12345);

void setup()
{
  // initialize the ethernet device
  Ethernet.begin(mac, ip, dns, gateway, subnet);

  // start listening for clients
  server.begin();

  Serial.begin(9600);
  Serial.println("Serial available");
}

int msg[3];
int data =0; 

void loop()
{
  // if an incoming client connects, there will be bytes available to read:
  EthernetClient client = server.available();
  if (client) {
    for(byte i = 0; i < 3; i++){
      msg[i] = client.read();
    }
    data = getData(msg); 
  }
  
  analogWrite(2, pwmValue(data)); 
}

int getData(int msg[]){
  
  String returndata; 
  for(byte i = 0; i<3; i++){
    if(msg[i] > 47 && msg[i] < 58 ){
        returndata += (msg[i] - 48);
      }
  }
  Serial.print(returndata); 
  return returndata.toInt();
}

int pwmValue(int data){
  return data * 2; 
}
