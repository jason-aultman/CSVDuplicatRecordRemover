using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVDuplicatRecordRemover.Classes
{
    public class FileHandler
    {
        public List<Tourney> GetFileData(string path)
        {
            List<Tourney> Matches = new List<Tourney>();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line = "";
                    while ((!reader.EndOfStream))
                    {

                        line = reader.ReadLine();
                        string[] values = line.Split(',', 3);

                        Matches.Add(new Tourney(values[0], values[1], values[2]));
                    }
                    return Matches;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return null;
        }
        public bool WriteFileData(List<Tourney> data, string path, string appendString)
        {
            path = path.Insert(path.Length - 4, appendString);
             bool success = WriteFileData(data, path);
            return success;
        }
        public bool WriteFileData(List<Tourney> data, string path)
        {
            //var pathln = path.Length - 4; //subtract 4 to account for ".csv"
            //path=path.Insert(pathln, "trm");
            var success = true;
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    if (new FileInfo(path).Exists)
                    {
                        Console.WriteLine("Output file with that name already exists, continue? y/n");
                        var answer = Console.ReadLine();
                        if (!answer.StartsWith('y'))
                        {
                            Console.WriteLine("User aborted write, exiting....");
                            return false;
                        }
                    }
                    foreach (Tourney tourney in data)
                    {
                        writer.WriteLine(tourney.State + "," + tourney.Course + "," + tourney.Golfer);
                    }
                }
            }catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                success = false;
            }

            return success;

        }


    }

}
