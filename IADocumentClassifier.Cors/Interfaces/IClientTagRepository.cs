﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IADocumentClassifier.Cors.Interfaces
{
    using IADocumentClassifier.Cors.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IClientTagRepository
    {
        Task<IEnumerable<ClientTag>> GetAll();
        Task<ClientTag> GetById(int id);
        Task Add(ClientTag clienTag);
        Task<bool> Update(ClientTag clienTag);
        Task<bool> Delete(int id);
    }
}
