// weekly mini-project 1
// Product list

var productList = new string[10]; // Declare a string array with size of 10.
var index = 0; // start an index to keep track of position in array.
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Produkt Lista"); // Give title of program
Console.ResetColor();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'");//user instructions
    Console.ResetColor();
    string userInput = Console.ReadLine(); //read user input
    if (userInput.ToLower().Trim() == "exit")
    {
        Console.WriteLine("Du angav följande produkter (sorterade):"); //writes the sorted list
        Array.Sort(productList);//sorts the list
        foreach (var product in productList)
        {
            if (product != null) //takes spaces off if there is not 10 items or more
            {
              Console.ForegroundColor = ConsoleColor.Green;
              Console.WriteLine(product);
              Console.ResetColor();
            }
        } 
        break;
    }

    var validIndex = userInput.IndexOf('-'); // checks for position of dash

    if (validIndex == -1) // checks for '-' in product number
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Felaktigt format på produktnumret. Vänligen ange produktnummer i formatet 'XXX-000'");
        Console.ResetColor();
        continue;
    }

    var vänsterSida = userInput.Substring(0, validIndex); // splits in to left and right sides
    var högerSida = userInput.Substring(validIndex + 1); // splits in to left and right sides

    

    if (int.TryParse(högerSida, out int result)) // checks if right side can be a number
    {
        // validates if the number is between 200-500
        bool greaterThan = result >= 200;
        bool lessThan = result <= 500;
        if (!greaterThan || !lessThan)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktigt format på högra delen av produktnumret. Vänligen ange produktnummer i formatet 'XXX-000'");
            Console.ResetColor();
            continue;
        }

    }
    else // error if not a number
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Felaktigt format på högra delen av produktnumret. Vänligen ange produktnummer i formatet 'XXX-000'");
        Console.ResetColor();
        continue;
    }

    foreach (var letter in vänsterSida) // validates that left side is letters
    {
        var validLetter = char.IsLetter(letter);

        if (!validLetter) //error if not letter
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktigt format på vänstra delen av produktnumret. Vänligen ange produktnummer i formatet 'XXX-000'");
            Console.ResetColor();
            continue;
        }
    }

    productList[index] = userInput; // add the user input to the array
    index++; // make the index point to the next spot in the array

    if (index >= productList.Length)
    {
        Array.Resize(ref productList, index); // resize array to fit elements added.  
    }
}