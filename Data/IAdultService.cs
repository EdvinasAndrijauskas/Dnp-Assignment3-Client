﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Managing_Adults.Data.Impl;
using Models;

namespace Managing_Adults.Data
{
    public interface IAdultService
    {
        Task<IList<Adult>> GetAdultAsync();
        Task<HttpStatusCode> AddAdult(Adult adult);
        Task RemoveAdultAsync(int adultId);
  

    }
}