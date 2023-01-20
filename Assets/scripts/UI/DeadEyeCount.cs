using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadEyeCount : MonoBehaviour
{
    public Text deadEye;

    // Update is called once per frame
    void Update()
    {
        deadEye.text = Counter.DeadEyeNumber.ToString();
    }
}
