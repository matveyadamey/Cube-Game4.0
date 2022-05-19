using UnityEngine;

public class flyCamera : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x,0);
    }
}
