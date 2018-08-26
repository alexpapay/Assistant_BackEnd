using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssistantWebMySql.Models.DbSets
{
    public class RegisteredUser
    {
        [Key]
        [DisplayName("№ пп")]
        public int Id { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [DisplayName("Компания")]
        public string Company { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }

        [DisplayName("Ключ")]
        public string KeyHash { get; set; }

        [DisplayName("MAC-адрес")]
        public string MacAdress { get; set; }

        [DisplayName("Ip-регистр.")]
        public string RegistrationIp { get; set; }

        [DisplayName("Тип регистр.")]
        public string RegistrationType { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата регистр.")]
        public DateTime? RegistrationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ключ до")]
        public DateTime? LicenseFinishDate { get; set; }
    }
}