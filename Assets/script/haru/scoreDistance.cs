using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDistance : MonoBehaviour
{
    public GameObject maruInput;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI HighscoreText;

    private float score=0;
    public int log;
    Vector2 startPosition;
    Vector2 nowPosition;

    void Start()
    {
        startPosition = new Vector2(maruInput.transform.position.x,maruInput.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        nowPosition = new Vector2(maruInput.transform.position.x, maruInput.transform.position.y);
        float scorenum = Mathf.Round((nowPosition.x - startPosition.x) * log);
        if (score < scorenum) score = scorenum;
        scoreText.text = "Score:" + scorenum.ToString() + "m";//‰æ–Ê‚É”½‰f
        HighscoreText.text = "Score:" + score.ToString() + "m";//‰æ–Ê‚É”½‰f
    }
}
