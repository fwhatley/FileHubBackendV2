using ServiceStack.DataAnnotations;
using System;

namespace FileHubBackendV2.Src.Models
{
    // Dto: prefix for data transfer object, have no business logic
    // Bo : prefix for business object needs to have business logic, eg., required fields
    // none : no prefix means that that POCO is used only for db table generation. 
    //  - Each prop should math a column
    //  - don't add a property if it doesn't exist in the table
    // referenced used: https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp
    public class FileRecord
    {
        [AutoId] // autogenerate guid by postgres
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public DateTime DeletedUtc { get; set; }
    }

}
