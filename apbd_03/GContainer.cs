namespace APBD_03;

public class GContainer : Container, IHazardNotifier
{
    private double pressure;

    public GContainer(double loadMass, double height, double ownMass, double depth, double maxLoad) 
        : base(loadMass, height, ownMass, depth, maxLoad, ContainerType.G)
    {
    }
    
    public override double Unload()
    {
        SetLoadMass(0.05 * GetLoadMass());
        return 0.95 * GetLoadMass();
    }
    
    public string NotifyHazard(string message)
    {
        return "[" + GetSerialId() + "]: " + message;
    }
}