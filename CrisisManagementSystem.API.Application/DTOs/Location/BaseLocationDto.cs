using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.Location
{
    //we use abstract class because, we cant instantiate
    //only used for inheritance purposes
    public abstract class BaseLocationDto
    {
        //since following properties are repeatin in all 
        //Dtos we can put it in base
        //we can add the required anotation.
        //it will only consider when adding new user
        [Required]
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public int PostalCode { get; set; }
    }
}