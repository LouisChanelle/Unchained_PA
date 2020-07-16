using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int scr;

    public Score()
    {
        scr = 0;
    }

    /*public int Scr
    {
        get { return scr; }
        set { scr = value; }
    }*/
    

    public int GetScore()
    {
        return this.scr;
    }

    public void SetScore(int _scr)
    {
        scr = _scr;
    }
}
