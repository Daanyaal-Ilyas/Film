bool run = true;

// Createing a new instance of the Functions class
Functions functions = new Functions();

//calling from FileCheck from the instance
functions.FileCheck();

while (run)
{
    functions.Menu();
    try
    {
       int input = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            // 1 is for Search for Film
            case 1:
                functions.DisplayFilmInfo();
                break;
            // 2 is for Search for Actora
            case 2:
                functions.DisplayActorsInfo();
                break;
            // 3 is for voting for a  Film
            case 3:
                functions.VoteFilm();
                break;
            // 4 is for voting for a  Actor
            case 4:
                functions.VoteActor();
                break;
            // 5 is for Displaying all Films
            case 5:
                functions.DisplayFilms();
                break;
            // 6 is for Displaying all Actors
            case 6:
                functions.DisplayActors();
                break;
            // 7 for quiting the program 
            case 7:
                functions.Save();
                run = false;
                break;
        }
        // checks if user input is more then 7 
        if (input > 7)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the numbers max is nubmer 7");
        }
    }
    // if users inputs other then numbers 
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Enter the numbers plz");
    }
}

