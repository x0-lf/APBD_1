namespace APBD_1;

public class GasContainer : Container, IHazardNotifier
{

    private double _fivePercentCapacity;
    private double _pressure;
    public double FivePercentCapacity
    {
        get => _fivePercentCapacity;
        set => _fivePercentCapacity = value;
    }

    public double Pressure
    {
        
        get => _pressure;
        set => _pressure = value;
    }
    
    public GasContainer(string containerType, double containerWeight, double capacity, int height, int width, double pressure) 
        : base(containerType, containerWeight, capacity, height, width)
    {
        if (containerType != "G")
        {
            throw new ArgumentException("Container type must be G meaning GasContainer");
        }
        Pressure = pressure;
        FivePercentCapacity = capacity * 0.05;
    }

    public override void EmptyTheCargo()
    {
        Notify("Unloading The Gas Container:: ");
        Console.WriteLine("Removing Products: ");
        //Depending on the item, if removing item weight will take more than those 5%
        Console.WriteLine("Removing products, leaving 5% or more of cargo.");

        double weightToLeave = CargoWeight * 0.05;

        var productsSorted = ProductsOnTheShip.OrderBy(p => p.Value.Weight).ToList();

        double removedWeight = 0;
        foreach (var kvp in productsSorted)
        {
            if (CargoWeight - removedWeight - kvp.Value.Weight < weightToLeave)
            {
                break;
            }

            ProductsOnTheShip.Remove(kvp.Key);
            removedWeight += kvp.Value.Weight;
        }

        CargoWeight -= removedWeight;
        Console.WriteLine($"Removed {removedWeight} of cargo. Remaining: {CargoWeight}.");
        
        Console.WriteLine("Products remaining in the container");
        foreach (var product in ProductsOnTheShip.Values)
        {
            Console.WriteLine(product.ToString());
        }
    }
    
    public override void LoadTheContainer(Dictionary<int, Product> products)
    {
        Notify(SerialNumber,"Loading the Gas Container: ");
        if (products.Count == 0)
        {
            Console.WriteLine("No products to load.");
            return;
        }
        //dodac exception dla productow jesli nullorempty etc
        Console.WriteLine($"Products for this container: ");
        // foreach (var product in products)
        // {
        //     Console.WriteLine(product.ToString());
        // }

        //debug
        Console.WriteLine($"Products Capacity:  {Product.TotalProductsWeight}");
        Console.WriteLine($"Container Capacity: {Capacity}");
        
        try
        {
            if (Capacity >= Product.TotalProductsWeight + ContainerWeight)
            {
                foreach (var product in products)
                {
                    ProductsOnTheShip.Add(product.Key, product.Value);
                }
                CargoWeight = Product.TotalProductsWeight;
                
                Console.WriteLine($"The container has been loaded with products, the capacity left in the container {Capacity - Product.TotalProductsWeight}");
            }
            else
            {
                throw new OverfillException($"Unable to load the container with the Serial Number: {SerialNumber}. The total weight of the products is: ({Product.TotalProductsWeight}) and Weight of the container is ({ContainerWeight}) it's exceeds the container capacity ({Capacity}).");
            }
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"The container could not be loaded as it exceeds the capacity.");
        }
    }
    
    public void Notify(string containerNumber, string message)
    {
        
    }

    public void Notify(string message)
    {
        Console.WriteLine("WARNING: Loading dangerous container!!!");
    }
}