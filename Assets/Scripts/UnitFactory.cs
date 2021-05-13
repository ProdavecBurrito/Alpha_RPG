public static class UnitFactory
{
    public static BaseUnitController CreateUnit(PlayerUnitType unitType)
    {
        switch (unitType)
        {
            case PlayerUnitType.Infantry:
                return new PlayerInfantry();
            case PlayerUnitType.Sniper:
                return new PlayerSniper();
            default:
                return new NullUnit();
        }
    }

    public static BaseUnitController CreateUnit(EnemyUnitType unitType)
    {
        switch (unitType)
        {
            case EnemyUnitType.Infantry:
                return new EnemyInfantry();
            default:
                return new NullUnit();
        }
    }
}
