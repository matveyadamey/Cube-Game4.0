using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DropDown : MonoBehaviour
{

    public TextMeshProUGUI output;

    public void HandleInputData(int val)
    {
        string[] arr = { "Sochi", "Yerevan", "Gorno - Altaysk", "Moscow", "Buenos - Aires", "Montevideo", "Helsinki", "Ottawa", "Almaty", "Dubai", "Cape Town", "Cairo" };
        string file="C:/Users/matve/Documents/GitHub/Cube-Game4.0/Assets/Scripts/city.txt";
        File.WriteAllText(file, arr[val-1]);
    }
}