using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEarning : UpgradeBase
{
    public override void GetCurrentLevelAndCost()
    {
        currentLevel = UpgradeManager.Instance.SavedData.currentEarningLevel;
        cost = GameEconomy.EarningBonusIncreaseCost(currentLevel);
    }

    public override void UpgradeTargetData()
    {
        UpgradeManager.Instance.SavedData.currentEarningLevel++;
    }
}
