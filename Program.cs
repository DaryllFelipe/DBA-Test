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
{
    List<int> duplicatedValues = groupedNumbers.SelectMany(x => x).Distinct().ToList();
    duplicatedValues.Sort((a, b) => a.CompareTo(b));
    return duplicatedValues.AsEnumerable();
}

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
PrintNumbers(6);
#region Print Numbers

void PrintNumbers(int numbersToPrint)
{
    Console.WriteLine("\n");
    Console.WriteLine("\n");
    Console.WriteLine("\n");
    Console.WriteLine("Print Numbers");
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