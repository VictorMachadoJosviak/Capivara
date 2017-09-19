using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.Service
{
    public interface ICapivaraService
    {
        string context { get; }
      Task< string> SendTextToService(string text);


    }
}
