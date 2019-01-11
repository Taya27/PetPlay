#define LED_NUMBER 4
#define LEFT_LED 3
#define BOTTOM_LED 5
#define TOP_LED 10
#define RIGHT_LED 9

const int c = 261;
const int d = 294;
const int e = 329;
const int f = 349;
const int g = 391;
const int gS = 415;
const int a = 440;
const int aS = 455;
const int b = 466;
const int cH = 523;
const int cSH = 554;
const int dH = 587;
const int dSH = 622;
const int eH = 659;
const int fH = 698;
const int fSH = 740;
const int gH = 784;
const int gSH = 830;
const int aH = 880;

const int buzzerPin = 15;

int ledPins[] = {LEFT_LED, BOTTOM_LED, RIGHT_LED, TOP_LED};

void setup() {
  Serial.begin(9600);
  pinMode(buzzerPin, OUTPUT);
  for (int i = 0; i < LED_NUMBER; ++i) {
    pinMode(ledPins[i], OUTPUT);
  }
}

void loop() {
  if (Serial.available()) {
    byte rd[2];
    int readBytesNumber = Serial.readBytes(rd, 2);

    if (readBytesNumber == 1) {
      runRing();
    }
    else {
      if (rd[1] == 1) {
        turnOnLed(rd[0]);
      } else if (rd[1] == 0) {
        turnOffLed(rd[0]);
      }
    }
  }
}


bool turnOnLed(int pin) {
  if (isPinExists(pin)) {
    digitalWrite(pin, HIGH);
    return true;
  }

  return false;
}

bool turnOffLed(int pin) {
  if (isPinExists(pin)) {
    digitalWrite(pin, LOW);
    return true;
  }

  return false;
}

bool isPinExists(int pin) {
  for (int i = 0; i < LED_NUMBER; ++i) {
    if (ledPins[i] == pin) {
      return true;
    }
  }

  return false;
}

void runRing() {
  firstSection();
}

void beep(int note, int duration)
{
  tone(buzzerPin, note, duration);
  delay(duration);
  noTone(buzzerPin);
  delay(50);
}
 
void firstSection(){
  beep(a, 500);
  beep(a, 500);
  beep(a, 500);
  beep(f, 350);
  beep(cH, 150);
  beep(a, 500);
  beep(f, 350);
  beep(cH, 150);
  beep(a, 650);
   
  delay(500);
   
  beep(eH, 500);
  beep(eH, 500);
  beep(eH, 500);
  beep(fH, 350);
  beep(cH, 150);
  beep(gS, 500);
  beep(f, 350);
  beep(cH, 150);
  beep(a, 650);
   
  delay(500);
}
 
void secondSection()
{
  beep(aH, 500);
  beep(a, 300);
  beep(a, 150);
  beep(aH, 500);
  beep(gSH, 325);
  beep(gH, 175);
  beep(fSH, 125);
  beep(fH, 125);
  beep(fSH, 250);
   
  delay(325);
   
  beep(aS, 250);
  beep(dSH, 500);
  beep(dH, 325);
  beep(cSH, 175);
  beep(cH, 125);
  beep(b, 125);
  beep(cH, 250);
   
  delay(350);
}
