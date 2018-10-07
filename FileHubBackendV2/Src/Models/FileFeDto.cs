using System;

namespace FileHubBackendV2.Src.Models
{
    // Dto: prefix for data transfer object, have no business logic
    // Bo : prefix for business object needs to have business logic, eg., required fields
    // Fe : prefix means this is object used for EF migrations
    // 
    // referenced used: https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp
    public class FileFeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string tags { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public DateTime DeletedUtc { get; set; }
    }

}
