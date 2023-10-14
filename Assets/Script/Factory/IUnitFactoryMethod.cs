using PoketZone;

namespace Assets.Script.Factory
{
    public interface IUnitFactoryMethod<out Tunit> where Tunit : Unit
    {
        public Tunit CreateUnit();
    }
}
