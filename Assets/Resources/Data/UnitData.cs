using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "UnitData")]
public class UnitData : ScriptableObject
{
    public int Initiative;
    public int StartActionPoints;
    public int MovementPointsValue;
    public int AttackPointsValue;
    public float MovementSpeed;
}
