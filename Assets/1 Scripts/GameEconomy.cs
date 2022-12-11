using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{
    public static int DropAmountCost(int currentLevel) => currentLevel + 150;
    public static int EarningsCost(int currentLevel) => currentLevel + 150;
    public static int SpeedCost(int currentLevel) => currentLevel + 150;
}
