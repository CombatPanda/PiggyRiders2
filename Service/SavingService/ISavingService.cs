using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.SavingService
{
    public interface ISavingService
    {
        Task<ServiceResponse<List<SavingsManagerInformation>>> GetAllSavings();
        Task<ServiceResponse<SavingsManagerInformation>> GetSavingsById(int id);
        Task<ServiceResponse<List<SavingsManagerInformation>>> AddSaving(SavingsManagerInformation newSaving);
        Task<ServiceResponse<SavingsManagerInformation>> UpdateSaving(SavingsManagerInformation updatedSaving);
        Task<ServiceResponse<List<SavingsManagerInformation>>> DeleteSaving(int id);


    }
}
