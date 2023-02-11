﻿using Core.Models;

namespace Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> Create(Security usersSecuredData);
        Task<Security> GetByUserEmail(string email);
        Task<Security> GetByUserId(int id);
        Task<bool> Update(Security usersSecuredData);
        Task<bool> DeleteByUserId(int id);
    }
}