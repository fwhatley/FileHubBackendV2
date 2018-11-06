﻿using ServiceStack.DataAnnotations;
using System;

namespace FileHubBackendV2.Src.Models
{
    // Dto: prefix for data transfer object, have no business logic
    // Bo : prefix for business object needs to have business logic, eg., required fields
    // none : no prefix means that that POCO is used only for db table generation. 
    //  - Each prop should math a column
    //  - don't add a property if it doesn't exist in the table
    // referenced used: https://www.codeproject.com/Articles/1050468/Data-Transfer-Object-Design-Pattern-in-Csharp
    // prefixing with Fh becaue of class clashes with File.io
    public class FhFile
    {
        [AutoId] // autogenerate guid by postgres
        public Guid Id { get; set; }
        [Required]
        public Guid FileRecordId { get; set; }
        [Required]
        public string FileName { get; set; }
    }

}
