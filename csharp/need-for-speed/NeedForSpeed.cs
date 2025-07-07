class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class

    private int speed;
    private int batteryDrain;
    private int distanceDriven;
    private int batteryPercentage = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return batteryPercentage < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += speed;
            batteryPercentage -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

}
    class RaceTrack
    {
        // TODO: define the constructor for the 'RaceTrack' class
        private int distance;

        public RaceTrack(int distance)
        {
            this.distance = distance;
        }

        public bool TryFinishTrack(RemoteControlCar car)
        {
            while (!car.BatteryDrained())
            {
                car.Drive();

                if (car.DistanceDriven() >= distance)
                {
                    return true;
                }
            }
            return false;
        }
    }
