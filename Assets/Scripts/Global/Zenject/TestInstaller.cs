using Character.CharacterControllers;
using Character.CharacterControllers.Inputs;
using Zenject;

namespace Global.Zenject
{
    public class TestInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITest>().To<PrintTestNew>().FromNew().AsSingle();
        }
    }
}