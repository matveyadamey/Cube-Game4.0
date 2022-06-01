
using UnityEngine;
public class MusicSaver : MonoBehaviour
{
    [SerializeField] private GameObject music;
    GameObject[] target_2;
    private void Awake()
    {
        DontDestroyOnLoad(music);
        DontDestroyOnLoad(gameObject);
    }
    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            target_2 = GameObject.FindGameObjectsWithTag("music");
            if (target_2.Length > 1)
            {
                Destroy(target_2[1]);
            }
        }
        if (level == 2)
        {
            Destroy(music);
        }
    }

}
