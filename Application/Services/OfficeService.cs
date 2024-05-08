using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly ApplicationDbContext _context;
        public OfficeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<BranchOfficeDTO>> GetOffices()
        {
            return await _context.BranchOffices.Select(x => new BranchOfficeDTO(x)).ToListAsync();
        }

        public async Task<ICollection<PrinterDeviceDTO>> GetPrinters(ConnectionType? connectionType)
        {
            return await _context.PrintDevices.Where(x => connectionType == null || x.ConnectionType == connectionType).Select(x => new PrinterDeviceDTO(x)).ToListAsync();
            
        }

        public async Task<ICollection<WorkerDTO>> GetWorkers()
        {
            return await _context.Workers.Select(x => new WorkerDTO(x)).ToListAsync();
        }
    }
}
