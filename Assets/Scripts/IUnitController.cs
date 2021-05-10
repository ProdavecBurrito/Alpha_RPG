using UnityEngine;

public interface IUnitController
{
    void GetTurn();
    void EndTurn();
    void Move(Vector3 direction);
    void Attack();
}