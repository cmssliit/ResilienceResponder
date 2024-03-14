using CrisisManagementSystem.API.Application.DTOs.Location;
using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.Location
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateLocationDto : BaseLocationDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateLocationDto : BaseLocationDto
    {
        public int Id { get; set; }
    }
}