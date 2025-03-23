namespace APBD_1;

public class CoolerContainer : Container, IHazardNotifier
{
    private double _maintainedTemperature;

    public double MaintainedTemperature
    {
        get => _maintainedTemperature;
        set => _maintainedTemperature = value;
    }

    public CoolerContainer(string containerType, double containerWeight, double capacity, int height, int width, double maintainedTemperature) 
        : base(containerType, containerWeight, capacity, height, width)
    {
        if (containerType != "C")
        {
            throw new ArgumentException("Container type must be C for CoolerContainer");
        }

        MaintainedTemperature = maintainedTemperature;
    }

    public override void LoadTheContainer(Dictionary<int, Product> products)
    {
        Console.WriteLine($"Loading Cooler Container with Serial Number: {SerialNumber}");

        if (products.Count == 0)
        {
            Console.WriteLine("No products to load.");
            return;
        }

        double minRequiredTemperature = products.Min(p => p.Value.Temperature);

        Console.WriteLine($"Maintained Temperature: {MaintainedTemperature}");
        Console.WriteLine($"Minimum Required Temperature by Products: {minRequiredTemperature}");

        if (MaintainedTemperature < minRequiredTemperature)
        {
            Notify($"Temperature inside the container ({MaintainedTemperature}) is too cold for the products (lowest required is {minRequiredTemperature}).");
            throw new OverfillException($"Temperature validation failed for Cooler Container: too cold.");
        }

        try
        {
            if (Capacity >= Product.TotalProductsWeight + ContainerWeight)
            {
                foreach (var product in products)
                {
                    ProductsOnTheShip.Add(product.Key, product.Value);
                }

                CargoWeight = Product.TotalProductsWeight;

                Console.WriteLine($"Cooler container loaded. Remaining capacity: {Capacity - CargoWeight}kg");
            }
            else
            {
                throw new OverfillException($"Cannot load Cooler Container: over capacity.");
            }
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void Notify(string containerNumber, string message)
    {
        Console.WriteLine($"[CoolerContainer {containerNumber}] ALERT: {message}");
    }

    public void Notify(string message)
    {
        Console.WriteLine($"[CoolerContainer ALERT] {message}");
    }

    public new string ToString()
    {
        return $"Serial number: {SerialNumber}, Cargo Weight: {CargoWeight}, Container Capacity {Capacity} Container Weight: {ContainerWeight},  Width: {Width}, Height: {Height}, Maintained Temperature: {MaintainedTemperature}";
    }
}