#region Print duplicated values
int[] arr = { 5, 1, 4, 6, 7, 3, 5, 7, 3 };
PrintDuplicatedValues(arr);
void PrintDuplicatedValues(int[] array)
{
    Console.WriteLine("Print Duplicated Numbers");
    IEnumerable<IGrouping<int, int>> groupedNumbers = GroupTheNumberArray(array);
    IEnumerable<int> duplicatedValues = ExtractTheValueOfTheGroupedNumbers(groupedNumbers);
    PrintValues(duplicatedValues);
}
IEnumerable<IGrouping<int, int>> GroupTheNumberArray(int[] array)
    => arr.GroupBy(x => x).Where(n => n.Count() == 2);

IEnumerable<int> ExtractTheValueOfTheGroupedNumbers(IEnumerable<IGrouping<int, int>> groupedNumbers)
    => groupedNumbers.SelectMany(x => x).Distinct().OrderBy(y => y).AsEnumerable();

void PrintValues(IEnumerable<int> duplicatedValues)
{
    foreach (int duplicatedValue in duplicatedValues)
    {
        foreach (var num in arr)
        {
            if (duplicatedValue == num) Console.Write(num);
        }
        Console.WriteLine();
    }
}
#endregion

#region Print Numbers
PrintNumbers(6);
void PrintNumbers(int numbersToPrint)
{
    Console.WriteLine("\n \n \nPrint Numbers");
    for (int i = 1; i <= numbersToPrint; i++)
    {
        for (int y = 1; y <= i; y++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }
}
#endregion

#region GetPercentage
Console.WriteLine("\n \n \nGet Percentage");
int NumberOfNewlyHiredMales = 0;
int NumberOfNewlyHiredFemales = 0;
int NumberOfPermanentMales = 0;
int NumberOfPermanentFemales = 0;
int NumberOfResignedMales = 0;
int NumberOfResignedFemales = 0;
GetTheCountOfNewHires("Enter the count of newly hired males", true);
GetTheCountOfNewHires("Enter the count of newly hired females", false);
GetTheCountWithPermanentPositions("Enter the count of permanent males", true);
GetTheCountWithPermanentPositions("Enter the count of permanent females", false);
GetTheCountOfResignedPersonnels("Enter the count of resigned males", true);
GetTheCountOfResignedPersonnels("Enter the count of resigned females", false);
PrintInfo("Hired Employees", NumberOfNewlyHiredMales, NumberOfNewlyHiredFemales);
PrintInfo("Permanent Employees", NumberOfPermanentMales, NumberOfPermanentFemales);
PrintInfo("Resigned Employees", NumberOfResignedMales, NumberOfResignedFemales);
void GetTheCountOfNewHires(string message, bool isMale)
{
    int numberOfNewlyHired = 0;
    try
    {
        Console.WriteLine(message);
        numberOfNewlyHired = Convert.ToInt32(Console.ReadLine());
        if (numberOfNewlyHired < 0) GetCountError("Error: Please enter a valid number", isMale ? "NumberOfNewlyHiredMales" : "NumberOfNewlyHiredFemales", () => GetTheCountOfNewHires(message, isMale));
        else
        {
            if(isMale) NumberOfNewlyHiredMales = numberOfNewlyHired;
            else NumberOfNewlyHiredFemales = numberOfNewlyHired;
        }
    }
    catch { GetCountError("Error: Please enter a valid number", isMale ? "NumberOfNewlyHiredMales" : "NumberOfNewlyHiredFemales", () => GetTheCountOfNewHires(message, isMale)); }
}

void GetTheCountWithPermanentPositions(string message, bool isMale)
{
    int numberOfPermanentPositions = 0;
    try
    {
        Console.WriteLine(message);
        numberOfPermanentPositions = Convert.ToInt32(Console.ReadLine());
        if (numberOfPermanentPositions < 0) GetCountError("Error: Please enter a valid number", isMale ? "NumberOfPermanentMales" : "NumberOfPermanentFemales", () => GetTheCountWithPermanentPositions(message, isMale));
        else
        {
            if (isMale) NumberOfPermanentMales = numberOfPermanentPositions;
            else NumberOfPermanentFemales = numberOfPermanentPositions;
        }
    }
    catch { GetCountError("Error: Please enter a valid number", isMale ? "NumberOfPermanentMales" : "NumberOfPermanentFemales", () => GetTheCountWithPermanentPositions(message, isMale)); }
}

void GetTheCountOfResignedPersonnels(string message, bool isMale)
{
    int numberOfResignedPersonnels = 0;
    try
    {
        Console.WriteLine(message);
        numberOfResignedPersonnels = Convert.ToInt32(Console.ReadLine());
        if (numberOfResignedPersonnels < 0) GetCountError("Error: Please enter a valid number", isMale ? "NumberOfResignedMales" : "NumberOfResignedFemales", () => GetTheCountOfResignedPersonnels(message, isMale));
        else
        {
            if (isMale) NumberOfResignedMales = numberOfResignedPersonnels;
            else NumberOfResignedFemales = numberOfResignedPersonnels;
        }
    }
    catch { GetCountError("Error: Please enter a valid number", isMale ? "NumberOfResignedMales" : "NumberOfResignedFemales", () => GetTheCountOfResignedPersonnels(message, isMale)); }
}

void PrintInfo(string message, int males, int females)
{
    double total = males + females;
    double maleAverage = Convert.ToDouble((males / total)) * 100;
    double femaleAverage = Convert.ToDouble((females / total)) * 100;
    Console.WriteLine($"Number of {message} = {total}");
    Console.WriteLine($"Male = {Math.Round(maleAverage, 2)}%");
    Console.WriteLine($"Female = {Math.Round(femaleAverage, 2)}%");
}

void GetCountError(string errorMessage, string propertyToReset, Action callback)
{
    Console.WriteLine($"\n{errorMessage}\n");
    ResetProperty(propertyToReset);
    callback.Invoke();
}

void ResetProperty(string propertyToReset)
{
    switch (propertyToReset)
    {
        case "NumberOfNewlyHiredMales":
            NumberOfNewlyHiredMales = 0;
            break;
        case "NumberOfNewlyHiredFemales":
            NumberOfNewlyHiredFemales = 0;
            break;
        case "NumberOfPermanentMales":
            NumberOfPermanentMales = 0;
            break;
        case "NumberOfPermanentFemales":
            NumberOfPermanentFemales = 0;
            break;
        case "NumberOfResignedMales":
            NumberOfResignedMales = 0;
            break;
        case "NumberOfResignedFemales":
            NumberOfResignedFemales = 0;
            break;
        default:
            break;
    }
}
#endregion