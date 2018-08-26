using System.ComponentModel.DataAnnotations;

namespace AssistantWebMySql.Models.DbSets
{
    public class UserRequest
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public string Adress { get; set; }

        public string MacAdress { get; set; }
    }
}