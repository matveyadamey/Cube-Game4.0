using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    private Text timerStart;
    public static bool NotPause=false;
    public bool timeStart;
    private int timeToStart;
    GameObject aboba;
    void Start()
    {
        aboba = GameObject.Find("aboba");
        timerStart = aboba.GetComponent<Aboba>().timerStart;
        timeToStart = 4;
        NotPause = false;
        timeStart = true;
        if (timeStart)
        {
            StartCoroutine(GameStart());
        }
    }
    private IEnumerator GameStart()
    {
        for (; ; )
        {
            timeToStart -= 1;
            timerStart.text = timeToStart.ToString();
            if (timeToStart <= 0)
            {
                NotPause = true;
                Destroy(timerStart);
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
