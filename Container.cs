namespace APBD_1;
public class Container : IHazardNotifier
{
    private int _productId;
    
    private string _serialNumber = string.Empty;
    
    private double _cargoWeight;  //Masa ładunku (w kilogramach)
    private double _containerWeight; // Waga własna (samego kontenera w kilogramach)
    private double _capacity; // Maksymalna ładowność danego kontenera (w kilogramach)
    
    private int _height; //Wysokość (w centymetrach)
    private int _width; //Gębokość (w centymetrach)
        
    ///<summary>
    /// Te wartości są auto-increment podczas generacji serial container'u, 
    private static int _liquidTypeContainer;
    private static int _gasTypeContainer;
    private static int _coolerTypeContainer;
    
    private Dictionary <int, Product> _productsOnTheShip = new Dictionary<int, Product>();

    public Dictionary<int, Product> ProductsOnTheShip
    {
        get => _productsOnTheShip;
        private set => _productsOnTheShip = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Container(string containerType, double cargoWeight, double containerWeight, double capacity, int height, int width)
    {
        SerialNumber = containerType;
        
        CargoWeight = cargoWeight;
        ContainerWeight = containerWeight;
        Capacity = capacity;
        
        Height = height;
        Width = width;
    }

    public double CargoWeight
    {
        get => _cargoWeight;
        set => _cargoWeight = value;
    }

    public double ContainerWeight
    {
        get => _containerWeight;
        set => _containerWeight = value;
    }

    public double Capacity
    {
        get => _capacity;
        set => _capacity = value;
    }

    private int Height
    {
        get => _height;
        set => _height = value;
    }

    private int Width
    {
        get => _width;
        set => _width = value;
    }

    private int LiquidTypeContainer
    {
        get => _liquidTypeContainer;
        set => _liquidTypeContainer = value;
    }

    private int GasTypeContainer
    {
        get => _gasTypeContainer;
        set => _gasTypeContainer = value;
    }

    private int CoolerTypeContainer
    {
        set => _coolerTypeContainer = value;
        get => _coolerTypeContainer;
    }

    public string SerialNumber
    {
        set
        {
            switch (value)
            {
                case "L":
                    LiquidTypeContainer++;
                    _serialNumber = $"KON-L-{LiquidTypeContainer}";
                    break;
                case "G":
                    GasTypeContainer++;
                    _serialNumber = $"KON-G-{GasTypeContainer}";
                    break;
                case "C":
                    CoolerTypeContainer++;
                    _serialNumber = $"KON-C-{CoolerTypeContainer}";
                    break;
                default:
                    throw new Exception($"Invalid container type: {value}");
            }
        }
        get => _serialNumber;
    }

    public string toString()
    {
        return $"Serial number: {SerialNumber}, Cargo Weight: {CargoWeight}, Container Capacity {Capacity} Container Weight: {ContainerWeight},  Width: {Width}, Height: {Height}";
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

    public void LoadTheContainer(Dictionary<int, Product> products)
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
            if (Capacity >= Product.TotalProductsWeight)
            {
                foreach (var product in products)
                {
                    ProductsOnTheShip.Add(product.Key, product.Value);
                }
                Console.WriteLine($"The container has been loaded with products, the capacity left in the container {Capacity - Product.TotalProductsWeight}");
            }
            else
            {
                throw new OverfillException($"Unable to load the container with the Serial Number: {SerialNumber}. The total weight of the products is: ({Product.TotalProductsWeight}) and it's exceeds the container capacity ({Capacity}).");
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
        throw new NotImplementedException();
    }
}