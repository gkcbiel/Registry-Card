using Cards.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cards.Services
{
    public class FileService : IFileService
    {    
        public List<string> FileValidation(IFormFile file)
        {
            List<string> errorList = new List<string>();

            if (file == null)
            {
                errorList.Add("Nenhum arquivo encontrado");
            }
            else if (!file.FileName.Split(".").Last().Equals("txt"))
            {
                errorList.Add("Arquivo não suportado");
            }

            return errorList;
        }
    }
}
