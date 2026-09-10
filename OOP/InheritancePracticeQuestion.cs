using CSharpCodingPrep.Interfaces;

public class InheritancePracticeQuestion : IQuestion
{
    // TODO 1: Create a base class 'Vehicle' with:
    //         - a protected field '_brand' (string)
    //         - a public property 'Speed' { get; set; } (int)
    //         - a constructor(string brand) that initializes _brand
    //         - a public virtual method Drive() that prints "{Brand} is driving"
    //           (use the protected _brand field)
    //
    //         Create a derived class 'Car' (: Vehicle) with:
    //         - a public property 'NumberOfDoors' { get; set; } (int)
    //         - a constructor(string brand, int doors) that chains to base
    //           and initializes NumberOfDoors
    //         - an override of Drive() that calls base.Drive() first, then
    //           prints "Car with {NumberOfDoors} doors is cruising fast"
    //
    //         Create another derived class 'Bicycle' (: Vehicle) with:
    //         - a constructor(string brand) that chains to base
    //         - an override of Drive() that prints "{Brand} bicycle pedaling"
    //           (access _brand using 'protected' visibility)
    private class Vehicle
    {
        protected string _brand;
        public int Speed { get; set; }

        public Vehicle(string brand)
        {
            _brand = brand;
        }

        public virtual void Drive()
        {
            Console.WriteLine($"{_brand} is driving");
        }
    }

    private class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public Car(string brand, int doors) : base(brand)
        {
            NumberOfDoors = doors;
        }

        public override void Drive()
        {
            base.Drive();
            Console.WriteLine($"Car with {NumberOfDoors} doors is cruising fast");
        }
    }

    private class Bicycle : Vehicle
    {
        public Bicycle(string brand) : base(brand) { }

        public override void Drive()
        {
            Console.WriteLine($"{_brand} bicycle pedaling"); // direct access to protected field
        }
    }

    public void Run()
    {
        // TODO 2: Create one Car and one Bicycle object.
        //         Call Drive() on each to demonstrate polymorphism.
        //         Also print their Speed property (inherited from Vehicle).

        Car car1 = new Car("Toyota", 4);
        Bicycle cycle1 = new Bicycle("Hero");

        car1.Drive();
        cycle1.Drive();

        Console.WriteLine($"Toyota Speed: {car1.Speed}");
        Console.WriteLine($"Hero Speed: {cycle1.Speed}");
    }
}