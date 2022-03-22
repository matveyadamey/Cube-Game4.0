using UnityEngine;

public class playerManager : MonoBehaviour
{
    public GameObject player;
    public Material skin;
    int NumberSkin;
    string nameSkin;
    void Start()
    {
        NumberSkin = PlayerPrefs.GetInt("skinNum");
        if (NumberSkin == 0)
        {
            NumberSkin = 1;
        }
    }
    void Update()
    {
        nameSkin = "skins/" + "playerMat" + NumberSkin.ToString();
        skin = Resources.Load<Material>(nameSkin);
        
        player.GetComponent<MeshRenderer>().material = skin;
    }
}
