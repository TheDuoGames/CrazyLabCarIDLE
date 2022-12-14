
public class UpgradeSpeed : UpgradeBase
{
    public override void GetCurrentLevelAndCost()
    {
        currentLevel = UpgradeManager.Instance.SavedData.currentSpeedLevel;
        cost = GameEconomy.SpeedBonusIncreaseCost(currentLevel);
    }

    public override void UpgradeTargetData()
    {
        UpgradeManager.Instance.SavedData.currentSpeedLevel++;
    }
}
