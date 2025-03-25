namespace zadanie2.Models;

class GContainer: Container, IHazardNotifier
{
    private double pressure { get; }

    public GContainer(double maxLoad, double height, double depth, double ownMass, double pressure) : base(maxLoad, height, depth, ownMass, "G")
    {
        this.pressure = pressure;
    }

    public void loadContainer(double loadWeight, string cargoType)
    {
        if (currentLoad + loadWeight > maxLoad)
        {
            Notify("przekroczono limit wagowy kontenera na gaz - {serNumb}");
        }    
        base.loadContainer(loadWeight, cargoType);
    }

    public void unloadConteiner()
    {
        currentLoad = currentLoad * 0.05;
    }

    public void Notify(string msg)
    {
        Console.WriteLine("Warning: " + msg);
    }

    public string toString()
    {
        return base.toString() + $" cisnienie: {pressure}";
    }
}