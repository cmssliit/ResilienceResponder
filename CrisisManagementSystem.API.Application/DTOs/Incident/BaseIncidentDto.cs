using CrisisManagementSystem.API.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrisisManagementSystem.API.Application.DTOs.Incident
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseIncidentDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public string Name { get; set; }
        public string Descripton { get; set; }
        public int IncidentDepartmentId { get; set; }
        public int IncidentTypeId { get; set; }
        public string ReporterId { get; set; }

        //public List<IncidentMedia> Media { get; set; } = new List<IncidentMedia>();
    }
}