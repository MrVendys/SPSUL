using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekken
{
    interface IMinigame
    {
        event Action<int> GameEnded;
        void StartGame();

        
    }
}
