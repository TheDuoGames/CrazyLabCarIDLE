using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatMenu : MonoBehaviour
{
    public void ManipulateTimeScale(int amount)
    {
        Time.timeScale = amount;
        SoundManager.Instance.Play("buttonClick");
    }
    public void AddMoney(int amount)
    {
        Economy.Instance.Add(amount);
        SoundManager.Instance.Play("buttonClick");
    }

    public void RestartGame()
    {
        UpgradeManager.Instance.Clear();
        PlayerPrefs.DeleteAll();
        Economy.Instance.Clear();
        GC.Collect();
        SceneManager.LoadScene(0);
        SoundManager.Instance.Play("buttonClick");
    }
}
