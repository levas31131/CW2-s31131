namespace zadanie2.Models;

class CConteiner: Container
{
    private double temp { get; }
    private static Dictionary<string, double> WymaganeTemperatury = new Dictionary<string, double> {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };

    public CConteiner(double maxLoad, double height, double depth, double ownMass, double temp) : base(maxLoad, height, depth, ownMass, "C")
    {
        this.temp = temp;
      }
    
    public void loadContainer(double weight, string cargoType)
    {   
        
        
        if (this.cargoType != "none" && this.cargoType != cargoType)
        {
            throw new Exception($"Nie może być roznych ładunków!");
        }
        else if (WymaganeTemperatury.ContainsKey(cargoType) && temp < WymaganeTemperatury[cargoType]) {
            
            throw new Exception($"Temperatura kontenera nie może być niższa niż {WymaganeTemperatury[cargoType]}°C dla produktu {cargoType}!");
        }
        else
        {
            base.loadContainer(weight, cargoType);
        }
        
    }

    public string toString()
    {
        return base.toString() + $" temperatura:{temp}";
    }
}