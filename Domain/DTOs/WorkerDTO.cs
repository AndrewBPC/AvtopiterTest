using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class WorkerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WorkerDTO() { }
        public WorkerDTO(Worker worker)
        {
            Id = worker.Id;
            Name = worker.Name;
        }
    }
}
