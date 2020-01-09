using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para cambiar el sorting layer de cualquier texto en pantalla y que se vea en frente de otros sprites
public class TextSortingLayer : MonoBehaviour
{
         public string SortingLayerName = "Default";
         public int SortingOrder = 0;
 
         void Awake ()
         {
                 gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
                 gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
         }
}
