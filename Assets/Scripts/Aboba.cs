using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Aboba : MonoBehaviour
{
    public Text ScoreText;
    public Text timerStart;
    public GameObject failed;
    public GameObject complete;
    public GameObject effect;
    public GameObject failedSound;
    public GameObject[] music;
    public GameObject pauseMenu;
    public GameObject confeti;
    public GameObject moneyEffect;
    public Image whiteScreen;
    public GameObject heart;
    public GameObject[] hearts;
    public GameObject manage;
    public Text moneyText;
    public ParticleSystem PlayerEffect;
    private void Start()
    {
        StartCoroutine(TransitionIn());
    }
    IEnumerator TransitionIn()
    {
        var col = whiteScreen.color;
        while (col.a > 0)
        {
            col.a -= 0.02f;
            whiteScreen.color = col;
            yield return new WaitForSeconds(0.005f);
        }
        col.a -= 0.02f;
        whiteScreen.gameObject.SetActive(false);
    }
} 
