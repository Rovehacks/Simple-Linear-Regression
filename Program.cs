// See https://aka.ms/new-console-template for more information

Dataset dataset = new Dataset(new (float, float )[]
{
  (1, 2),
  (2, 4),
  (3, 6),
  (4, 8),
  (5, 10),
  (6, 12),
  (7, 14),
  (8, 16),
  (9, 18)
});

SLR slr = new SLR(dataset);

while(true)
{
  Console.WriteLine("Ingrese un valor para X (Sales)");
  var x = Convert.ToDouble(Console.ReadLine());
  Console.WriteLine($"El valor de 'y' (Advertising) es de {slr.GetFor(x)}");
}



public class SLR
{
  private Model model;
  public SLR(Dataset dataset)
  {
    model = new Model(dataset);
  }
  public double GetFor(double x) => model.b0 + (model.b1 * x);
}

 static class DiscMaths
  {
    public static float getXSummation(Dataset dataset)
    {
      float result = 0;

      foreach(var tuple in dataset.Data)
        result += tuple.X;

      return result;
    }
    public static float getYSummation(Dataset dataset)
    {
      float result = 0;

      foreach(var tuple in dataset.Data)
        result += tuple.Y;

      return result;
    }
    public static float getSquaredXSummation(Dataset dataset)
    {
      float result = 0;

      foreach(var tuple in dataset.Data)
        result+= (tuple.X*tuple.X);
  
      return result;
    }
    public static float getXYSummation(Dataset dataset)
    {
      float result = 0;

      foreach(var tuple in dataset.Data)
        result+= (tuple.X*tuple.Y);
  
      return result;
    }
  }
  class Model()
  {
    public readonly double b0;
    public readonly double b1;

    private double n;
    private double xSummation;
    private double ySummation;
    private double x2Summation;
    private double xySummation;

    public Model(Dataset dataset) : this()
    {
      n = dataset.Data.Length;
      xSummation = DiscMaths.getXSummation(dataset);
      ySummation = DiscMaths.getYSummation(dataset);
      x2Summation = DiscMaths.getSquaredXSummation(dataset);
      xySummation = DiscMaths.getXYSummation(dataset);

      b0 = ( (x2Summation * ySummation) - (xSummation * xySummation) ) / ( (n * x2Summation) - (xSummation * xSummation) );
      b1 = ( (n * xySummation) - (xSummation * ySummation) ) / ( (n * x2Summation) - (xSummation * xSummation) );
      Console.WriteLine($"y = {b0} + {b1}x");
    }
  }

public class Dataset((float,float)[] data)
{
  public (float X, float Y)[] Data { get; } = data;
}