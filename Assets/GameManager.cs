using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject WinUI;

    public GameObject[] Tiles;
    public bool[] TilesMatched;

    public string tileA;
    public string tileB;

    public float timer;

   
    void Update()
    {
        OnMatch();
        TileReset();
        WinCheck();
        timer += Time.deltaTime;
    }

    void Matches(int pos)
    {
        if(TilesMatched[pos]==true)
        {
            return;
        }
        else
        {
            TilesMatched[pos] = true;
        }

        Tiles[pos].GetComponent<TileController>().Matched(TilesMatched[pos]);
    }

    void TileReset()
    {
        for(int i =0; i< Tiles.Length; i++)
        {
            if(tileA.Length > 0 && tileB.Length >0 && timer >=2)
            {
                tileA = "";
                tileB = "";
                timer = 0;
            }
        }
    }
    void OnMatch()
    {
        for(int i =0; i<Tiles.Length; i++)
        {
            if(tileA.Length>0&& tileB.Length>0)
            {
                if(tileA != tileB)
                {
                    tileA = "";
                    tileB = "";
                }
                else if(tileA == tileB)
                {
                    if(Tiles[i].GetComponent<TileController>().tileName == tileA || Tiles[i].GetComponent<TileController>().tileName == tileB)
                    {
                        Tiles[i].GetComponent<TileController>().OnMatch(true);
                        Tiles[i].GetComponent<TileController>().Matched(true);
                        Matches(i);
                    }
                }
            }
        }
    }

    bool WinCheck()
    {
        for(int i =0; i< TilesMatched.Length; i++)
        {
            if(TilesMatched[i] == false)
            {
                return false;
            }
        }
        WinUI.SetActive(true);
        Debug.Log("youwin");
        return true;
    }
}
