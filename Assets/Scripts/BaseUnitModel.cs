using System;

public abstract class BaseUnitModel : IUnitModel
{
    public string LoadPath { get; set; }
    public bool IsAlreadyActed { get; set; }
    public bool IsActing { get; set; }
    public int Initiative { get; set; }
    public int CurrentActionPoints { get; set; }
    public int StartActionPoints { get; set; }
    public int MovementPointsValue { get; set; }
    public int AttackPointsValue { get; set; }
    public float MovementSpeed { get; set; }
    public Health Health { get; set; }
    public UnitData CurrentUnitData;

    public BaseUnitModel(Health health)
    {
        Health = health;
    }
}
