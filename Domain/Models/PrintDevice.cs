using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PrintDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }
}
