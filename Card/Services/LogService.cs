using Cards.Data;
using Cards.Enums;
using Cards.Interfaces;
using Cards.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Services
{
    public class LogService : ILogService
    {
        public int AddLog(DataContext context,string request, string response, int operationTypeId)
        {

            Logs log = new Logs();

            log.Request = request;
            log.FKOperationTypeId = operationTypeId;
            log.Response = response;
            log.CreateDate = DateTime.Now;

            context.Log.Add(log);
            context.SaveChanges();
            return 0;
        }
    }
}
