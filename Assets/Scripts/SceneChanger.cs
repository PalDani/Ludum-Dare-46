using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Image fadeScreen;
    Animator animator;

    public static SceneChanger Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else Debug.LogError("Other SceneChanger instance already created!", Instance);

        DontDestroyOnLoad(gameObject);
        animator = fadeScreen.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Fading(int index)
    {
        Debug.Log("Loading scene " + index);
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeScreen.color.a == 1);
        SceneManager.LoadScene(index);
        animator.SetBool("Fade", false);
        //yield return new WaitUntil(() => fadeScreen.color.a == 0);
        Debug.Log("Loaded scene " + index);
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(Fading(index));
    }
}
