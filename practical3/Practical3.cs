using sim_cs_practicals.practical3.abstraction;
using sim_cs_practicals.practical3.inheritance;
using sim_cs_practicals.practical3.polymorphism;

namespace sim_cs_practicals.practical3
{
    class Practical3
    {
        public static void main(String[] args)
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
}