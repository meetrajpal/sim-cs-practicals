namespace sim_cs_practicals.practical3.polymorphism
{

    class Duck : Bird
    {
        /// <summary>
        /// This method will return void / nothing and will print "Quack Quack"
        /// </summary>
        public override void Voice() // If we dont override the method then it will hide the method and when creating Parent (Bird) reference with Child (Duck) object then it will call Parent class method (prints Turr Turr) only
        {
            Console.WriteLine("\nQuack Quack");
        }
    }
}
