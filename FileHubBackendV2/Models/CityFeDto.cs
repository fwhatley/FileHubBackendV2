namespace FileHubBackendV2.Models
{
    // Dto: prefix for data transfer object, have no business logic
    // Bo : prefix for business object needs to have business logic, eg., required fields
    // Fe : prefix means this is object used for EF migrations
    // 
    // referenced used: https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp
    public class CityFeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
