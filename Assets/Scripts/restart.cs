using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject SetVolume;
    public Image whiteScreen;
    Color col;
    public Animator trans;
    [SerializeField] private GameObject SetPlat;
    [SerializeField] private GameObject volume;
    private void Start()
    {
        try {
            whiteScreen.gameObject.SetActive(false);
        }
        catch { }

        if (!PlayerPrefs.HasKey("platformNum"))
        {
            Off(true);
        }
    }

    public void transition()
    {
        
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
          SceneManager.LoadScene("level 1");
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
    public void Off(bool s)
    {
        gameObject.transform.parent.gameObject.SetActive(s);
    }
    public void Volume()
    {
        volume.SetActive(true);
    }

}