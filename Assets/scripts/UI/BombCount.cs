using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCount : MonoBehaviour
{
    public Text countBomb;
    void Update()
    {
        countBomb.text = Counter.bombNumber.ToString();
    }
}
