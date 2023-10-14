using Script.ItemSpace;

namespace Assets.Script.Interfaces
{
    public interface ICloneable<in T>
    {
        Tclone Clone<Tclone>() where Tclone : T;
    }
}
