using zadanie2.Models;

namespace zadanie2;

class Program
{
    static void Main(string[] args)
    {
        Ship ship1 = new Ship("Transfer-1", 20, 5, 2000);
        Ship ship2 = new Ship("Transfer-2", 20, 5, 5000);
        ship1.printConteinersInfo();
        ship2.printConteinersInfo();
        
        LContainer lContainer = new LContainer(1000, 100, 100, 200, false);
        GContainer gContainer = new GContainer(1000, 100, 100, 200, 5);
        CConteiner cConteiner = new CConteiner(1000, 100, 100, 200, 13.3);
        Console.WriteLine(lContainer.toString());
        Console.WriteLine(gContainer.toString());
        Console.WriteLine(cConteiner.toString());
        lContainer.loadContainer(900, "water");
        gContainer.loadContainer(900, "N2");
        cConteiner.loadContainer(1, "Bananas");
        // cConteiner.loadContainer(900, "Chocolate");
        
        Console.WriteLine(lContainer.toString());
        Console.WriteLine(gContainer.toString());
        Console.WriteLine(cConteiner.toString());
        
        ship1.AddConteiner(lContainer);
        ship2.AddConteiners([gContainer, cConteiner]);
        ship1.printConteinersInfo();
        ship2.printConteinersInfo();
        
        ship1.unloadConteiner(lContainer);
        ship1.printConteinersInfo();
        
        lContainer.unloadConteiner();
        Console.WriteLine(lContainer.toString());
        
        ship2.replaceConteiners("KON-G-2", lContainer);
        ship2.printConteinersInfo();
        
        ship1.AddConteiner(gContainer);
        ship1.printConteinersInfo();
        
        ship1.replaceConteinerFromShipToShip(gContainer, ship2);
        ship1.printConteinersInfo();
        ship2.printConteinersInfo();
        
        
    }
}