using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text deadText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreBoard(int score, int dead)
    {
        scoreText.text = score + "";
        deadText.text = dead + "";
    }
}
