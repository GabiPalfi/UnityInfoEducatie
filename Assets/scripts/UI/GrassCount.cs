using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassCount : MonoBehaviour
{
    public Text countGrass;
    // Update is called once per frame
    void Update()
    {
        countGrass.text = Counter.grassDestroyed.ToString();
    }
}
