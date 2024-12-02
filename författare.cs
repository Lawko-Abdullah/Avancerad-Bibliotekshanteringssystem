public class Författare
{
    public int Id { get; set; }
    public string Namn { get; set; }
    public string Land { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Namn: {Namn}, Land: {Land}";
    }
}
