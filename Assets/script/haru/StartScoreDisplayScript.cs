using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScoreDisplayScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighscoreText;
    [SerializeField] TextMeshProUGUI EndscoreText;
    [SerializeField] TextMeshProUGUI enTimeText;
    [SerializeField] TextMeshProUGUI bestTimeText;
    float highScoreDisplay;
    float endScoreDisplay;
    float entimeScoreDisplay;
    float besttimeScoreDisplay;

    void Start()
    {
        highScoreDisplay = PlayerPrefs.GetFloat("HighScore", 0);
        endScoreDisplay = PlayerPrefs.GetFloat("EndScore", 0);
        entimeScoreDisplay = PlayerPrefs.GetFloat("nowTimeScore", 0);
        besttimeScoreDisplay = PlayerPrefs.GetFloat("bestTimeScore", 0);

        //�O��̌���
        float senTime = entimeScoreDisplay % 60;
        float menTime = Mathf.FloorToInt(entimeScoreDisplay / 60);

        var stime = senTime.ToString("00.00");
        var mtime = menTime.ToString("00");

        //�x�X�g�X�R�A
        float sbestTime = besttimeScoreDisplay % 60;
        float mbestTime= Mathf.FloorToInt(besttimeScoreDisplay / 60);

        var stimebest = sbestTime.ToString("00.00");
        var mtimebest = mbestTime.ToString("00");

        //�\��
        HighscoreText.text = highScoreDisplay + "m";
        EndscoreText.text = endScoreDisplay + "m";
        enTimeText.text = mtime + ":" + stime + "s";
        bestTimeText.text= mtimebest + ":" + stimebest + "s";
    }
}