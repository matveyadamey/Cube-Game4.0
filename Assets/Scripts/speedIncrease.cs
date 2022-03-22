using System.Collections;
using UnityEngine;

public class speedIncrease : MonoBehaviour
{
  void Start()
    {
        MoveController.speed = 15;
        StartCoroutine(SpeedIncreaser());
    }
    IEnumerator SpeedIncreaser()
    {
        while (true)
        {
            MoveController.speed += 1;
            yield return new WaitForSeconds(8);
        }

    }
}
