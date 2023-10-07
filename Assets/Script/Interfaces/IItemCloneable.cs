using Script.ItemSpace;

namespace Assets.Script.Interfaces
{
    public interface IItemCloneable
    { 
        BaseItem Clone<T>() where T : BaseItem;
    }
}
