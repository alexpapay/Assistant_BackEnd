using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistantWebMySql.Models.DbSets
{
    public class MonitoringValue
    {
        [Key]
        [DisplayName("№ пп")]
        public int Id { get; set; }

        [DisplayName("Ip-адрес")]
        public string Ip { get; set; }
        
        public string Type { get; set; }

        public string ContinentCode { get; set; }

        public string ContinentName { get; set; }

        public string CountryCode { get; set; }

        [DisplayName("Страна")]
        public string CountryName { get; set; }

        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        [DisplayName("Город")]
        public string City { get; set; }

        public string Zip { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [NotMapped]
        public Location Location { get; set; }

        [DisplayName("MAC-адрес")]
        public string MacAddress { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Дата/Время")]
        public DateTime EventDateTime { get; set; }
    }

    public class Location
    {
        public int GeonameId { get; set; }

        public string Capital { get; set; }

        public List<Language> Languages { get; set; }

        public string CountryFlag { get; set; }

        public string CountryFlagEmoji { get; set; }

        public string CountryFlagEmojiUnicode { get; set; }

        public string CallingCode { get; set; }

        public bool IsEu { get; set; }
    }

    public class Language
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Native { get; set; }
    }
}