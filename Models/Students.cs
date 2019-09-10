using LiteDB;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Students   
    {
        [BsonId(true)]
        public int Id { get; set; }

        [BsonField("name")]  
        [Required()]
        public string Name { get; set; }

        [BsonField("active")]
        [Required()]
        public bool Active { get; set; }
    }
}
