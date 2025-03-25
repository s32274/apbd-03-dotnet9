namespace APBD_03;

public class CContainer : Container, IHazardNotifier
{
    private static Dictionary<string, double> productTemps = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19},
    };
    
    private double temperatureInside { get; set;  }
    private string? product { get; set; }
    
    public CContainer(double loadMass, double height, double ownMass, double depth, double maxLoad) 
        : base(loadMass, height, ownMass, depth, maxLoad, ContainerType.C)
    {
    }
    
    public CContainer(string product) : base(ContainerType.C)
    {
        this.product = product;
    }
    
    public string NotifyHazard(string message)
    {
        return "[" + GetSerialId() + "]: " + message;
    }

    public void setTemperatureInside(double temperatureInside)
    {
        this.temperatureInside = temperatureInside;
        if (temperatureInside > productTemps[product])
        {
            NotifyHazard("Temperature inside too high for product!");
        }
    }

    // public void setProduct(string product)
    // {
    //     if (this.product == null)
    //         this.product = product;
    // }
    
}