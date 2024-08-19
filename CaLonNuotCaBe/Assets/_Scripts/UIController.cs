using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI UIScore;
    [SerializeField] TextMeshProUGUI UIhp;
    [SerializeField] TextMeshProUGUI UIClock;
    [SerializeField] GameObject labelLoss;
    public static UIController Instance;
    float countClock = 0;
    public float CountClock { get { return countClock; } }
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        countClock += Time.deltaTime;
        UpdateClockUI();
    }
    public void UpdateScoreUI(int scoreNow)
    {
        UIScore.text = "Score: " + scoreNow;
    }
    public void UpdateHPUI(float hpNow)
    {
        UIhp.text = "HP: " + hpNow;
    }
    public void GameOver()
    {
        labelLoss.gameObject.SetActive(true);
    }
    public void UpdateClockUI()
    {
        int countSecond = (int)countClock;
        int minute = 0;
        int second = 0;
        minute = (int)(countSecond / 60);
        second = countSecond % 60;

        string minuteTxt = "";
        if (minute < 10) minuteTxt = "0" + minute;
        else minuteTxt = "" + minute;

        string secondTxt = "";
        if (second < 10) secondTxt = "0" + second;
        else secondTxt = "" + second;

        UIClock.text = minuteTxt + ":" + secondTxt;
    }
}
