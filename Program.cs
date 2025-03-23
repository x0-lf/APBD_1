using APBD_1;

Console.WriteLine("Hello, World!");

Dictionary <int, Product> coolerProducts = new Dictionary<int, Product>();
Dictionary <int, Product> gasProducts = new Dictionary<int, Product>();
Dictionary <int, Product> liquidProducts = new Dictionary<int, Product>();


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
Product honey = new Product("Honey", 18.0, 1400.0, false, "L");

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
liquidProducts.Add(26, gasoline);
liquidProducts.Add(27, mercury);
liquidProducts.Add(28, sulfuricAcid);
liquidProducts.Add(29, ethanol);
liquidProducts.Add(30, liquidChlorine);

// foreach (var product in Product.Dict)
// {
//     Console.WriteLine($"ID: {product.ToString()}");
// }

Product.Dict = gasProducts;
// Product.Dict = liquidProducts;
// Product.Dict = coolerProducts;

Product.TotalProductsWeight = Product.Dict.Count;

Container superContainer = new Container("C",1500.1,99.9,6000,180,180);
Console.WriteLine(superContainer.SerialNumber);
Console.WriteLine(superContainer.SerialNumber);

superContainer.LoadTheContainer(Product.Dict);

foreach (var product in superContainer.ProductsOnTheShip)
{
    Console.WriteLine($"ID: {product.ToString()}");
}

superContainer.EmptyTheCargo();
//Container.LoadTheContainer(superContainer, Product.Dict);
