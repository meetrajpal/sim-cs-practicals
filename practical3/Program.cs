namespace practical3;

internal class Program
{
    public static void Main(String[] args)
    {
        Team teamObj = new Team("CSK");
        teamObj.PrintInfo();

        Bird bird = new Bird();
        bird.Voice();
        Bird duck = new Duck();
        duck.Voice();

        Laptop laptop = new Laptop();
        laptop.Brand = "Lenovo";
        laptop.Model = "Legion LOQ";
        laptop.LaptopDetails();
        // laptop.MotherboardDetails(); accessing this method will give error because it is private to its class
    }
}