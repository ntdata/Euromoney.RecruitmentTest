using Ninject.Modules;
using Ninject;
using ContentConsole.Data;

namespace ContentConsole
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IWordsDataStore>().To<NegativeWordsDataStore>();
        }
    }
}
