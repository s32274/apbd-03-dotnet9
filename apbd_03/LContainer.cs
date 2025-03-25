using System.Transactions;

namespace APBD_03;

public class LContainer : Container, IHazardNotifier
{
    // Kontenery na płyny pozwalają na przewożenie ładunku niebezpiecznego (np. paliwo)
    // i ładunku zwykłego (np. mleko).

    private bool isLoadDangerous = false;

    public LContainer(double loadMass, double height, double ownMass, double depth, double maxLoad) 
        : base(loadMass, height, ownMass, depth, maxLoad, ContainerType.L)
    {
    }
    
    public override void Load(double newLoad)
    {
        if (isLoadDangerous)
        {
            if (GetLoadMass() + newLoad > 0.5 * GetMaxLoad())
            {
                //throw new OverfillException("Cannot load more than max load");
                NotifyHazard("contains dangerous load, cannot load more than 0.5 max load");
            }
        }
        else
        {
            if (GetLoadMass() + newLoad > 0.9 * GetMaxLoad())
            {
                //throw new OverfillException("Cannot load more than max load");
                NotifyHazard("contains safe load, but cannot load more than 0.9 max load");
            }
        }
    }

    public string NotifyHazard(string message)
    {
        return "[" + GetSerialId() + "]: " + message;
    }

}