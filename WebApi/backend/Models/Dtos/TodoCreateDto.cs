using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models.Dtos
{
    public class TodoCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Value { get; set; }
    }
}
