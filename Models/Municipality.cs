namespace Covid19Data.Models
{
  public class Municipality
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pupulation { get; set; }

    public Municipality()
    {

    }

    public Municipality(int id, string name, int population)
    {
      this.Id = id;
      this.Name = name;
      this.Pupulation = population;
    }
  }
}