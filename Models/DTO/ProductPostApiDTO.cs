/*
    {
  "id": 0,
  "name": "string",
  "price": 0,
  "description": "string",
  "shortDescription": "string",
  "quantity": 0,
  "imgLink": "string"
}
*/

using System.ComponentModel.DataAnnotations;

public class ProductPostApiDTO
{
    
    public int Id { get; set; }
    // [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public double Quantity { get; set; }
    public string ImgLink { get; set; }
    
    
}