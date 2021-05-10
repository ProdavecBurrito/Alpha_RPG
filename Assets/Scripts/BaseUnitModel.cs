using System;

public abstract class BaseUnitModel : IUnitModel
{
    public string LoadPath { get; set; }
    public bool IsAlreadyActed { get; set; }
    public bool IsActing { get; set; }
    public int Initiative { get; set; }
    public int MovementPoints { get; set; }
    public Health Health { get; set; }

    public BaseUnitModel(Health health)
    {
        Health = health;
    }
}
