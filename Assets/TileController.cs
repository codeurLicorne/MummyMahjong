using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public TileController[] AdTiles;
    GameManager GM;

    public string tileName;
    public SpriteRenderer tileColor;
    public bool isMatched;

    public bool selected;

    public bool active = false;

    private void Awake()
    {
        tileColor = GetComponent<SpriteRenderer>();
        tileName = gameObject.name;

        selected = false;

        GM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        ActiveState();
        Selected();
    }

    private void Selected()
    {
        if(selected)
        {
            tileColor.color = Color.yellow;
        }
        else if(active == false)
        {
            tileColor.color = Color.grey;
        }
        else if (active == true && selected == false)
        {
            tileColor.color = Color.white;
        }
    }


    private void ActiveState()
    {
        if(active == false)
        {
            tileColor.color = Color.grey;
        }
        else
        {
            tileColor.color = Color.white;
        }
    }

    public void TileActivate()
    {
        for (int i=0; 1<AdTiles.Length; i++)
        {
            if(AdTiles[i].active == false)
            {
                AdTiles[i].active = true;
            }
            else
            {
                return;
            }
        }
    }

    public void OnMouseDown()
    {
        if(active == true)
        {
            selected = !selected;
        }

        if(active && GM.tileA.Length <=0)
        {
            GM.tileA = tileName;
        }
        else if(active && GM.tileA.Length >0)
        {
            GM.tileB = tileName;
        }
    }

    public void Matched(bool state)
    {
        isMatched = state;
    }

    public void OnMatch(bool Matched)
    {
        TileActivate();

        if (Matched == true && active == true && tileName == GM.tileA || tileName == GM.tileB)
        {
            gameObject.SetActive(false);
        }
    }
}
