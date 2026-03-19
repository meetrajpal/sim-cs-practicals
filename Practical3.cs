namespace sim_cs_practicals
{
    class Practical3
    {
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
            public void printInfo()
            {
                Console.WriteLine($"Owner: {this._owner}, Team Name: {this.TeamName}");
            }

        }


        public static void main(String[] args)
        {
            Team teamObj = new Team("CSK");
            teamObj.printInfo();
        }
    }
}
