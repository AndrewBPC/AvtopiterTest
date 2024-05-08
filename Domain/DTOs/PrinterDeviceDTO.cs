using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PrinterDeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public PrinterDeviceDTO() { }
        public PrinterDeviceDTO(PrintDevice device)
        {
            Id = device.Id;
            Name = device.Name;
            ConnectionType = device.ConnectionType;
        }
    }
}
