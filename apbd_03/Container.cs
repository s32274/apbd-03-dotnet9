namespace APBD_03;

public abstract class Container
{
    private ContainerType containerType; // chłodnicze, na płyny, na gaz (C, L, G)
    private double loadMass;
    private double height;
    private double ownMass { get; }
    private double depth;
    private string serialID;
    private double maxLoad;

    public Container(double loadMass, double height, double ownMass, double depth, double maxLoad, ContainerType type)
    {
        this.containerType = type;
        serialID = GenerateSerialID();
        this.loadMass = loadMass;
        this.height = height;
        this.ownMass = ownMass;
        this.depth = depth;
        this.maxLoad = maxLoad;
    }

    public Container(ContainerType containerType)
    {
        this.containerType = containerType;
        serialID = GenerateSerialID();
    }

    private string GenerateSerialID()
    {
        return "KON-" + containerType + "-" + System.Guid.NewGuid();
    }

    public virtual double Unload()
    {
        loadMass = 0.0;
        return GetLoadMass();
    }

    public virtual void Load(double newLoad)
    {
        if (loadMass + newLoad > maxLoad)
        {
            throw new OverfillException("Cannot load more than max load");
        }
        else
        {
            this.loadMass += newLoad;
        }
    }

    public string GetSerialId()
    {
        return serialID;
    }
    public double GetLoadMass()
    {
        return loadMass;
    }

    public double GetMaxLoad()
    {
        return maxLoad;
    }

    public void SetType(ContainerType containerType)
    {
        this.containerType = containerType;
    }

    public void SetLoadMass(double loadMass)
    {
        this.loadMass = loadMass;
    }

    public double GetOwnMass()
    {
        return ownMass;
    }

    public double GetTotalMass()
    {
        return ownMass + loadMass;
    }
    
    public string Info()
    {
        string info =  $"Container ID: {serialID}\n" +
                       $"Type: {containerType}\n" +
                       $"Load Mass: {loadMass} kg\n" +
                       $"Height: {height} cm\n" +
                       $"Own Mass: {ownMass} kg\n" +
                       $"Depth: {depth} cm\n" +
                       $"Max Load: {maxLoad} kg\n";
        return info;
    }
}