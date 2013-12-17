
#include <EEPROM.h>
#include <Password.h>
#include <Keypad.h>

//DEFINE RFID
#include <SoftwareSerial.h>
#include <Servo.h> 
 

#define RFIDEnablePin 12 // Enable Read
#define RFIDSerialRate 2400 

#define RxPin 10 //SOUT
#define TxPin 4 //Pin to write data to the Reader NOTE: The reader doesn't get written to, don't connect this line.
SoftwareSerial RFIDReader(RxPin,TxPin);

String RFIDTAG=""; //Holds the RFID Code read from a tag
String DisplayTAG = ""; //Holds the last displayed RFID Tag

Servo myservo;  
                
 
int cerrado = 0;   
int abierto = 180; 
int a = 1;//queda por programar las EEPROM para las 3 contraseñas
int valor;
int usuario = 0;
String newPasswordString1; 
String newPasswordString2;
String newPasswordString3;
char newPassword1[4]; 
char newPassword2[4];
char newPassword3[4];

Password password1 = Password ("1111");
Password password2 = Password ("2222");
Password password3 = Password ("3333");
 
byte maxPasswordLength = 4; 
byte currentPasswordLength = 0;
const byte ROWS = 4; 
const byte COLS = 4; 
char keys[ROWS][COLS] = {
  {'1','2','3','A'},
  {'4','5','6','B'},
  {'7','8','9','C'},
  {'*','0','#','D'}
};
byte rowPins[ROWS] = {6,7,8,9}; //connect to row pinouts 
byte colPins[COLS] = {2,3,4,5}; //connect to column pinouts

Keypad keypad = Keypad( makeKeymap(keys), rowPins, colPins, ROWS, COLS );





void setup(){
  
    RFIDReader.begin(RFIDSerialRate);
    pinMode(RFIDEnablePin,OUTPUT); 
    digitalWrite(RFIDEnablePin, LOW); // Nivel bajo el led SOUT
    Serial.begin(9600);        
    myservo.attach(11); // Enable del servo al pin 11
    
}

void loop(){
  char key = keypad.getKey();
   if (key != NO_KEY){
      delay(10); 
      switch (key){
      case 'A': break; 
      case 'B': break; 
      case 'C': break; 
      case 'D': changePassword(); break;
      //case '*': resetPassword(); break;
      default: processNumberKey(key);
      }
   }
   
   //***********************************
   
     myservo.write(cerrado); 
  
  if(RFIDReader.available() > 0) // If data available from reader
  { 
    ReadSerial(RFIDTAG);  //Lectura Puerto Serie
  if (RFIDTAG.equals("0F02781ECB")) //Si lee este codigo
   {
     digitalWrite(RFIDEnablePin, HIGH); // Enciende led RFID
     
     myservo.write(abierto);              
    delay(10); 
     
     delay(2000);
     digitalWrite(RFIDEnablePin, LOW); 
     Serial.println("1");
     
     myservo.write(cerrado);              
    delay(10); 
   }
   
  
    if (RFIDTAG.equals("0F02782183"))
   {
     digitalWrite(RFIDEnablePin, HIGH);
     
     myservo.write(abierto);               
    delay(10); 
     
     delay(2000);
     digitalWrite(RFIDEnablePin, LOW);
     Serial.println("2");
     
     myservo.write(cerrado);            
    delay(10); 
   }
   
   if (RFIDTAG.equals("0F02782183")||RFIDTAG.equals("0F02781ECB"))
   {
   }
   else
   {
   
          Serial.println("AD");
   }
   
  }
  
  
  //This only displays a tag once, unless another tag is scanned
  if(DisplayTAG!=RFIDTAG)
  {
    DisplayTAG=RFIDTAG;
   // Serial.println(RFIDTAG);
  }
   
   //***********************************
}
 
void processNumberKey(char key) {
   //Serial.print(key);
   currentPasswordLength++;
   password1.append(key);
   password2.append(key);
   password3.append(key);
   if (currentPasswordLength == maxPasswordLength) {
      checkPassword();
   } 
}

void checkPassword() {
   usuario = 0;
   if (password1.evaluate()){
     //Serial.println(" "); 
     Serial.println("1B");
      usuario = 1;} 
   else if (password2.evaluate()){
     //Serial.println(" "); 
     Serial.println("2B");
      usuario = 2;} 
   else if (password3.evaluate()){
     //Serial.println(" "); 
     Serial.println("3B");
      usuario = 3;} 
   else {
     //Serial.println(" ");
      Serial.println("CI");
   } 
     password1.reset(); 
     password2.reset(); 
     password3.reset(); 
     currentPasswordLength = 0;
}

void resetPassword() {
   if (usuario == 1){
     password1.reset();
     currentPasswordLength = 0;} 
   else if (usuario == 2){
     password2.reset(); 
     currentPasswordLength = 0;}
   else if (usuario == 3){
     password3.reset(); 
     currentPasswordLength = 0;}
   else{
     currentPasswordLength = 0;}
}

void changePassword() {
  switch (usuario){  
   case(1):
      newPasswordString1 = "4444";
      newPasswordString1.toCharArray(newPassword1, newPasswordString1.length()+1); 
      password1.set(newPassword1);
      resetPassword();
      Serial.println("CC1");
    break;
    case(2):
      newPasswordString2 = "5555";
      newPasswordString2.toCharArray(newPassword2, newPasswordString2.length()+1); 
      password2.set(newPassword2);
      resetPassword();
      Serial.println("CC2");
    break;
    case(3):
      newPasswordString3 = "6666";
      newPasswordString3.toCharArray(newPassword3, newPasswordString3.length()+1); 
      password3.set(newPassword3);
      resetPassword();
      Serial.println("CC3");
    break;
    }
}


//*******************
void ReadSerial(String &ReadTagString)
{
  int bytesread = 0;
  int  val = 0; 
  char code[10];
  String TagCode="";

  if(RFIDReader.available() > 0) {          // If data available from reader 
    if((val = RFIDReader.read()) == 10) {   // Check for header 
      bytesread = 0; 
      while(bytesread<10) {                 // Read 10 digit code 
        if( RFIDReader.available() > 0) { 
          val = RFIDReader.read(); 
          if((val == 10)||(val == 13)) {   // If header or stop bytes before the 10 digit reading 
            break;                         // Stop reading 
          } 
          code[bytesread] = val;           // Add the digit           
          bytesread++;                     // Ready to read next digit  
        } 
      } 
      if(bytesread == 10) {                // If 10 digit read is complete 

        for(int x=0;x<10;x++)              //Copy the Chars to a String
        {
          TagCode += code[x];
        }
        ReadTagString = TagCode;          //Update the caller
        while(RFIDReader.available() > 0) //Burn off any characters still in the buffer
        {
          RFIDReader.read();
        } 

      } 
      bytesread = 0;
      TagCode="";
    } 
  } 
}
//*******************

