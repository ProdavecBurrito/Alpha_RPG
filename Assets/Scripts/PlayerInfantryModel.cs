public class PlayerInfantryModel : BaseUnitModel
{
    public PlayerInfantryModel(Health health) : base(health)
    {
        CurrentUnitData = ResourceLoader.LoadObject<UnitData>("Data/PlayerInfantry");
        LoadPath = "Prefabs/SoldierInfantry";
        Initiative = CurrentUnitData.Initiative;
        MovementSpeed = CurrentUnitData.MovementSpeed;
        MovementPointsValue = CurrentUnitData.MovementPointsValue;
        AttackPointsValue = CurrentUnitData.AttackPointsValue;
        StartActionPoints = CurrentUnitData.StartActionPoints;
        CurrentActionPoints = StartActionPoints;
        IsAlreadyActed = false;
        IsActing = false;
    }
}