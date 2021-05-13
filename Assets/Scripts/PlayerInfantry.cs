public class PlayerInfantry : BaseUnitController
{
    public PlayerInfantry() : base()
    {
        _unitModel = new PlayerInfantryModel(new Health(100));
        _unitView = ResourceLoader.LoadAndInstantiateObject<PlayerInfantryView>(_unitModel.LoadPath);
        _animationController.Init(_unitView.UnitAnimator);
        UpdateManager.SubscribeToUpdate(CheckSpeed);
    }
}