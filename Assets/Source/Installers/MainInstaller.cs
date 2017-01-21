using SeaSideScroll.Input;
using UnityEngine;
using Zenject;

namespace SeaSideScroll.Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField]
        private InputInstaller _inputInstaller;

        public override void InstallBindings()
        {
            _inputInstaller.Install(Container);
        }
    }
}
