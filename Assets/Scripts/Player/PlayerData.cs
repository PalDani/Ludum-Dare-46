using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [Header("Game settings")]
    public int maxDead = 3;

    private int score = 0;
    public int Score {
        get { return score; }
        set {
            score = value;
            GetComponent<PlayerGUI>().UpdateScoreBoard(score, dead);
        }
    }

    private int dead = 0;
    public int Dead {
        get { return dead; }
        set {
            dead = value;
            GetComponent<PlayerGUI>().UpdateScoreBoard(score, value);
            CheckIfLost();
        }
    }

    public static PlayerData Instance;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else Debug.LogWarning("Other Instance already running!", Instance);

        Score = 0;
        Dead = 0;
    }

    
    void CheckIfLost()
    {
        if (Dead >= maxDead)
        {
            GameObject dataHolder = new GameObject("[PlayerData]");
            DontDestroyOnLoad(dataHolder);
            dataHolder.AddComponent(typeof(PlayerDataHolder));
            var dh = dataHolder.GetComponent<PlayerDataHolder>();
            dh.Score = Score;
            dh.Dead = Dead;
            SceneChanger.Instance.ChangeScene(2);
        }
    }
}
