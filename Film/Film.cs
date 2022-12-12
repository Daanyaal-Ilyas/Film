using System.Xml.Linq;

class Film
{
    private string title;
    private string director;
    private int year;
    private int votes;
    //Constructor for the Film class
    public Film(string title, string director, int year)
    {
        this.title = title;
        this.director = director;
        this.year = year;
        this.votes = 0;
    }
    public Film() 
    {

    }
    // OverRide ToString to get rid of the [] when printing out all the films 
    public override string ToString()
    {
        return $"{Title}";
    }
    //Property for the title of the film
    public string Title
    {
        get { return this.title; }
        set { this.title = value; }
    }

    //Property for the director of the film
    public string Director
    {
        get { return this.director; }
        set { this.director = value; }
    }

    //Property for the year of the film
    public int Year
    {
        get { return this.year; }
        set { this.year = value; }
    }

    //Property for the votes of the film
    public int Votes
    {
        get { return this.votes; }
        set { this.votes = value; }
    }
}