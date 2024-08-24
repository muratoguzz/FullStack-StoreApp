namespace Store.Entities.Models
{
    public class Category
    {
        public int CategoryId{get; set;}
        public String? CategoryName { get; set; } = String.Empty;
        
        //Collection navigation prop-nesneler arasýnda geçiþ yapmamýza yarayan prop
        public ICollection<Product>? Products { get; set; } 
    }
}