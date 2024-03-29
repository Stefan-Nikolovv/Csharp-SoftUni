﻿using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Models;
using HouseRentingSystem.Web.ViewModels.Agent;
using HouseRentingSystems.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystems.Services.Data
{
    public class AgentService : IAgentService
    {

        private readonly HouseRentingDbContext dbContext;

        public AgentService(HouseRentingDbContext dbContext)
        {
                this.dbContext = dbContext;
        }
        public async Task<bool> AgentExistsByUserId(string userId)
        {
            bool result = await this.dbContext
                 .Agents
                 .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
                                 
        }

        public async Task<bool> AgentExistsPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                    .Agents
                    .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task Create(string userId, BecomeAgentFromModel model)
        {
            Agent agent = new Agent()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };
           await this.dbContext.Agents.AddAsync(agent);
            await this.dbContext.SaveChangesAsync();    
        }

        public async Task<string?> GetAgentIdByUserIdAsync(string userId)
        {
           Agent? agentId = await this.dbContext.Agents.FirstOrDefaultAsync(a => a.UserId.ToString() == userId);
            if(agentId == null)
            {
                return null;
            }
            return agentId.Id.ToString();
        }

        public async Task<bool> HasHouseWithIdAsync(string? userId, string houseId)
        {
           Agent? agent = await this.dbContext.Agents
                .Include(a => a.ManagedHouses).FirstOrDefaultAsync(a => a.UserId.ToString() == userId);
            if(agent == null)
            {
                return false;
            }
            houseId = houseId.ToLower();
          return  agent.ManagedHouses.Any(h => h.Id.ToString() == houseId);
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            User? result = await this.dbContext
                  .Users
                    .FirstOrDefaultAsync(a => a.Id.ToString() == userId);

            if(result == null)
            {
                return false;
            }

            return result.RentedHouses.Any();
        }
    }
}
