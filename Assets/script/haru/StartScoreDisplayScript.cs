using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScoreDisplayScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighscoreText;
    [SerializeField] TextMeshProUGUI EndscoreText;
    float highScoreDisplay;
    float endScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplay = PlayerPrefs.GetFloat("HighScore", 0);
        endScoreDisplay = PlayerPrefs.GetFloat("EndScore", 0);
        HighscoreText.text = highScoreDisplay + "m";
        EndscoreText.text = endScoreDisplay + "m";

    }
}