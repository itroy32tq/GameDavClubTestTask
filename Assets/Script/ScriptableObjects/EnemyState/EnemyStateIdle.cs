using PoketZone;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStateIdle", menuName = "Configurations/EnemyStateIdle")]
public class EnemyStateIdle : EnemyState
{
    public override void Update()
    {
        if (IsTargetExist())
        {
            NeedTransition = true;
            TargetState = AvailableTransitions[0];
        } 
    }

    private bool IsTargetExist()
    {
        return AvailableTransitions[0] != null && Enemy.Target != null;
    }
}
