namespace APBD_1;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _dangerousContainer;

    private double _capacityModifier;

    public bool DangerousContainer
    {
        get => _dangerousContainer;
        set => _dangerousContainer = value;
    }

    private double CapacityModifier
    {
        get => _capacityModifier;
        set => _capacityModifier = value;
    }
    
    public LiquidContainer(string containerType, double containerWeight, double capacity, int height, int width)
        : base(containerType, containerWeight, capacity, height, width)
    {
        if (containerType != "L")
        {
            throw new ArgumentException("Container type must be L meaning LiquidContainer");
        }
    }
    
    public override void LoadTheContainer(Dictionary<int, Product> products)
    {
        Console.WriteLine($"Loading the container with the serialNumber: {SerialNumber}");
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
            //check if cargo is dangerous
            
            //if yes = 50%
            
            //if no = 90%

            foreach (var product in products)
            {
                if (product.Value.IsDangerous)
                {
                    DangerousContainer = true;
                }
            }

            if (DangerousContainer)
            {
                CapacityModifier = 0.5;
                Notify($"Loading Container {SerialNumber} with dangerous cargo");
            }
            else
            {
                CapacityModifier = 0.9;
            }
            
            Console.WriteLine($"====Capacity after Modifier: {Capacity * CapacityModifier}()");
            
            if (Capacity * CapacityModifier >= Product.TotalProductsWeight + ContainerWeight)
            {
                foreach (var product in products)
                {
                    if (product.Value.IsDangerous)
                    {
                        // Console.WriteLine($"Product {product.Key} is Dangerous");
                        
                    }
                    ProductsOnTheShip.Add(product.Key, product.Value);
                }
                Console.WriteLine($"Contener + Produkty =({Product.TotalProductsWeight + ContainerWeight})");
                CargoWeight = Product.TotalProductsWeight;
                Console.WriteLine($"The container {SerialNumber} has been loaded with products, Weight of the Container {ContainerWeight}, the capacity left in the container {Capacity - Product.TotalProductsWeight}");
            }
            else
            {
                throw new OverfillException($"Unable to load the container with the Serial Number: {SerialNumber}." +
                                            $" The total weight of the products is: ({Product.TotalProductsWeight})" +
                                            $" The container weight is: ({ContainerWeight})" +
                                            $" and it's exceeds the container capacity ({Capacity}) " +
                                            $"or it does brake rules for loading the LiquidContainer such as dangerous products may be loaded up to" +
                                            $" 50% of Capacity and other Liquids may be loaded up to 90% of Capacity.");
            }
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"The container could not be loaded as it exceeds the capacity.");
        }
    }
    
    public void EmptyTheCargo()
    {
        
        // Console.WriteLine("All of the products before EmptyTheCargo");
        // foreach (var product in ProductsOnTheShip)
        // {
        //     Console.WriteLine(product.ToString());
        // }
        
        Console.WriteLine("Removing Products: ");
        foreach (var product in ProductsOnTheShip)
        {
            ProductsOnTheShip.Remove(product.Key);
        }
        
        // Console.WriteLine("All of the products after EmptyTheCargo");
        // foreach (var product in ProductsOnTheShip)
        // {
        //     Console.WriteLine(product.ToString());
        // }
    }

    public void Notify(string containerNumber, string message)
    {
        
    }

    public void Notify(string message)
    {
        Console.WriteLine("WARNING: Loading dangerous container!!!");
    }

    public string ToString()
    {
        return $"Serial number: {SerialNumber}, Cargo Weight: {CargoWeight}, Container Capacity {Capacity} Container Weight: {ContainerWeight},  Width: {Width}, Height: {Height}, DangerousContainer: {DangerousContainer}, CapacityModifier: {CapacityModifier}";
 
    }
    
}