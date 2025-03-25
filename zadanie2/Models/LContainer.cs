namespace zadanie2.Models;

class LContainer: Container, IHazardNotifier
{
    public bool isHazard { get; }

    public LContainer(double maxLoad, double height, double depth, double ownMass, bool isHazard) : base(maxLoad, height, depth, ownMass, "L")
    {
        this.isHazard = isHazard;
    }

    public void loadContainer(double loadWeight, string cargoType)
    {
        double limitedLoad = isHazard ? maxLoad * 0.5 : maxLoad * 0.9;
        if (currentLoad + loadWeight > limitedLoad)
        {
            Notify($"przekroczono limit wagowy kontenera na płyny - {serNumb}");
        }
        base.loadContainer(loadWeight, cargoType);
    }

    public void Notify(string msg)
    {
        Console.WriteLine("Warning: " + msg);
    }

    public string toString()
    {
        return base.toString() + $" isHazard: {isHazard}";
    }
}