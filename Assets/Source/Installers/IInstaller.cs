using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;

namespace SeaSideScroll.Installers
{
    interface IInstaller
    {
        void Install(DiContainer container);
    }
}
