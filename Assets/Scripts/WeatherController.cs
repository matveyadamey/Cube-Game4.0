using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace UnityEngine.AzureSky
{
    public class WeatherController : MonoBehaviour
    {
        public AzureWeatherController Azure;
        public AzureTimeController Time;
        int time;
        int weatherState;
        private void Start()
        {
            var pythonArgs = "C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/getAll.py";
            System.Diagnostics.Process.Start("python", pythonArgs);
            string file1 = @"weather.txt";
            if (File.Exists(file1))
            {
                weatherState = int.Parse(File.ReadAllText(file1));
            }
            string file2 = @"time.txt";
            if (File.Exists(file2))
            {
                time = int.Parse(File.ReadAllText(file2));
            }
            Time.SetTimeline(time);
            Azure.SetNewWeatherProfile(6);
        }
    }
}
