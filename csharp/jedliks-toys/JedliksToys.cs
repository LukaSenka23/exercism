class RemoteControlCar
{
        int battery = 100;
        private int distanceDriven;
        
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {distanceDriven} meters";  
    }

    public string BatteryDisplay()
    {
        if (battery == 0)
        {
            return "Battery empty";
        }
        return $"Battery at {battery}%";
    }
    
    public void Drive()
    {
        if (battery > 0)
        {
            battery -= 1;
            distanceDriven += 20;
        }
        
    }
}