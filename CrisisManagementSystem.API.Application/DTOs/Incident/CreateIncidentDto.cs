﻿using CrisisManagementSystem.API.Application.DTOs.Workflow;
using System.ComponentModel.DataAnnotations;

namespace CrisisManagementSystem.API.Application.DTOs.Incident
{
    //Introduce to add here Single Responsibilty priniciple.
    //Only to transfer data.Not to hold data from database
    public class CreateIncidentDto : BaseIncidentDto
    {
    }

    // This is feel repeating samething. but
    //it follows single responsibility prinicple
    // one clas for one purpose
    public class UpdateIncidentDto : BaseIncidentDto
    {
        public int Id { get; set; }
    }
}