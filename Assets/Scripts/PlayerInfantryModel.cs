public class PlayerInfantryModel : BaseUnitModel
{
    public PlayerInfantryModel(Health health) : base(health)
    {
        LoadPath = "Prefabs/SoldierInfantry";
        Initiative = 1;
    }
}