using System.Text.Json;
class Functions
{
    Dictionary<string, Film> Films = new Dictionary<string, Film>(20);
    List<Actor> Actors = new List<Actor>(20);
    private string film = ("films.txt");
    private string actor = ("actors.txt");

    public void FileCheck()
    {
        // checking if files for actor and film exist 
        if (System.IO.File.Exists(film))
        {
            if (System.IO.File.Exists(actor))
            {
                Load();
            }
            else
            {
                ActorData();
                Save();
                Load();
            }
        }
        else if (System.IO.File.Exists(actor))
        {
            if (System.IO.File.Exists(film))
            {
                Load();
            }
            else
            {
                FilmData();
                Save();
                Load();
            }
        }
        else
        {
            FilmData();
            ActorData();
            Save();
            Load();
        }
    }
    //Menu
    public  void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("///////////////////////////////////////////////");
        Console.WriteLine("Welcome to the Films and Actors Search Program");
        Console.WriteLine("1. Search for a film");
        Console.WriteLine("2. Search for an actor");
        Console.WriteLine("3. Vote for a film");
        Console.WriteLine("4. Vote for a actor");
        Console.WriteLine("5. View All Films");
        Console.WriteLine("6. View All Actors");
        Console.WriteLine("7. Quit");
        Console.WriteLine("////////////////////////////////////////////////");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter your choice: ");

    }
    // Flim info Display
    public  void DisplayFilmInfo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter the film title: ");
        string filmtitle = Console.ReadLine().ToUpper();
        //Checking if the Flims  exists in the dictionary
        if (Films.ContainsKey(filmtitle))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Film film = Films[filmtitle];
            Console.WriteLine("Title: " + film.Title);
            Console.WriteLine("Director: " + film.Director);
            Console.WriteLine("Year: " + film.Year);
            Console.WriteLine("Votes: " + film.Votes);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Film not found!");
        }
    }
    // Actor info Display
    public void DisplayActorsInfo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter the actor's name: ");
        string actorName = Console.ReadLine().ToUpper();

        //Checking if the actor exists in the list
        if (Actors.Any(a => a.Name == actorName))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Actor actor = Actors.First(a => a.Name == actorName);
            Console.WriteLine("Name: " + actor.Name);
            Console.WriteLine("Age: " + actor.Age);
            Console.WriteLine("Country: " + actor.Country);
            Console.WriteLine("Votes: " + actor.Votes);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Actor not found!");
        }
    }
    // Voting for Film 
    public void VoteFilm()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter the film title: ");
        string filmvote = Console.ReadLine().ToUpper();
        //Checking if the film exists in the dictionary
        if (Films.Any(f => f.Value.Title == filmvote))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Film film = Films[filmvote]; 
            film.Votes++;
            Save();
            Console.WriteLine("Thank you for your vote");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Film not found");
        }
    }
    // Voting for Actor 
    public void VoteActor()
    {
        Console.Write("Enter the Actor Name: ");
        string actormvote = Console.ReadLine().ToUpper();
        //Checking if the actor exists in the list
        if (Actors.Any(a => a.Name == actormvote))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Actor actor = Actors.First(a => a.Name == actormvote);
            actor.Votes++;
            Save();
            Console.WriteLine("Thank you for your vote");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Actor not found");
        }
    }
    // Save 
    public void Save()
    {
        string savefilm = JsonSerializer.Serialize(Films);
        File.WriteAllText("films.txt", savefilm);
        string saveactors = JsonSerializer.Serialize(Actors);
        File.WriteAllText("actors.txt", saveactors);
    }
    // Loading Actor and Film files
    private void Load()
    {
        string datafilm = File.ReadAllText("films.txt");
        string dataactor = File.ReadAllText("actors.txt");
        Actors = JsonSerializer.Deserialize<List<Actor>>(dataactor);
        Films = JsonSerializer.Deserialize<Dictionary<string, Film>>(datafilm);
    }
    //Displaying all Films
    public void DisplayFilms()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Parallel.ForEach(Films, film =>
        {
            // Printing the Film thats in the Dictionary
            Console.WriteLine(film.Value);
        });
    }
    //Displaying all Actors
    public void DisplayActors()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Parallel.ForEach(Actors, name =>
        {
            // Printing each Actor thats in the List
            Console.WriteLine(name.ToString());
        });
    }
    // Data for Films called when the files need to be create
    private void FilmData()
    {
        Films.Add("BLACK ADAM", new Film("BLACK ADAM", "JAUME COLLET-SERRA", 2022));
        Films.Add("EMANCIPATION", new Film("EMANCIPATION", "ANTOINE FUQUA", 2022));
        Films.Add("PREY FOR THE DEVIL", new Film("PREY FOR THE DEVIL", "DANIEL STAMM", 2022));
        Films.Add("ALONE", new Film("ALONE", "JOHN HYAMS", 2020));
        Films.Add("THE EMPTY MAN", new Film("THE EMPTY MAN", "DAVID PRIOR", 2020));
        Films.Add("GREYHOUND", new Film("GREYHOUND", "AARON SCHNEIDER", 2020));
        Films.Add("JAWANI PHIR NAHI ANI 2", new Film("JAWANI PHIR NAHI ANI 2", "NADEEM BAIG", 2018));
    }
    // Data for Actor called when the files need to be create
    private void ActorData()
    {
        Actors.Add(new Actor("DWAYNE JOHNSON", 50, "UNITED STATES"));
        Actors.Add(new Actor("TOM HANKS", 66, "UNITED STATES"));
        Actors.Add(new Actor("DANIEL RADCLIFFE", 33, "UNITED KINGDOM"));
        Actors.Add(new Actor("EMMA WATSON", 32, "UNITED KINGDOM"));
        Actors.Add(new Actor("RUPERT GRINT", 34, "UNITED KINGDOM"));
        Actors.Add(new Actor("FEROZE KHAN", 32, "PAKISTAN"));
        Actors.Add(new Actor("FAHAD MUSTAFA", 39, "PAKISTAN"));
    }
}
