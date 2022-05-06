using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField] private GameObject skin;
    int NumberSkin;
    string nameSkin;

    
    void Awake()
    {
        NumberSkin = PlayerPrefs.GetInt("skinNum");
        if (NumberSkin == 0)
        {
            NumberSkin = 1;
        }
        string skinName = "skins/" + "player" + NumberSkin.ToString();

        var skin = Resources.Load(skinName) as GameObject;
        GameObject player = Instantiate(skin,new Vector3(), Quaternion.identity);
        player.transform.SetParent(transform.transform, false);
    }
}
