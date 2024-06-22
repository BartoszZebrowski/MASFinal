using MASFinal.Backend.Models;
using MASFinal.Backend.Services;

namespace MASFinal
{
    class Program
    {
        public static void PresentExtension()
        {
            var vehicleRepository = new VehicleRepository();
            var personRepository = new PersonRepository();
            var scheduleRepository = new SchedulRepository();

            var bus = new GroundVehicle(
                brand: "Ford",
                model: "Transit",
                dailyRentalPrice: 150.50m,
                numberOfSeats: 5,
                productionDate: new DateTime(2018, 5, 15),
                power: 180,
                mileage: 50000,
                category: DrivingLicencType.B,
                numberOfWheels: 4,
                rimSize: 18,
                trunkCapacity: 2000,
                typeOfBody: BodyType.Common
            );

            DriveType.CreateCombustionDrive(bus, 2000, 12);
            vehicleRepository.AddBus(bus);

            var camper = new GroundVehicle(
                brand: "Toyota ",
                model: "Hiace ",
                dailyRentalPrice: 300m,
                numberOfSeats: 4,
                productionDate: new DateTime(2020, 3, 12),
                power: 250,
                mileage: 230000,
                category: DrivingLicencType.C,
                numberOfWheels: 4,
                rimSize: 18,
                equipment: "Radio, Navigation",
                hasGenerator: true
            );

            DriveType.CreateHybridDrive(camper, 300, 200, 4000, 8);
            vehicleRepository.AddCamper(camper);

            var amphibian = new Amphibian(
                brand: "Gibbs ",
                model: "Humdinga",
                maximumLaunchAngle: 15.0m,
                driveSystem: DriveSystem.WaterScrew,
                requiresHelmsmanLicense: false,
                displacement: 6000.0m,
                dailyRentalPrice: 600.0m,
                numberOfSeats: 2,
                productionDate: new DateTime(2015, 2, 4),
                power: 120,
                mileage: 120000,
                category: DrivingLicencType.B,
                numberOfWheels: 4,
                rimSize: 16
            );

            DriveType.CreateCombustionDrive(amphibian, 4000, 15);
            vehicleRepository.AddAmphibian(amphibian);

            var boat = new Boat(
                brand: "Yamaha",
                model: "FX Cruiser",
                dailyRentalPrice: 150.0m,
                numberOfSeats: 2,
                productionDate: new DateTime(2021, 3, 15),
                power: 400,
                requiresHelmsmanLicense: true,
                displacement: 3000m,
                hasSail: false,
                canSleep: false
            );

            DriveType.CreateElectricDrive(boat, 1000, 230);
            vehicleRepository.AddBoat(boat);

            var mechanicAdress = new Address(
                street: "Urzednicza",
                houseNumber: 23,
                apartmentNumber: null,
                postalCode: "01-871",
                city: "Warszawa",
                country: "PL"
            );

            var mechanic = new Mechanic(
                dateOfEmployment: new DateTime(2020, 1, 15),
                grossSalary: 8000.0m,
                firstName: "Jan",
                lastName: "Kowalski",
                address: mechanicAdress,
                email: "jan.kowalski@wp.pl",
                phoneNumber: "000000000"
            );

            var clientAdress = new Address(
                street: "Złota",
                houseNumber: 10,
                apartmentNumber: 2,
                postalCode: "01-871",
                city: "Warszawa",
                country: "PL"
            );

            personRepository.AddMechanic(mechanic);

            var client = new Client(
                joiningDate: new DateTime(2023, 5, 30),
                discount: 3,
                firstName: "Andrzej",
                lastName: "Nowak",
                address: clientAdress,
                email: "andrzej.nowak@wp.pl",
                phoneNumber: "000000000"
            );
            personRepository.AddClient(client);

            Rent.CreateRent(client, bus, new DateTime(2024, 4, 10), new DateTime(2024, 4, 16));

            scheduleRepository.AddRent(bus);

            // dodawanie napraw jest zaprezentowane w przypadku uzycia z gui

            vehicleRepository.GetAllBuses();
            vehicleRepository.GetAllCampers();
            vehicleRepository.GetAllAmphibians();
            vehicleRepository.GetAllBoats();

            personRepository.GetAllClients();
            personRepository.GetAllMechanics();

            scheduleRepository.GetAllRents();
        }
    }
}
