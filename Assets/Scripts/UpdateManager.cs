using System.Collections.Generic;

public static class UpdateManager
{
    private static List<IUpdate> _updates;
    public static List<IUpdate> Updates => _updates;

    public static void AddToUpdate(IUpdate update)
    {
        _updates.Add(update);
    }

    public static void RemoveFromUpdate(IUpdate update)
    {
        if (_updates.Contains(update))
        {
            _updates.Remove(update);
        }
    }

    public static void UpdateAll()
    {
        for (int i = 0; i < _updates.Count; i++)
        {
            _updates[i].UpdateTick();
        }
    }
}
