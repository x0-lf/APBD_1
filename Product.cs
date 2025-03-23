namespace APBD_1;

public class Product
{
    private static Dictionary <int, Product> _dict = new Dictionary<int, Product>();

    private string _name = string.Empty;
    
    private double _temperature;
    private double _weight;

    private bool _isDangerous;
    private string _typeOfProduct = string.Empty;

    private static double _totalProductsWeight;

    public Product(string name, double temperature, double weight, bool isDangerous, string typeOfProduct)
    {
        Name = name;
        Temperature = temperature;
        Weight = weight;
        IsDangerous = isDangerous;
        TypeOfProduct = typeOfProduct;
    }

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Temperature
    {
        get => _temperature;
        set => _temperature = value;
    }

    public double Weight
    {
        get => _weight;
        set => _weight = value;
    }

    public bool IsDangerous
    {
        get => _isDangerous;
        set => _isDangerous = value;
    }

    public string TypeOfProduct
    {
        get => _typeOfProduct;
        set => _typeOfProduct = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static double TotalProductsWeight
    {
        get
        {
            double total = 0;
            foreach (var item in Dict)
            {
                total += item.Value.Weight;
            }
            return total;
        }
    }

    public static Dictionary<int, Product> Dict
    {
        get => _dict;
        set
        {
            _dict = value;
        }
    }
    
    public static void ClearProducts()
    {
        _dict.Clear();
        _totalProductsWeight = 0;
    }

    public override string ToString()
    {
        return $"Product: {Name}, Temperature: {Temperature}, Weight of Pallet: {Weight}";
    }
}