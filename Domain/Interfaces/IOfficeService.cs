using Domain.DTOs;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IOfficeService
    {
        Task<ICollection<BranchOfficeDTO>> GetOffices();
        Task<ICollection<WorkerDTO>> GetWorkers();
        Task<ICollection<PrinterDeviceDTO>> GetPrinters(ConnectionType? connectionType);
    }
}
