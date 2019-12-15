namespace VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        double LitersPerKM { get; }
        double FuelQuantity { get; }
        double TankCapacity { get; }
        bool IsVehicleEmpty { get; set; }    

        void Driving(double distance);
        void Refueling(double refuel);
    }
}
