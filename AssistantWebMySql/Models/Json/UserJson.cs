using System;

namespace AssistantWebMySql.Models.Json
{
    public class UserJson
    {
        public string Name { get; set; }

        public string MacAdress { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? LicenseFinishDate { get; set; }
    }
}