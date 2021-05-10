using UnityEngine;

public class PlayerInfantry : BaseUnitController
{
    public PlayerInfantry()
    {
        _unitModel = new PlayerInfantryModel(new Health(100));
        _unitView = ResourceLoader.LoadAndInstantiateObject<PlayerInfantryView>(_unitModel.LoadPath);
    }
}