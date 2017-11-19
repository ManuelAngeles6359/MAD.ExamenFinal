using Dapper.Contrib.Extensions;

namespace MAD.Chinook.Models
{
    public class MediaType
    {

        [Key]
        public int MediaTypeId { get; set; }
        public string Name { get; set; }

    }
}
