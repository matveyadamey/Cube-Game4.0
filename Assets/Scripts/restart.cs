using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject SetVolume;
    public Image whiteScreen;
    Color col;
    private void Start()
    {
        try
        {
            col = whiteScreen.color;
            WhiteScreenManager(false, 1);
        }
        catch
        { }
    }
    public void StartLevel1()
    {
        StartCoroutine(TransitionTo());
    }

    IEnumerator TransitionTo()
    {
        WhiteScreenManager(true, 0);
        
        while (col.a <1)
        {
            col.a += 0.01f;
            whiteScreen.color = col;
            yield return new WaitForSeconds(0.005f);
        }
        col.a += 0.01f;
        SceneManager.LoadScene("level 1");
    }
    void WhiteScreenManager(bool s,int i)
    {
        whiteScreen.gameObject.SetActive(s);
        col.a = i;
        whiteScreen.color = col;

    }
    public void RunScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Volume(bool s)
    {
        SetVolume.SetActive(s);
    }
}