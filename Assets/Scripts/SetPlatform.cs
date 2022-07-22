using UnityEngine;

public class SetPlatform : MonoBehaviour
{
    public void PlatformSet(int num)
    {
        PlayerPrefs.SetInt("platformNum",num);
    }
}
