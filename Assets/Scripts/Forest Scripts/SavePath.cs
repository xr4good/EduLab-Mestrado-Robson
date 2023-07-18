using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SavePath : MonoBehaviour
{
    public List<Vector3> path;
    public int start = 0;
    private Vector3 goal;
    public LineRenderer lineRenderer;

    private Color lineColor = Color.white;

    public int colors = 0;

    public bool recording = false;


    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (colors == 0)
        {
            lineColor = Color.white;
        }else if(colors == 1)
        {
            lineColor = Color.green;
        }else if(colors == 2)
        {
            lineColor = Color.yellow;
        }
        else
        {
            lineColor = Color.red;
        }



        if (recording)
        {
            if(path.Count == 0)
            {
                path.Add((Vector3)transform.position);
            }
            else
            {
                if (Goal(transform.position, start))
                {
                    Instantiate(lineRenderer);
                    lineRenderer.SetColors(lineColor, lineColor);
                    recording = false;
                    lineRenderer.positionCount = path.Count;
                    for (int i = 1; i < path.Count; i++)
                    {
                        lineRenderer.SetPosition(i, path[i]);
                    }

                }
                else if (transform.position != path[path.Count - 1])
                {
                    path.Add(new Vector3(transform.position.x, 6.2f, transform.position.z));
                }
            }
            
        }
        
    }

    private bool Goal(Vector3 pos, int start)
    {
        if(start == 0)
        {
            if (pos.x < 5.3 && pos.x > 4.7)
            {
                if (pos.z > -17.3 && pos.z < -16.7)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            if (pos.x < 5.3 && pos.x > 4.7)
            {
                if (pos.z > -15.3 && pos.z < -14.7)
                {
                    return true;
                }
            }
            return false;
        }
        
    }

    public void StarRecording()
    {
        recording = true;
    }

    public void ChangeColor(int newColor)
    {
        colors = newColor;
    }

    public void SetStart(int n)
    {
        start = n;
    }


}
