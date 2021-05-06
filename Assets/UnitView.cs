using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView : MonoBehaviour
{
    private BaseUnit baseUnit;
    public Health GetHealth => baseUnit.health;

    private void Awake()
    {
        baseUnit = new BaseUnit();
    }
}
