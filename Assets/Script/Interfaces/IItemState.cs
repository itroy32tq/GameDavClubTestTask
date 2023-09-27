
namespace Script.Interfaces
{
    public interface IItemState
    {
        bool IsEquipped { get; set; }
        bool IsOnMap { get; set; }
        int Amount { get; set; }
    }
}

