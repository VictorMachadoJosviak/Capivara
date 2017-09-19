using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capibara.Helpers
{
    public interface ISpeechToTextHelper
    {
        Task<string> StartVoiceInput();
    }
}
