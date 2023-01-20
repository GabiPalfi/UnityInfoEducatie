using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RockCount : MonoBehaviour
{
    public Text countRock;
    // Update is called once per frame
    void Update()
    {
        countRock.text = Counter.rockDestroyed.ToString();
    }
}
