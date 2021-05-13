public interface IUnitModel
{
    bool IsAlreadyActed { get; set; }
    bool IsActing { get; set; }
    int Initiative { get; set; }
}