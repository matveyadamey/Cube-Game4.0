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
            string file1 = @"Assets/Scripts/weather.txt";
            weatherState = int.Parse(File.ReadAllText(file1));
            Azure.SetNewWeatherProfile(weatherState);
            string file2 = @"Assets/Scripts/time.txt";
            time = int.Parse(File.ReadAllText(file2));
            Time.SetTimeline(time);
        }
    }
}
