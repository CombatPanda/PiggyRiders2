﻿using Microsoft.EntityFrameworkCore;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSaver.Service.SavingService
{
    public class SavingService : ISavingService
    {
        private readonly UserContext _context;

        public SavingService(UserContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<SavingsManagerInformation>>> AddSaving(SavingsManagerInformation newSaving)
        {
            ServiceResponse<List<SavingsManagerInformation>> serviceResponse = new ServiceResponse<List<SavingsManagerInformation>>();
            _context.SMInfo.Add(newSaving);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.SMInfo.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SavingsManagerInformation>>> DeleteSaving(int id)
        {
            ServiceResponse<List<SavingsManagerInformation>> serviceResponse = new ServiceResponse<List<SavingsManagerInformation>>();
            try
            {

                SavingsManagerInformation savingsManagerInformation = await _context.SMInfo.FindAsync(id);
                _context.SMInfo.Remove(savingsManagerInformation);


                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.SMInfo.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SavingsManagerInformation>>> GetAllSavings()
        {
            ServiceResponse<List<SavingsManagerInformation>> serviceResponse = new ServiceResponse<List<SavingsManagerInformation>>();
            serviceResponse.Data = await _context.SMInfo.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<SavingsManagerInformation>> GetSavingsById(int id)
        {
            ServiceResponse<SavingsManagerInformation> serviceResponse = new ServiceResponse<SavingsManagerInformation>();
            serviceResponse.Data = await _context.SMInfo.FindAsync(id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<SavingsManagerInformation>> UpdateSaving(SavingsManagerInformation updatedSaving)
        {
            ServiceResponse<SavingsManagerInformation> serviceResponse = new ServiceResponse<SavingsManagerInformation>();
            try { 

            SavingsManagerInformation savingsManagerInformation = await _context.SMInfo.FindAsync(updatedSaving.ID);
            savingsManagerInformation.Purpose = updatedSaving.Purpose;
            savingsManagerInformation.Cost = updatedSaving.Cost;
            savingsManagerInformation.Date = updatedSaving.Date;
            savingsManagerInformation.SavedAmount += updatedSaving.lastAddition;
                if (savingsManagerInformation.SavedAmount > 0 && savingsManagerInformation.SavedAmount < savingsManagerInformation.Cost)
                {
                    savingsManagerInformation.Status = "In progress";
                }
                if (savingsManagerInformation.SavedAmount + updatedSaving.lastAddition >=savingsManagerInformation.Cost)
                {
                    savingsManagerInformation.Status = "Completed";
                }
            await _context.SaveChangesAsync();
            serviceResponse.Data = savingsManagerInformation;
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        private bool SavingsManagerInformationExists(int id)
        {
            return _context.SMInfo.Any(e => e.ID == id);
        }
    }
}
