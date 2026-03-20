namespace sim_cs_practicals
{
    class Practical3
    {
        //Inheritance
        class Sponsor
        {
            protected string _owner = "Rakuteen";
        }

        class Team : Sponsor
        {
            string TeamName  { get; set; }

            public Team(string teamName)
            {
                this.TeamName = teamName;
            }

            /*
             * 
             This method will print _owner value and TeamName value and will return nothing.
             */
            public void PrintInfo()
            {
                Console.WriteLine($"Owner: {this._owner}, Team Name: {this.TeamName}");
            }

        }


        // Polymorphism
        class Bird
        {
            /*
             *
             This method will return nothing and will print "Turr Turr"
             */
            public virtual void Voice()
            {
                Console.WriteLine("\nTurr Turr");
            }
        }

        class Duck : Bird
        {
            /*
             *
             This method will return nothing and will print "Quack Quack"
             */
            public override void Voice() // If we dont override the method then it will hide the method and when creating Parent (Bird) reference with Child (Duck) object then it will call Parent class method (prints Turr Turr) only
            {
                Console.WriteLine("\nQuack Quack");
            }
        }


        //Abstraction
        class Laptop
        {

            private string brand;
            private string model;
            public string Brand { get{ return this.brand; } set { this.brand = value; } } // We can use short form also: public string Brand { get; set; }
            public string Model { get { return this.model; } set { this.model = value;} }

            /*
             * 
             This method prints details about laptop and will return nothing
             */
            public void LaptopDetails()
            {
                Console.WriteLine($"\nBrand: {this.Brand}");
                Console.WriteLine($"Model: {this.Model}");
                this.MotherboardDetails();
            }

            /*
             * 
             This method prints "Motherboard Details" and will return nothing
             Also this method is private so it can not be accessed out side of the class but can be accessed inside the class
             */
            private void MotherboardDetails()
            {
                Console.WriteLine("Motherboard Details");
            }
        }

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
            laptop.Model = "Ideapad S145";
            laptop.LaptopDetails();
            // laptop.MotherboardDetails(); accessing this method will give error because it is private to its class
        }
    }
}
