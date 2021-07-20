using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Interfaces
{
    public interface IFileService
    {
        List<string> FileValidation(IFormFile file);
    }
}
