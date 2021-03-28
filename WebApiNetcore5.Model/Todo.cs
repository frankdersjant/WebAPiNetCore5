using System.ComponentModel.DataAnnotations;

namespace WebApiNetcore5.Model
{
    public class Todo
    {
        [Key]
        public int TodoId { get; set; }
    }
}
