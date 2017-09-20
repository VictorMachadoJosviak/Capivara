using Capibara.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.Service
{
    public interface ICapivaraService
    {
        Conversa Context { get; set; }
      Task< Conversa> SendTextToService(string pegunta);


    }
}
