namespace APBD_1;

public class Ship
{
    public string Name { get; set; }
    public double MaxSpeedKnots { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxWeightTons { get; set; } 
    
    private List<Container> _containersOnBoard = new();

    public Ship(string name, double maxSpeedKnots, int maxContainerCount, double maxWeightTons)
    {
        Name = name;
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainerCount = maxContainerCount;
        MaxWeightTons = maxWeightTons;
    }

    public bool LoadContainer(Container container)
    {
        double currentWeight = _containersOnBoard.Sum(c => c.CargoWeight + c.ContainerWeight);
        if (_containersOnBoard.Count >= MaxContainerCount || (currentWeight + container.CargoWeight + container.ContainerWeight) > MaxWeightTons * 1000)
        {
            Console.WriteLine($"Cannot load container {container.SerialNumber}, ContainerCount or ContainerMaxWeight is exceeded.");
            return false;
        }

        _containersOnBoard.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded onto ship {Name}.");
        return true;
    }

    public bool LoadContainers(List<Container> containers)
    {
        bool allLoaded = true;
        foreach (var container in containers)
        {
            if (!LoadContainer(container))
            {
                allLoaded = false;
            }
        }
        return allLoaded;
    }

    public bool RemoveContainer(string serialNumber)
    {
        var container = _containersOnBoard.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            _containersOnBoard.Remove(container);
            Console.WriteLine($"Container {serialNumber} removed from ship {Name}.");
            return true;
        }
        Console.WriteLine($"Container {serialNumber} not found.");
        return false;
    }

    public bool ReplaceContainer(string oldSerial, Container newContainer)
    {
        if (RemoveContainer(oldSerial))
        {
            return LoadContainer(newContainer);
        }
        return false;
    }

    public bool MoveContainerTo(Ship targetShip, string serialNumber)
    {
        var container = _containersOnBoard.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            Console.WriteLine($"Container {serialNumber} not found on ship {Name}.");
            return false;
        }

        if (targetShip.LoadContainer(container))
        {
            _containersOnBoard.Remove(container);
            Console.WriteLine($"Container {serialNumber} moved from {Name} to {targetShip.Name}.");
            return true;
        }

        return false;
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"\nShip Name: {Name}");
        Console.WriteLine($"Max Speed: {MaxSpeedKnots} knots");
        Console.WriteLine($"Max Containers: {MaxContainerCount}");
        Console.WriteLine($"Max Weight: {MaxWeightTons} tons");
        Console.WriteLine($"Current Containers: {_containersOnBoard.Count}");
        Console.WriteLine($"Total Weight (kg): {_containersOnBoard.Sum(c => c.CargoWeight + c.ContainerWeight)}");

        Console.WriteLine("=== Containers on board ===");
        foreach (var container in _containersOnBoard)
        {
            Console.WriteLine(container.ToString());
        }
    }

    public void PrintContainerInfo(string serialNumber)
    {
        var container = _containersOnBoard.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Console.WriteLine(container.ToString());
        }
        else
        {
            Console.WriteLine($"Container {serialNumber} not found on ship {Name}");
        }
    }
}
