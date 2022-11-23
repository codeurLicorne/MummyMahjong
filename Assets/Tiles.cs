using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public Sprite backTile;
    public Sprite frotnTile;


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = frotnTile;
    }
}
