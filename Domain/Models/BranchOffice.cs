using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BranchOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // В данном случае не вижу делать отдельную таблицу с локациями т.к. они и так уникальны
        public string Address { get; set; }
        public List<Worker> Workers { get; set; }
        public List<PrintInstallation> PrintInstallations { get; set; }
    }
}
