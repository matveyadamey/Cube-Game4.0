using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    public GameObject[] Prefabs;
    public Transform Point;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            var numberlevel = Random.Range(0, Prefabs.Length);
            Instantiate(Prefabs[numberlevel], Point.position, Quaternion.identity);
            Destroy(this.gameObject.transform.parent.gameObject, 12);
        }
    }
}