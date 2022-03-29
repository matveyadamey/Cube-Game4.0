using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject SetVolume;
    public Image whiteScreen;
    Color col;
    public Animator trans;
    private void Start()
    {
        try {
            whiteScreen.gameObject.SetActive(false);
        }
        catch { }
    }

    public void transition()
    {
        try { 
            whiteScreen.gameObject.SetActive(true);
            //trans = GameObject.Find("Image").GetComponent<Animator>();
        }
        catch { }
        trans.SetTrigger("trans");
        
        /*
        while (col.a <1)
        {
            print("run");
            col.a += 0.01f;
            whiteScreen.color = col;
            print("vanyazadolbal2");
            yield return new WaitForSeconds(0.005f);
            print("vanyazadolbal3");
        }
        */
        UnityEngine.SceneManagement.SceneManager.LoadScene("level 1");
    }
    void WhiteScreenManager(bool s,int i)
    {
        print("siuuu");
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