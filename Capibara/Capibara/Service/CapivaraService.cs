using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.Service
{
    public class CapivaraService : ICapivaraService
    {
        public string context => "";

        public async Task<string> SendTextToService(string text)
        {
            return text;
        }
    }
}
