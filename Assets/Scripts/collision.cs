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
    public int LifeCount = 3;
    public GameObject[] hearts;
    private ParticleSystem PlayerEffect;
    int i = 0;
    private GameObject camera;
    ParticleSystem spawn;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        money = PlayerPrefs.GetInt("money");
        aboba = GameObject.Find("aboba").GetComponent<Aboba>();
        hearts = aboba.hearts;
        heart = aboba.heart;
        PlayerEffect = aboba.PlayerEffect;
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
            spawn.transform.position = new Vector3(transform.position.x, transform.position.y - 0.7f, transform.position.z - 0.7f);
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
        if(other.gameObject.tag == "earth"| other.gameObject.tag == "lat")
        {
            spawn = Instantiate(PlayerEffect, new Vector3(transform.position.x, transform.position.y-0.7f, transform.position.z - 0.5f),
                Quaternion.Euler(90,0,0));
            spawn.Play();
        }
        if (other.gameObject.tag == "enemy")
        {
            TryDestroyHeart();
            if (LifeCount > 0)
            {
                camShaker.Shake(0.15f, 0.3f);
                effect.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = Resources.Load<Material>("Materials/enemys");
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.tag == "lat")
        {
            print(2323);
            other.gameObject.GetComponent<MeshCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            TryDestroyHeart();
            if (LifeCount > 0)
                {
                    print(65656);
                    camShaker.Shake(0.15f, 0.3f);
                    transform.position = other.transform.position + new Vector3(0, 5, -6);
                    effect.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = Resources.Load<Material>("Materials/enemys");
                    Instantiate(effect, transform.position, Quaternion.identity);
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
    private void OnCollisionExit(Collision collision)
    {
        spawn.Stop();
    }
    private void Death()
    {
        camShaker.Shake(0.15f, 0.3f);
        effect.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        Instantiate(effect, new Vector3(transform.position.x, transform.position.y, transform.position.z+40), Quaternion.identity);
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