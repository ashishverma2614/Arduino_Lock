
String pass1= "1111";
String pass2= "2222";
String pass3= "3333";

#include <SoftwareSerial.h>

#define RxD 10
#define TxD 11

SoftwareSerial BTSerial(RxD, TxD);


String pass = "";
int pos = 0;
int cont  = 0;

void setup()
{
  
  
  BTSerial.flush();
  delay(500);
  BTSerial.begin(9600);
  Serial.begin(9600);

  BTSerial.print("AT\r\n");
  delay(10);

}

void loop()
{
  
     
       if(BTSerial.available()){
      	 pass += (char)BTSerial.read();
      	 pos++;
         }
       


  if(pass.equals(pass1)){
  Serial.println("x");
  cont = 0;
  pos = 0;
  pass = ""; 
  }  
  
  else if(pass.equals(pass2)){
  Serial.println("y");
  cont = 0;
  pos = 0;
  pass = ""; 
  }  
  
  else if(pass.equals(pass3)){
  Serial.println("w");
  cont = 0;
  pos = 0;
  pass = ""; 
  }  
  
  else if(pos == 4){
  Serial.println("z");
  cont = 0;
  pos = 0;
  pass = ""; 
  }
  
  delay(100);


}
