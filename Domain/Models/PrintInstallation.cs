using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PrintInstallation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrintDeviceId { get; set; }
        public PrintDevice PrintDevice { get; set; }

        public int BranchOfficeId { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public bool IsDefault { get; set; } = false;
        public string? MacAddress { get; set; } = null;
        
    }
}
