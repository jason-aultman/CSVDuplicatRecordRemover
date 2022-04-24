// See https://aka.ms/new-console-template for more information
//A comma-separated values (CSV) file is a delimited text file that stores tabular data using the comma (',') character to separate plain text column (field) values, with each data record (row) separated by new line characters.This exercise entails making a console application that reads in a CSV file, finds duplicate entries, and writes the unique entries to a new CSV file.

//Requirements

//Read in a CSV file
using CSVDuplicatRecordRemover.Classes;

var fileHandler = new FileHandler();
Console.WriteLine("File path to parse: ");
var path = Console.ReadLine();
var fileInfo = fileHandler.GetFileData(path);

if (fileInfo != null)
{
    //Make all the rows in the CSV unique
    List<Tourney> distinct = fileInfo.GroupBy(_ => new { _.State, _.Course, _.Golfer }).Select(g => g.First()).ToList();

    //Write the data back out to another CSV file
    //The data in the resulting file should contain all of the unique entries in the file that was read in, without the duplicates
    var sucess = fileHandler.WriteFileData(distinct, path, "-trimmed");
    if (sucess)
    {
        Console.WriteLine("File parsing has been completed sucessfully");
    }

}
else
{
    Console.WriteLine("Unable to read data from specified file path");
}

