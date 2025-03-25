namespace zadanie2.Models;

class Container
{
    public double maxLoad { get;}
    public double currentLoad{get;set;}
    public double height { get; }
    public double depth { get; }
    public double ownMass { get; }
    private static int count = 1;
    public string serNumb { get; }
    public string cargoType { get; set; }

    protected Container(double maxLoad, double height, double depth, double ownMass, string contType)
    {
        serNumb = $"KON-{contType}-{count++}";
        this.maxLoad = maxLoad;
        this.height = height;
        this.depth = depth;
        this.ownMass = ownMass;
        this.cargoType = "none";
    }

    public void loadContainer(double loadWeight, string cargoType)
    {
        if (currentLoad + loadWeight > this.maxLoad)
        {
            throw new OverfillException("Overfill of {serNumb}") ;
        }
        this.currentLoad += loadWeight;
        this.cargoType = cargoType;
    }

    public void unloadConteiner()
    {
        this.currentLoad = 0;
        this.cargoType = "none";
    }

    public string toString()
    {
        return $"Kontener {serNumb}: ładunek: {cargoType}, załadowano: {currentLoad} kg of {maxLoad} kg, wysokość: {height}, głębokość: {depth}, waga własna: {ownMass} kg ";
    }
    
}   