using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{
    public static int SellBonusIncreaseCost(int currentLevel) => ((currentLevel - 1) * 35) + 50;
    public static int EarningBonusIncreaseCost(int currentLevel) => (4 * (currentLevel - 1) * 75) + 50;
    public static int SpeedBonusIncreaseCost(int currentLevel) => ((currentLevel - 1) * 50) + 50;
}
