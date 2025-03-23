using APBD_1;

Console.WriteLine("Hello, World!");

Dictionary <int, Product> coolerProducts = new Dictionary<int, Product>();
Dictionary <int, Product> gasProducts = new Dictionary<int, Product>();
Dictionary <int, Product> gasProducts2 = new Dictionary<int, Product>();
Dictionary <int, Product> liquidProducts = new Dictionary<int, Product>();
Dictionary <int, Product> dangerousLiquidProducts = new Dictionary<int, Product>();
Dictionary <int, Product> coolerProducts2 = new Dictionary<int, Product>();


// Products for Cooler
Product bananas = new Product("Bananas",13.3, 100.00,false,"C");
Product chocolate = new Product("Chocolate",18, 150.0,false,"C");
Product fish = new Product("Fish",2,400.0,false,"C");
Product meat = new Product("Meat",-15, 500.0,false,"C");
Product iceCream = new Product("Ice Cream",-18,250.0,false,"C");
Product frozenPizza = new Product("Frozen Pizza",-30,800.0,false,"C");
Product cheese = new Product("Cheese",7.2,600.0,false,"C");
Product sausages = new Product("Sausages",5, 440.0,false,"C");
Product butter = new Product("Butter",20.5,300.0,false,"C");
Product eggs = new Product("Eggs",19,750.0,false,"C");

coolerProducts.Add(1,bananas);
coolerProducts.Add(2,chocolate);
coolerProducts.Add(3,fish);
coolerProducts.Add(4,meat);
coolerProducts.Add(5,iceCream);
coolerProducts.Add(6,frozenPizza);
coolerProducts.Add(7,cheese);
coolerProducts.Add(8,sausages);
coolerProducts.Add(9,butter);
coolerProducts.Add(10,eggs);

// Gases
Product hydrogen = new Product("Hydrogen",-252.9, 500.0,true,"G");
Product oxygen = new Product("Oxygen",-183.0, 600.0,true,"G");
Product nitrogen = new Product("Nitrogen",-196.0, 550.0,true,"G");
Product methane = new Product("Methane",-161.5, 700.0,true,"G");
Product propane = new Product("Propane",-42.0, 800.0,true,"G");
Product butane = new Product("Butane",-0.5, 750.0,false,"G");
Product ammonia = new Product("Ammonia",-33.3, 650.0,false,"G");
Product chlorine = new Product("Chlorine",-34.0, 500.0,false,"G");
Product carbonMonoxide = new Product("Carbon Monoxide",-191.5, 400.0,false,"G");
Product sulfurDioxide = new Product("Sulfur Dioxide",-10.0, 450.0,false,"G");

gasProducts.Add(11, hydrogen);
gasProducts.Add(12, oxygen);
gasProducts.Add(13, nitrogen);
gasProducts.Add(14, methane);
gasProducts.Add(15, propane);
gasProducts.Add(16, butane);
gasProducts.Add(17, ammonia);
gasProducts.Add(18, chlorine);
gasProducts.Add(19, carbonMonoxide);
gasProducts.Add(20, sulfurDioxide);

// Safe liquids
Product water = new Product("Water", 0.0, 1000.0, false, "L");
Product milk = new Product("Milk", -4.0, 950.0, false, "L");
Product vegetableOil = new Product("Vegetable Oil", 20.0, 920.0, false, "L");
Product fruitJuice = new Product("Fruit Juice", 5.0, 980.0, false, "L");
//if we add 1 weight to the honey, it will be unable to load it for more than 90% of container = LiquidContainer
Product honey = new Product("Honey", 18.0, 1455.0, false, "L");


// Dangerous liquids
Product gasoline = new Product("Gasoline", -40.0, 750.0, true, "L");
Product mercury = new Product("Mercury", 25.0, 13546.0, true, "L");
Product sulfuricAcid = new Product("Sulfuric Acid", 10.0, 1800.0, true, "L");
Product ethanol = new Product("Ethanol", 20.0, 789.0, true, "L");
Product liquidChlorine = new Product("Liquid Chlorine", -34.0, 1560.0, true, "L");

liquidProducts.Add(21, water);
liquidProducts.Add(22, milk);
liquidProducts.Add(23, vegetableOil);
liquidProducts.Add(24, fruitJuice);
liquidProducts.Add(25, honey);
dangerousLiquidProducts.Add(26, gasoline);
dangerousLiquidProducts.Add(27, mercury);
dangerousLiquidProducts.Add(28, sulfuricAcid);
dangerousLiquidProducts.Add(29, ethanol);
dangerousLiquidProducts.Add(30, liquidChlorine);

// foreach (var product in Product.Dict)
// {
//     Console.WriteLine($"ID: {product.ToString()}");
// }

Product.Dict = gasProducts;
// Product.Dict = liquidProducts;
// Product.Dict = coolerProducts;

Container superContainer = new Container("C",90,6000,180,180);
Console.WriteLine(superContainer.ToString());

superContainer.LoadTheContainer(Product.Dict);

//check if it works +
Console.WriteLine("LOADED" + superContainer.ToString());

foreach (var product in superContainer.ProductsOnTheShip)
{
    Console.WriteLine($"ID: {product.ToString()}");
}

// superContainer.EmptyTheCargo();

// Console.WriteLine("Emptied" + superContainer.ToString());


//Container.LoadTheContainer(superContainer, Product.Dict);


//Testing liquid Container for safe products
//Clearing collection of Products to load new products into it:
Product.ClearProducts();
//Init Liquid Products
Product.Dict = liquidProducts;

LiquidContainer liquidContainer = new LiquidContainer("L",90,6000,180,180);
Console.WriteLine(liquidContainer.ToString());
liquidContainer.LoadTheContainer(Product.Dict);
Console.WriteLine(liquidContainer.ToString());
// liquidContainer.EmptyTheCargo();

Console.WriteLine(liquidContainer.ToString());


//Works well
//Clearing earlier positions
Product.ClearProducts();
//New Dangerous Liquid Products
Product.Dict = dangerousLiquidProducts;

//Testing Dangerous Container

//18535 * 2 = 37070
LiquidContainer dangerousLiquidContainer = new LiquidContainer("L",90,37070,180,180);
Console.WriteLine(dangerousLiquidContainer.ToString());
dangerousLiquidContainer.LoadTheContainer(Product.Dict);
Console.WriteLine(dangerousLiquidContainer.ToString());
// dangerousLiquidContainer.EmptyTheCargo();
Console.WriteLine(dangerousLiquidContainer.ToString());

Product.ClearProducts();

//Testing Gas
Product.Dict = gasProducts2;
gasProducts2.Add(11, hydrogen);
gasProducts2.Add(12, oxygen);
gasProducts2.Add(13, nitrogen);
gasProducts2.Add(14, methane);
gasProducts2.Add(15, propane);
gasProducts2.Add(16, butane);

GasContainer gasContainer = new GasContainer("G",90,4000,180,180,3000);
Console.WriteLine(gasContainer.ToString());
gasContainer.LoadTheContainer(Product.Dict);
Console.WriteLine(gasContainer.ToString());
// gasContainer.EmptyTheCargo();
Console.WriteLine(gasContainer.ToString());

Product.ClearProducts();
//Testing Cooler


CoolerContainer coolerContainer = new CoolerContainer("C", 90, 6000, 180, 180, 5); // maintained temp = 5°C

// coolerProducts2.Add(1,bananas);
// coolerProducts2.Add(2,chocolate);
coolerProducts2.Add(3,fish);
coolerProducts2.Add(4,meat);
coolerProducts2.Add(5,iceCream);
coolerProducts2.Add(6,frozenPizza);
// coolerProducts2.Add(7,cheese);
// coolerProducts2.Add(8,sausages);
// coolerProducts2.Add(9,butter);
// coolerProducts2.Add(10,eggs);

Product.Dict = coolerProducts2;

Console.WriteLine(coolerContainer.ToString());
coolerContainer.LoadTheContainer(Product.Dict);
Console.WriteLine(coolerContainer.ToString());
// coolerContainer.EmptyTheCargo();
Console.WriteLine(coolerContainer.ToString());

Ship ship1 = new Ship("SuperStatek", 300, 5, 20);
Ship ship2 = new Ship("NiedobryStatek", 20, 3, 15);

ship1.LoadContainer(coolerContainer);
ship1.LoadContainer(gasContainer);
ship1.LoadContainer(liquidContainer);

Console.WriteLine("Ship 1");
ship1.PrintShipInfo();

ship1.RemoveContainer(gasContainer.SerialNumber);
coolerContainer.EmptyTheCargo();
Console.WriteLine("Ship 1");
ship1.PrintShipInfo();

CoolerContainer replacementContainer = new CoolerContainer("C", 80, 5000, 180, 180, 5);
Dictionary<int, Product> replacementProducts = new()
{
    { 40, new Product("Tofu", 4.0, 300.0, false, "C") }
};
Product.ClearProducts();
Product.Dict = replacementProducts;
replacementContainer.LoadTheContainer(Product.Dict);
ship1.ReplaceContainer(liquidContainer.SerialNumber, replacementContainer);

Console.WriteLine("XXXXXXXXXXX");
Console.WriteLine("Ship1 po zmiennie produktow");
ship1.PrintShipInfo();
Console.WriteLine("XXXXXXXXXXX");


ship1.MoveContainerTo(ship2, coolerContainer.SerialNumber);

ship1.PrintShipInfo();
ship2.PrintShipInfo();

