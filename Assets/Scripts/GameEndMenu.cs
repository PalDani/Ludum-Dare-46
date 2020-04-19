using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndMenu : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text deadText;

    // Start is called before the first frame update
    void Start()
    {
        var dataHolder = GameObject.Find("[PlayerData]").GetComponent<PlayerDataHolder>();
        scoreText.text = dataHolder.Score + "";
        deadText.text = dataHolder.Dead + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        SceneChanger.Instance.ChangeScene(0);
        //Application.Quit();
    }

    public void RestartGame()
    {
        SceneChanger.Instance.ChangeScene(1);
    }
}
