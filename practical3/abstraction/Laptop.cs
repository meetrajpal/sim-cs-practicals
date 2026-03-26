namespace practical3.abstraction;

//Abstraction
internal class Laptop
{
    private string? brand;
    private string? model;
    public string Brand { get { return this.brand; } set { this.brand = value; } } // We can use short form also: public string Brand { get; set; } then we will not need to declare fields explicitly, private fields will be created automatically.
    public string Model { get { return this.model; } set { this.model = value; } }

    /// <summary>
    /// This method prints details about laptop and will return void / nothing
    /// </summary>
    public void LaptopDetails()
    {
        Console.WriteLine($"\nBrand: {this.Brand}");
        Console.WriteLine($"Model: {this.Model}");
        this.MotherboardDetails();
    }

    /// <summary>
    /// This method prints "Motherboard Details" and will return void / nothing.
    /// This method is private so it can not be accessed out side of the class but can be accessed inside the class
    /// </summary>
    private void MotherboardDetails()
    {
        Console.WriteLine("Motherboard Details");
    }
}
