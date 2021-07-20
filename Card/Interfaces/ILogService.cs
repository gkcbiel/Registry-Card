using Cards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Interfaces
{
    public interface ILogService
    {
        int AddLog(DataContext context,string request, string response, int operationTypeId);
    }
}
