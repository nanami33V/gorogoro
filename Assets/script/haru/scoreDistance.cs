using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreDistance : MonoBehaviour
{
    public GameObject maruInput;
    [SerializeField] TextMeshProUGUI scoreText;

    private int score;
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
        scoreText.text = "Score:"+scorenum.ToString()+"m";//‰æ–Ê‚É”½‰f
    }
}
