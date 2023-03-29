﻿using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Dto.Professor;

public class PostUpdateProfessorDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
    [Display(Name = "Name", Prompt = "Enter the name")]
    public string Name { get; set; }

    public bool Active { get; set; }
}
