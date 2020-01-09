using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    static int enemiesCount = 0;
    TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        enemiesCount += GameObject.FindGameObjectsWithTag("normalEnemy").Length;
        enemiesCount += GameObject.FindGameObjectsWithTag("rangeEnemy").Length;
        enemiesCount += GameObject.FindGameObjectsWithTag("bigEnemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemigos: " + enemiesCount;
    }
}
