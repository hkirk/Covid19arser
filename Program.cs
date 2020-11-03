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
  }
}
