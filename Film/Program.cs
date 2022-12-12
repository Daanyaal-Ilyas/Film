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

            case 1:
                functions.DisplayFilmInfo();
                break;
            case 2:
                functions.DisplayActorsInfo();
                break;
            case 3:
                functions.VoteFilm();
                break;
            case 4:
                functions.VoteActor();
                break;
            case 5:
                functions.DisplayFilms();
                break;
            case 6:
                functions.DisplayActors();
                break; 
            case 7:
                functions.Save();
                run = false;
                break;
        }

        if (input > 7)
        {
            Console.WriteLine("Enter the numbers max is nubmer 7");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Enter the numbers plz");
    }
}

