using System;

namespace TodoApi.Models.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public bool Done { get; set; }

        public DateTime Created { get; set; }
    }
}
