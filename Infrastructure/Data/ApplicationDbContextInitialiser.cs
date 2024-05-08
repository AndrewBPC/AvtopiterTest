using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }

    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            List<PrintDevice> devices = new();
            if (!await _context.PrintDevices.AnyAsync())
            {
                devices = new List<PrintDevice>() {
                    new()
                    {
                        Name = "Папирус",
                        ConnectionType = Domain.Enums.ConnectionType.Local
                    },
                    new()
                    {
                        Name = "Бумага",
                        ConnectionType = Domain.Enums.ConnectionType.Local
                    },
                    new(){
                        Name = "Камень",
                        ConnectionType = Domain.Enums.ConnectionType.Network
                    }
                };
                _context.PrintDevices.AddRange(devices);
                await _context.SaveChangesAsync();
            }

            

            if (! await _context.BranchOffices.AnyAsync() && devices.Count > 0)
            {
                var offices = new List<BranchOffice>() {
                    new BranchOffice(){ 
                        Name = "Тридевятое царство",
                        Workers = new List<Worker>() {
                            new()
                            {
                                Name = "Царь"
                            },
                            new()
                            {
                                Name = "Добрыня"
                            }
                        },
                        Address = "Царство",
                        PrintInstallations = new List<PrintInstallation>()
                        {
                            new()
                            {
                                Name = "Дворец",
                                // Допустимо !
                                PrintDeviceId = devices.FirstOrDefault(x => x.Name == "Папирус")!.Id,
                                IsDefault = true
                            },
                            new()
                            {
                                Name = "Конюшни",
                                // Допустимо !
                                PrintDeviceId = devices.FirstOrDefault(x => x.Name == "Бумага")!.Id,
                                IsDefault = true
                            },
                            new()
                            {
                                Name = "Оружейная",
                                // Допустимо !
                                PrintDeviceId = devices.FirstOrDefault(x => x.Name == "Бумага")!.Id,
                                IsDefault = true,
                                
                            }
                        }
                    },
                    new BranchOffice(){
                        Name = "Дремучий Лес",
                        Workers = new List<Worker>() {
                            new()
                            {
                                Name = "Яга"
                            }
                        },
                        Address = "Tayga",
                        PrintInstallations = new List<PrintInstallation>()
                        {
                            new()
                            {
                                Name = "Избушка",
                                // Допустимо !
                                PrintDeviceId = devices.FirstOrDefault(x => x.Name == "Бумага")!.Id,
                                IsDefault = true
                            },
                            new()
                            {
                                Name = "Топи",
                                // Допустимо !
                                PrintDeviceId = devices.FirstOrDefault(x => x.Name == "Папирус")!.Id,
                                IsDefault = true
                            }
                        }
                    },
                    new BranchOffice(){
                        Name = "Луна",
                        Workers = new List<Worker>() {
                            new()
                            {
                                Name = "Копатыч"
                            },
                            new()
                            {
                                Name = "Кощей"
                            },
                            new()
                            {
                                Name = "Лосяш"
                            }
                        },
                        Address = "Moon",
                        PrintInstallations = new List<PrintInstallation>()
                        {
                            new()
                            {
                                Name = "Кратер",
                                // Допустимо !
                                PrintDeviceId = devices.FirstOrDefault(x => x.Name == "Камень")!.Id,
                                IsDefault = true,
                                MacAddress = "29:83:40:bb:8c:64"
                            }
                        }
                    },

                };
                _context.BranchOffices.AddRange(offices);
                await _context.SaveChangesAsync();
            }
            
           


            
        }
    }
}
