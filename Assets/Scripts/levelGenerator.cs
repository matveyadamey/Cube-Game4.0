using UnityEngine;
using System.Linq;
using System.IO;

public class levelGenerator : MonoBehaviour
{
    public GameObject[] Prefabs;
    public Transform Point;
    private bool isActive=true;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && isActive)
        {
            isActive = false;
            int numberlevel;
            string[] winterCitys = { "Yerevan", "Gorno - Altaysk", "Helsinki", "Ottawa", "Almaty" };
            string file1 = @"C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/city.txt";
            string num = File.ReadAllText(file1);
            if (winterCitys.Contains(num)) numberlevel = 0;
            else numberlevel = 1;
            GameObject lev = Instantiate(Prefabs[numberlevel], new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(lev, 12);
        }
    }
}