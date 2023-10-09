using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Core
{
    public class ProgramDetailsCore
    {
        public ProgramDetailsCore() 
        {
            
        }
        async public Task<dynamic> GetProgramDetailsAsync(int? programId = null)
        {
            if(programId == null) 
            {
                return new ProgramDetailsDto();
            }
            return new ProgramDetailsDto();
        }
        async public Task<dynamic> InsertProgramDetailsAsync(ProgramDetailsDto programDetails)
        {
            return true;
        }
    }
}
