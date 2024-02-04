using UnityEngine;
using System.Linq;
using System.IO;

public class levelGenerator : MonoBehaviour
{
    public GameObject[] Prefabs;
    public Transform Point;
    private bool isActive=true;
    string num;
    string[] winterCitys = { "Yerevan", "Gorno - Altaysk", "Helsinki", "Ottawa", "Almaty" };
    private void Start()
    {
        string file1 = @"C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/city.txt";
        num = File.ReadAllText(file1);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && isActive)
        {
            isActive = false;
            int numberlevel;
            if (winterCitys.Contains(num))
            {
                GameObject lev = Instantiate(Prefabs[1], Point.position, Quaternion.identity);
                Destroy(lev, 24);
            }
            else
            {
                GameObject lev = Instantiate(Prefabs[0], Point.position, Quaternion.identity);
                Destroy(lev, 24);
            }
        }
    }
}