using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class LevelSpawn : MonoBehaviour
{
    public GameObject[] Prefabs;
    void Start()
    {
        string[] winterCitys = { "Yerevan", "Gorno - Altaysk", "Helsinki", "Ottawa", "Almaty" };
        string file1 = @"C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/city.txt";
        string num = File.ReadAllText(file1);
        if (winterCitys.Contains(num))
        {
            GameObject lev = Instantiate(Prefabs[1], new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(lev, 24);
        }
        else
        {
            GameObject lev = Instantiate(Prefabs[0], new Vector3(0, 0, 0), Quaternion.identity);
            Destroy(lev, 24);
        }
    }
}
