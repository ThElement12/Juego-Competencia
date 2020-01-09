using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarLuces : MonoBehaviour
{
    private void OnBecameInvisible()
    {

        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }
    private void OnBecameVisible()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }
}
