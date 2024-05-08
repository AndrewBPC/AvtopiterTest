using Domain.DTOs;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        public InfoController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        /// <summary>
        /// Получить список филиалов
        /// </summary>
        /// <returns>json list</returns>
        [HttpGet("Offices")]
        public async Task<ActionResult<ICollection<BranchOfficeDTO>>> GetOffices()
        {
            var offices = await _officeService.GetOffices();

            return Ok(offices);
        }
        /// <summary>
        /// Получить список работников
        /// </summary>
        /// <returns>json list</returns>
        [HttpGet("Workers")]
        public async Task<ActionResult<ICollection<WorkerDTO>>> GetWorkers()
        {
            var workers = await _officeService.GetWorkers();
            return Ok(workers);
        }


        /// <summary>
        /// Получить устройства из списка справочников
        /// </summary>
        /// <param name="type">Опционально</param>
        /// <returns>A list of worker DTOs representing the printers.</returns>
        
        [HttpGet("PrintDevices")]
        
        public async Task<ActionResult<List<PrinterDeviceDTO>>> GetPrintDevices([FromQuery] ConnectionType? type = null)
        {
            var workers = await _officeService.GetPrinters(type);
            return Ok(workers);
        }
    }
}
