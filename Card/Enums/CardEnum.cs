using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Enums
{
    public class CardEnum
    {
        public enum OperationType
        {
            Authenticate = 1,
            Get = 2,
            GetByCardNumber = 3,
            Post = 4,
            Upload = 5
        }
    }
}
