public interface IUnit
{
    bool IsAlreadyActed { get; set; }
    bool IsActing { get; set; }

    int Initiative { get; set; }

    void GetTurn();
}