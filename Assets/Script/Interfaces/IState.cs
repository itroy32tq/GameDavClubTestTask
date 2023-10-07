using System.Linq;
using System.Text;

namespace Assets.Script.Interfaces
{
    public interface IState<out TInitializer>
    {
        public TInitializer Initializer { get; }
    }
}
