using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemy;
    // Update is called once per frame
    void Update()
    {
        enemy.text = Counter.enemyKilled.ToString();
    }
}
