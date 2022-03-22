using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseManager : MonoBehaviour
{
    private bool game_is_paused;
    public Sprite pic1;
    public Sprite pic2;
    public Image im;
    public manager script1;
    public controller script2;
    public GameObject pauseMenu;
    void Start()
    {
        timer.NotPause = false;
    }
    public void pause()
    {
        pauseMenu.SetActive(true);
        timer.NotPause = false;
        game_is_paused = true;
        im.sprite = pic1;

    }
    void resume()
    {
        pauseMenu.SetActive(false);
        timer.NotPause = true;
        game_is_paused = false;
        im.sprite = pic2;
    }
    public void check()
    {
        if (game_is_paused)
        {
            resume();
        }
        else
        {
            pause();
        }
    }
}
