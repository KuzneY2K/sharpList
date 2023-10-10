

namespace server.Models;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }  
    public string Model { get; set; }
    public int Year { get; set; }
    public int? Price { get; set; }
    public bool IsNew { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    // NOTE once we have our DB created we wont use constructors.
}
