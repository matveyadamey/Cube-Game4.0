using UnityEngine;
using UnityEngine.UI;
using System;

public class collision : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject effectDeath;
    [SerializeField] Aboba aboba;
    [SerializeField] private GameObject heart;
    private GameObject failed;
    private GameObject[] music;
    private int rand;
    private GameObject failedSound;
    private int money;
    private float score;
    private Text ScoreText;
    private GameObject pauseMenu;
    public int LifeCount=3;
    public GameObject[] hearts;
    int i = 0;
    public GameObject player;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        money=PlayerPrefs.GetInt("money");
        aboba = GameObject.Find("aboba").GetComponent<Aboba>();
        hearts = aboba.hearts;
        heart = aboba.heart;
        ScoreText = aboba.ScoreText;
        failed = aboba.failed;
        failedSound = aboba.failedSound;
        music = aboba.music;
        rand = UnityEngine.Random.Range(0, music.Length);
        pauseMenu = aboba.pauseMenu;
    }
    void Update()
    {
        if (timer.NotPause)
        {
            score = (float)Math.Round(Time.timeSinceLevelLoad) - 3;
            ScoreText.text = "¬аш счет: " + score.ToString();
        }
    }

    void TryDestroyHeart()
    {
        try
        {
            LifeCount -= 1;
            hearts[i].SetActive(false);
            i++;
        }
        catch
        { }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            TryDestroyHeart();
            if (LifeCount > 0)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "lat") 
        {
            var front = other.gameObject.transform.position.z-3.5;
            if (transform.position.z < front)
            {
                TryDestroyHeart();
                if (LifeCount > 0)
                {
                    Instantiate(effect, transform.position, Quaternion.identity);
                    player.transform.position = other.transform.position + new Vector3(0, 5, -6);
                }
            }
        }
        if (other.gameObject.tag == "floor")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            heart.SetActive(false);
            Death();
        }
        if (LifeCount == 0)
        {
            Death();
        }

    }
    private void Death()
    {
        timer.NotPause = false;
        Instantiate(effectDeath, transform.position, Quaternion.identity);
        player.SetActive(false);
        music[rand].SetActive(false);
        failedSound.SetActive(true);
        money += manager.moneyInGame;
        PlayerPrefs.SetInt("money",money);
        manager.moneyInGame = 0;
        Invoke("StopAll", 0.7f);
    }
    private void StopAll()
    {
        pauseMenu.SetActive(false);
        PlayerPrefs.SetFloat("score", score);
        failed.SetActive(true);
        Time.timeScale = 0;
    }
    
}
