using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class volume : MonoBehaviour
{
    public float musicVolume;
    public float value;
    private void Start()
    {
        var v = AudioListener.volume;
        GetComponent<Slider>().value = v;
    }
    void Update()
    {
        value=PlayerPrefs.GetFloat("volume");
        GetComponent<Slider>().value = value;
    }
    public void setVolume(float vol)
    {

        musicVolume = vol;
        PlayerPrefs.SetFloat("volume", musicVolume);
        AudioListener.volume = musicVolume;
    }

}
