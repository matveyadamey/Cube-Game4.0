using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.AzureSky
{
    public class WeatherController : MonoBehaviour
    {
        public AzureWeatherController Azure;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("h"))
            {
                Azure.SetNewWeatherProfile(6);
            }
            if (Input.GetButton("j"))
            {
                Azure.SetNewWeatherProfile(2);
            }
            if (Input.GetButton("k"))
            {
                Azure.SetNewWeatherProfile(7);
            }
            if (Input.GetButton("l"))
            {
                Azure.SetNewWeatherProfile(0);
            }
        }
    }
}
