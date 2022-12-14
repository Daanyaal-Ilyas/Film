class Actor
{
    private string name;
    private int age;
    private string country;
    private int votes;
    //Constructor for the Actor class
    public Actor(string name, int age, string country)
    {
        this.name = name;
        this.age = age;
        this.country = country;

    }
    //Property for the name of the actor
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    //Property for the age of the actor
    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    //Property for the country of the actor
    public string Country
    {
        get { return this.country; }
        set { this.country = value; }
    }
    public int Votes
    {
        get { return this.votes; }
        set { this.votes = value; }
    }
    // OverRide ToString to be able to print out the all Names of the Actors in the List 
    public override string ToString()
    {
        return string.Format("Name: {0}", Name);
    }
}