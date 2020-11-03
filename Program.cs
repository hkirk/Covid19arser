using System.Text;
using System.IO;
using System;

namespace Covid19Data
{
  class Program
  {
    static void Main(string[] args)
    {
      ParseMunicipality();
      GenerateCitizens();
    }

    private static void ParseMunicipality()
    {
      string line = "";
      var reader = new StreamReader("./Municipality_test_pos.csv");
      var builder = new StringBuilder();
      var builderCSV = new StringBuilder();
      reader.ReadLine(); // Skip first
      while ((line = reader.ReadLine()) != null)
      {
        var data = line.Split(";");
        var population = float.Parse(data[4].Trim()) * 1000;
        builder.Append($"new Municipality({data[0].Trim()}, \"{data[1].Trim()}\", {population}),\n");
        builderCSV.Append($"{data[0].Trim()},{data[1].Trim()},{population},\n");

      }

      File.WriteAllText("./output/Municipality.output", builder.ToString());
      File.WriteAllText("./output/Municipality.csv", builderCSV.ToString());

      reader.Close();
    }

    static string[] Firstnames = new string[] {
      "Hans", "Jens", "Henrik", "Jesper", "Morten", "Mathias", "Alice", "Bob", "Mette", "Lene", "Hanne", "Lise", "Lise"
    };
    static string[] Lastnames = new string[] {
      "Hansen", "Jensen", "Olsen", "Mortensen", "Frederiksen", "Larsen"
    };
    static string[] Genders = new string[] { "female", "male", "either" };
    static Random random = new Random();
    public static void GenerateCitizens(int number = 100)
    {

      var builder = new StringBuilder();
      var builderCSV = new StringBuilder();

      for (var i = 0; i < number; i++)
      {
        var first = Firstnames[random.Next(Firstnames.Length)];
        var last = Lastnames[random.Next(Lastnames.Length)];
        var gender = Genders[random.Next(Genders.Length)];
        var age = random.Next(100);
        var ssn = $"{getDate()}{getMonth()}{getYear(age)}-{getControl()}";

        builder.Append($"new Citizen({i}, \"{first}\", \"{last}\", \"{ssn}\", {age}, \"{gender}\"),\n");
        builderCSV.Append($"{i},{first},{last},{ssn},{age},{gender}),\n");
      }

      File.WriteAllText("./output/Citizen.output", builder.ToString());
      //File.WriteAllText("./output/Citizen.csv", builderCSV.ToString());
    }

    public static string getDate()
    {
      return setZeroes(random.Next(28) + 1);
    }
    public static string getMonth()
    {
      return setZeroes(random.Next(12) + 1);
    }
    public static string getYear(int age)
    {
      var birthYear = 2020 - age;
      return birthYear.ToString().Substring(2);
    }
    public static string getControl()
    {
      return setZeroes(random.Next(10000), 4);
    }

    public static string setZeroes(int i, int length = 2)
    {
      return ("" + i).PadLeft(length, '0');
    }
  }
}
