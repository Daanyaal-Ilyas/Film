using System.Text.Json;

class Functions
{
    Dictionary<string, Film> Films = new Dictionary<string, Film>(20);
    List<Actor> Actors = new List<Actor>(20);
    private string film = ("films.txt");
    private string actor = ("actors.txt");

    public void FileCheck()
    {
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
    public  void Menu()
    {
        Console.WriteLine("/////////////////////////////////////////");
        Console.WriteLine("Welcome to the Films and Actors Search Program");
        Console.WriteLine("1. Search for a film");
        Console.WriteLine("2. Search for an actor");
        Console.WriteLine("3. Vote for a film");
        Console.WriteLine("4. Vote for a actor");
        Console.WriteLine("5. View All Films");
        Console.WriteLine("6. View All Actors");
        Console.WriteLine("7. Quit");
        Console.WriteLine("/////////////////////////////////////////");
        Console.Write("Enter your choice: ");

    }

    public  void DisplayFilmInfo()
    {
        Console.Write("Enter the film title: ");
        string filmtitle = Console.ReadLine().ToUpper();
        if (Films.ContainsKey(filmtitle))
        {
            Film film = Films[filmtitle];
            Console.WriteLine("Title: " + film.Title);
            Console.WriteLine("Director: " + film.Director);
            Console.WriteLine("Year: " + film.Year);
            Console.WriteLine("Votes: " + film.Votes);
        }
        else
        {
            Console.WriteLine("Film not found!");
        }
    }
    public void DisplayActorsInfo()
    {
        Console.Write("Enter the actor's name: ");
        string actorName = Console.ReadLine().ToUpper();

        //Checking if the actor exists in the list
        if (Actors.Any(a => a.Name == actorName))
        {
            Actor actor = Actors.First(a => a.Name == actorName);
            Console.WriteLine("Name: " + actor.Name);
            Console.WriteLine("Age: " + actor.Age);
            Console.WriteLine("Country: " + actor.Country);
            Console.WriteLine("Votes: " + actor.Votes);
        }
        else
        {
            Console.WriteLine("Actor not found!");
        }
    }
    public void VoteFilm()
    {
        Console.Write("Enter the film title: ");
        string filmvote = Console.ReadLine().ToUpper();
        //Checking if the film exists in the dictionary
        if (Films.Any(f => f.Value.Title == filmvote)) // Compare the string value to the Title property of the Film object
        {
            Film film = Films[filmvote]; // Access the Film object stored in the Films dictionary
            film.Votes++;
            Save();
            Console.WriteLine("Thank you for your vote");
        }
        else
        {
            Console.WriteLine("Film not found");
        }
    }
    public void VoteActor()
    {
        Console.Write("Enter the Actor Name: ");
        string actormvote = Console.ReadLine().ToUpper();
        //Checking if the film exists in the dictionary
        if (Actors.Any(a => a.Name == actormvote))
        {
            Actor actor = Actors.First(a => a.Name == actormvote);
            actor.Votes++;
            Save();
            Console.WriteLine("Thank you for your vote");
        }
        else
        {
            Console.WriteLine("Actor not found");
        }
    }
    public void Save()
    {
        string savefilm = JsonSerializer.Serialize(Films);
        File.WriteAllText("films.txt", savefilm);
        string saveactors = JsonSerializer.Serialize(Actors);
        File.WriteAllText("actors.txt", saveactors);
    }

    private void Load()
    {
        string datafilm = File.ReadAllText("films.txt");
        string dataactor = File.ReadAllText("actors.txt");
        Actors = JsonSerializer.Deserialize<List<Actor>>(dataactor);
        Films = JsonSerializer.Deserialize<Dictionary<string, Film>>(datafilm);
    }

    public void DisplayFilms()
    {
        Parallel.ForEach(Films, film =>
        {
            // Printing the Film thats in the Dictionary
            Console.WriteLine(film.Value);
        });
    }

    public void DisplayActors()
    {
        Parallel.ForEach(Actors, name =>
        {
            // Printing each Actor thats in the List
            Console.WriteLine(name.ToString());
        });
    }
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
