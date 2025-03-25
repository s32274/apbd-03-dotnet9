namespace APBD_03;

public class CargoShip
{
    private List<Container> containers { get; }
    private static int maxId = 1;
    private int id { get; }
    private double maxSpeed;
    private int maxContainersCount;
    private int currentContainerCount;
    private double currentLoadMass;
    private double maxContainersMass;

    public CargoShip(double maxSpeed, int maxContainersCount, double maxContainersMass)
    {
        id = maxId;
        maxId++;
        containers = new List<Container>();
        this.maxSpeed = maxSpeed;
        this.maxContainersCount = maxContainersCount;
        this.maxContainersMass = maxContainersMass;
    }

    public void LoadContainerOnShip(Container container)
    {
        if (containers.Count + 1 > maxContainersCount 
            || GetContainersWeight() + container.GetMaxLoad() + container.GetOwnMass() > 1000 * maxContainersMass)
            // bo jednostka ładowności kontenerowca to tona, a nie kilogram
        {
            Console.Write("Cannot load any more containers on ship " + id + "\n");
        }
        else
        {
            containers.Add(container);
            currentContainerCount += 1;
            currentLoadMass += 0.001 * container.GetTotalMass();
        }
    }

    public void LoadContainersOnShip(List<Container> containers)
    {
        if (containers.Count + 1 > maxContainersCount
            || GetContainersWeight() > 1000 * maxContainersMass)
        {
            Console.Write("Cannot load any more containers on ship " + id);
        }
        else
        {
            foreach (Container con in containers)
            {
                this.containers.Add(con);
                currentContainerCount += 1;
                currentLoadMass += 0.001 * con.GetTotalMass();
            }
        }
    }

    public void RemoveContainer(Container container)
    {
        containers.Remove(container);
        currentContainerCount -= 1;
        currentLoadMass -= 0.001 * container.GetTotalMass();
    }

    public void SwapContainer(string id, Container container)
    {
        foreach (Container currentContainer in containers)
        {
            if (currentContainer.GetSerialId().Equals(id))
            {
                // int index = containers.IndexOf(container);
                // if (index != -1)
                {
                    // containers.RemoveAt(index);
                    // containers.Insert(index, container);
                    RemoveContainer(currentContainer);
                    LoadContainerOnShip(container);
                    break;
                }
            }
        }

    }

    public void MoveContainer(Container container, CargoShip otherShip)
    {
        RemoveContainer(container);
        otherShip.LoadContainerOnShip(container);
    }

    public string Info()
    {
        RefreshCurrentLoad();
        string info = $"Transporter ID: {id}\n" +
                      $"Max Speed: {maxSpeed} knots\n" +
                      $"Current Containers Count: {currentContainerCount}\n" +
                      $"Max Containers Count: {maxContainersCount}\n" +
                      $"Max Containers Mass: {maxContainersMass} t\n" +
                      $"Current Load Mass: {currentLoadMass} t\n\n";
        foreach (Container c in containers)
        {
            info += "On ship " + GetId() + ": " + c.Info() + "\n";
        }
        return info;
    }

    public void RefreshCurrentLoad()
    {
        currentLoadMass = 0.0;
        foreach (Container c in containers)
        {
            currentLoadMass += 0.001 * c.GetTotalMass();
        }
    }

    public double GetContainersWeight()
    {
        double sumOfWeights = 0.0;
        foreach (Container c in containers)
        {
            sumOfWeights += c.GetMaxLoad(); 
            sumOfWeights += c.GetOwnMass();
        }

        return sumOfWeights;
    }

    public int GetId()
    {
        return id;
    }
}