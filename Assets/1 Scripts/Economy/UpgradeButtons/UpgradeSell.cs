using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSell : UpgradeBase
{
    public override void GetCurrentLevelAndCost()
    {
        currentLevel = UpgradeManager.Instance.SavedData.currentSellLevel;
        cost = GameEconomy.SellBonusIncreaseCost(currentLevel);
    }

    public override void UpgradeTargetData()
    {
        UpgradeManager.Instance.SavedData.currentSellLevel++;
    }
}
