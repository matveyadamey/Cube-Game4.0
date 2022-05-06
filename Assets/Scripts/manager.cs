using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class manager : MonoBehaviour
{
    private GameObject complete;
    private GameObject[] music;
    private GameObject confeti;
    private int rand;
    public static int moneyInGame=0;
    private GameObject moneyEffect;
    Aboba aboba;
    public GameObject player;
    private Text moneyText;

    
    void Start()
    {
        print("it is new");
        aboba = GameObject.Find("aboba").GetComponent<Aboba>();
        complete = aboba.complete;
        music = aboba.music;
        confeti = aboba.confeti;
        moneyEffect = aboba.moneyEffect;
        Time.timeScale = 1;
        rand = Random.Range(0, music.Length);
        music[rand].SetActive(true);
        moneyText = aboba.moneyText;
        moneyText.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
            if (other.tag == "money")
            {
             moneyInGame++;
             moneyText.text = moneyInGame.ToString();
             moneyText.gameObject.SetActive(true);
             var main = moneyEffect.GetComponent<ParticleSystem>().main;
             main.startColor = player.gameObject.GetComponent<MeshRenderer>().material.color;
             Instantiate(moneyEffect,transform.position, Quaternion.identity);
             Destroy(other.gameObject);
            }

            if (other.tag == "win")
            {
                StartCoroutine(win()); 
            }
    }
    private IEnumerator win()
    {
        confeti.SetActive(true);
        music[rand].SetActive(false);
        yield return new WaitForSeconds(1f);
        timer.NotPause = false;
        complete.SetActive(true);
        Time.timeScale = 0;
    }
}