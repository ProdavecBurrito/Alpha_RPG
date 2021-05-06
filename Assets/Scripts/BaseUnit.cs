using System;

public abstract class BaseUnit : IUnit
{
    public event Action OnTurnEnd = delegate () { };

    public Health _health;

    private MovementPoints _movementPoints;

    public bool IsAlreadyActed { get; set; }
    public bool IsActing { get; set; }
    public int Initiative { get; set; }

    public BaseUnit(Health health)
    {
        _health = health;
    }

    public void GetTurn()
    {
        IsActing = true;
    }

    public void EndTurn()
    {
        OnTurnEnd?.Invoke();
    }
}
