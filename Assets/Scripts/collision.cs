using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

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
    public int LifeCount = 3;
    public GameObject[] hearts;
    int i = 0;
    private Animator camAnim;
    private GameObject camera;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        money = PlayerPrefs.GetInt("money");
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
            ScoreText.text = "��� ����: " + score.ToString();
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
                camShaker.Shake(0.15f, 0.3f);
                //camAnim.SetTrigger("shake");
                effect.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = Resources.Load<Material>("Materials/enemys");
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "lat")
        {
            var front = other.gameObject.transform.position.z - 3.5;
            if (transform.position.z < front)
            {
                TryDestroyHeart();
                if (LifeCount > 0)
                {
                    camShaker.Shake(0.15f, 0.3f);
                    transform.position = other.transform.position + new Vector3(0, 5, -6);
                    effect.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = Resources.Load<Material>("Materials/enemys");
                    Instantiate(effect, transform.position, Quaternion.identity);
                }
            }
        }
        if (other.gameObject.tag == "floor")
        {

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
        camShaker.Shake(0.15f, 0.3f);
        effect.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        Instantiate(effect, transform.position, Quaternion.identity);
        timer.NotPause = false;
        gameObject.SetActive(false);
        music[rand].SetActive(false);
        failedSound.SetActive(true);
        money += manager.moneyInGame;
        PlayerPrefs.SetInt("money", money);
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