namespace practical3.inheritance;


internal class Team : Sponsor
{
    string TeamName { get; set; }

    public Team(string teamName)
    {
        this.TeamName = teamName;
    }

    /// <summary>
    /// This method will return void / nothing and will print _owner value and TeamName value.
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine($"Owner: {this._owner}, Team Name: {this.TeamName}");
    }

}
