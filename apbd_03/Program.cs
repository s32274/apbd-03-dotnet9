namespace APBD_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container1 = new LContainer(500, 250, 1000, 200, 2000);
            Container container2 = new CContainer(300, 220, 1200, 180, 1500);
            Container container3 = new GContainer(700, 270, 1500, 250, 2500);
            Container container4 = new GContainer(750, 300, 2000, 250, 2700);
            
            container1.Load(450);
            container2.Load(200);
            container3.Load(500);
            container4.Load(600);

            Console.WriteLine(container1.Info());
            Console.WriteLine(container2.Info());
            Console.WriteLine(container3.Info());
            Console.WriteLine(container4.Info());

            CargoShip ship1 = new CargoShip(15, 25, 50.0);
            CargoShip ship2 = new CargoShip(20, 50, 75.0);
            Console.Write("\tBEFORE LOAD: \n" + ship2.Info());
            for (int i = 0; i < 30; i++)
            {
                Container c = new LContainer(500, 250, 1000, 200, 2000);
                c.Load(5000);
                ship2.LoadContainerOnShip(c);
            }
            Console.Write("\tAFTER LOAD: \n" + ship2.Info());

            ship1.LoadContainerOnShip(container1);
            ship1.LoadContainerOnShip(container2);

            List<Container> containersToLoad = new List<Container> { container3, container4 };
            ship1.LoadContainersOnShip(containersToLoad);

            ship1.RemoveContainer(container2);

            Console.WriteLine("\tBEFORE UNLOADING CONTAINER ON ship 1:\n" + ship1.Info());
            container1.Unload();
            Console.WriteLine("\tAFTER UNLOADING CONTAINER ON ship 1:\n" + ship1.Info());

            ship1.SwapContainer(container1.GetSerialId(), container3);

            ship1.MoveContainer(container3, ship2);
            
            Console.WriteLine(ship1.Info());
        }
    }
}