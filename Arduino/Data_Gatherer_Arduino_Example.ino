byte Delimiter[] = {13};
String Status = "0";
String HTTPBody = "";

void setup()
{
  Serial1.begin(9600);
  Serial.begin(9600);
}

void loop()
{
  delay(5000);
  WriteCommand("LIGHT:1");
  delay(2000);
  WriteCommand("LIGHT:0");
  delay(1000);
  WriteCommand("VIBRATE:500");
  delay(1000);
  WriteCommand("VIBRATE:500");
  delay(1000);
  WriteCommand("GETHTTP:www.google.co.uk");
  
  while(Status == "0")
  {
    Status = "0";
    WriteCommand("HTTPSTAT");
    Status = ReadSerial();
    delay(500);
  }
  
  if(Status = "1")
  {
    WriteCommand("HTTPRESP");
    HTTPBody = ReadSerial();
    Serial.println(HTTPBody);
    Serial.flush();
  }
  Status = "0";
  HTTPBody = "";
}

String ReadSerial()
{
  String data;
  
  while (Serial1.available())
  {
    delay(5);
    
    if (Serial1.available() >0)
    {
      char c = Serial1.read();
      
      if(c != Delimiter[0])
      {
        data += c;
      }
      else
      {
        return data;
      }
    } 
  }
}

void WriteCommand(String data)
{
  Serial1.print(data);
  Serial1.write(Delimiter, 1);
  Serial1.flush();
}
