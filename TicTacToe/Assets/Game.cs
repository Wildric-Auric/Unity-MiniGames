using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    Transform[] pos;
    Transform crossObj;
    Transform circleObj;
    bool whoPlays;
    bool gameRun = true;
    List<string> crossPlayer = new List<string>();
    List<string> circlePlayer = new List<string>();
    [SerializeField] float maxDis = 0.2f;
    public bool crossWin;
    public bool circleWin;
    void Start()
    {
        Transform posObj = GameObject.Find("Positions").transform ;
        crossObj = GameObject.Find("AllCross").transform;
        circleObj = GameObject.Find("AllCircle").transform;
        pos = new Transform[posObj.childCount];
        for (int i = 0; i < posObj.childCount; i++)
        {
            pos[i] = posObj.GetChild(i);
        }
    }

    void Update()
    {
        if (gameRun)
        {
            foreach (Transform posi in pos)
            {
                if ((Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), posi.position) < maxDis) && Input.GetMouseButtonUp(0) && posi.gameObject.activeSelf)
                {
                    if (!whoPlays)
                    {
                        var temp = crossObj.GetChild(0);
                        temp.SetParent(null);
                        temp.position = posi.position;
                        temp.gameObject.SetActive(true);
                        crossPlayer.Add(posi.name);

                    }
                    else
                    {
                        var temp = circleObj.GetChild(0);
                        temp.SetParent(null);
                        temp.position = posi.position;
                        temp.gameObject.SetActive(true);
                        circlePlayer.Add(posi.name);
                    }
                    whoPlays = !whoPlays;
                    posi.gameObject.SetActive(false);
                }
            }
            if (crossObj.childCount == 0)
            {
   
                var temp1 = Int16.Parse((crossPlayer[0][0]).ToString()) + Int16.Parse((crossPlayer[1][0]).ToString()) + Int16.Parse((crossPlayer[2][0]).ToString()); 
                var temp2 = Int16.Parse(crossPlayer[0][1].ToString()) + Int16.Parse(crossPlayer[1][1].ToString()) + Int16.Parse(crossPlayer[2][1].ToString());
        
                if ((temp1 == 3 && temp2 == 0) || (temp2 == 3 && temp1 == 0) || (temp1 == 3 && temp2 == 3))
                {
                    crossWin = true;
                    gameRun = false;
                }

            }
            if (circleObj.childCount == 0)
            {
                gameRun = false;
                var temp1 = Int16.Parse((circlePlayer[0][0]).ToString()) + Int16.Parse((circlePlayer[1][0]).ToString()) + Int16.Parse((circlePlayer[2][0]).ToString());
                var temp2 = Int16.Parse((circlePlayer[0][1]).ToString()) + Int16.Parse(circlePlayer[1][1].ToString()) + Int16.Parse((circlePlayer[2][1]).ToString());
                if ((temp1 == 3 && temp2 == 0) || (temp2 == 3 && temp1 == 0) || (temp1 == 3 && temp2 == 3))
                {
                    circleWin = true;
                    gameRun = false;
                }
            }
            
        }
    }
}
