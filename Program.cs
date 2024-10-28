// See https://aka.ms/new-console-template for more information

var dataSet = new (float X,float Y)[]
{
  (651,23),
  (762,26),
  (856,30),
  (1063,34),
  (1190,43),
  (1298,48),
  (1421,52),
  (1440,57),
  (1518,58)
};


int n = dataSet.Length;
float b0 =((getSquaredXSummation() * getYSummation())-(getXSummation()*getXYSummation()))/((n*getSquaredXSummation())-(getXSummation() * getXSummation()));
float b1 =((n * getXYSummation())-(getXSummation()*getYSummation()))/((n*getSquaredXSummation())-(getXSummation() * getXSummation()));

Console.WriteLine($"y = {b0} + {b1}x");
while(true)
{
  Console.WriteLine("Ingrese un valor para X (Sales)");
  var x = Convert.ToDouble(Console.ReadLine());
  Console.WriteLine($"El valor de 'y' (Advertising) es {b0 + (b1 * x)}");
}

float getXSummation()
{
  float result = 0;

  foreach(var tuple in dataSet)
    result += tuple.X;

  return result;
}


float getYSummation()
{
  float result = 0;

  foreach(var tuple in dataSet)
    result += tuple.Y;

  return result;
}


float getSquaredXSummation()
{
  float result = 0;

  foreach(var tuple in dataSet)
    result+= (tuple.X*tuple.X);
  
  return result;
}

float getXYSummation()
{
  float result = 0;

  foreach(var tuple in dataSet)
    result+= (tuple.X*tuple.Y);
  
  return result;
}
