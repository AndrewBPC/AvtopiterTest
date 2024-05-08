using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class BranchOfficeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BranchOfficeDTO() { }
        public BranchOfficeDTO(BranchOffice office)
        {
            Id = office.Id;
            Name = office.Name;
        }
    }
}
