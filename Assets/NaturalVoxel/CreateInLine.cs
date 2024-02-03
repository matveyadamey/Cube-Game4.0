using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Line
{
    [SerializeField] string Nom;
    public List<GameObject> item;
}

public class CreateInLine : MonoBehaviour
{
    [SerializeField] int DistanceItem;
    [SerializeField] int DistanceLigne;
    [SerializeField] Line[] line;

    // Start is called before the first frame update
    void Awake()
    {
        for (int j = 0; j < line.Length;j++)
        {
            for (int i = 0; i < line[j].item.Count; i++)
            {
                Instantiate(line[j].item[i], new Vector3(i*DistanceItem, 0,j*DistanceLigne) + transform.position, Quaternion.identity,this.transform);
            }
        }
    }
}
