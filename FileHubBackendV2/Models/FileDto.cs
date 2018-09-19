using System;
using System.Collections.Generic;

namespace FileHubBackendV2.Models
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public ICollection<string> tags { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public DateTime DeletedUtc { get; set; }
    }

}
