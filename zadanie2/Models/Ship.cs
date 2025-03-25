namespace zadanie2.Models;

class Ship
{
    public string name { get; }
    private double maxSpeed { get; }
    private int maxConteinerCount { get; }
    private double maxWeight { get; }
    List<Container> containers = new List<Container>();

    public Ship(string name, double maxSpeed, int maxConteinerCount, double maxWeight)
    {
        this.name = name;
        this.maxSpeed = maxSpeed;
        this.maxConteinerCount = maxConteinerCount;
        this.maxWeight = maxWeight;
    }

    public void AddConteiner(Container container)
    {
        if (containers.Count >= maxConteinerCount)
        {
            throw new OverfillException("conteiners limit reached");
        }
        else if (getTotalWeight() + container.currentLoad + container.ownMass > maxWeight)
        {
            throw new OverfillException("weight limit reached");
        }
        containers.Add(container);
    }

    public void AddConteiners(List<Container> containerss)
    {
        if (containers.Count + containerss.Count > maxConteinerCount)
        {
            throw new OverfillException("conteiners limit reached");
        }
        
        if (getTotalWeight() + containerss.Sum(c =>c.ownMass + c.currentLoad) > maxWeight)
        {
            throw new OverfillException("weight limit reached");
        }

        containers.AddRange(containerss);
    }

    public void unloadConteiner(Container container)
    {
        containers.Remove(container);
    }

    public double getTotalWeight()
    {
        return containers.Sum(c =>c.ownMass + c.currentLoad);
    }

    public void printConteinersInfo()
    {
        Console.WriteLine($"Nazwa statku: {name}, maksymalna prędkość: {maxSpeed} węzłów, kontenerów: {containers.Count}/{maxConteinerCount}");

        foreach (var container in containers)
        {
            Console.WriteLine(container.toString());
        }
    }

    public void replaceConteiners(string serNum, Container container)
    {
        unloadConteiner(containers.Find(x => x.serNumb.Equals(serNum)));
        AddConteiner(container);
    }

    public void replaceConteinerFromShipToShip(Container container, Ship ship)
    {
        if (containers.Contains(container))
        {
            unloadConteiner(container);
            ship.AddConteiner(container);
        }
        
    }
}