using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveWithShadow : MonoBehaviour
{
    public bool isEnter = false;
    public Shadow shadow;

    public Vector3 mousePos;

    public Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        ////if (isEnter)
        ////{
        //    shadow.effectDistance = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y);

        //}
        //else
        //{
        //    shadow.effectDistance = new Vector2(7, -7);
        ////}
       
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = /*Camera.main.ScreenToWorldPoint*/(Input.mousePosition);

        Debug.Log(mousePos);

        if (isEnter)
        {
            shadow.effectDistance = new Vector2(((transform.position.x - mousePos.x)/10), ((transform.position.y - mousePos.y)/10));
            lastPos = shadow.effectDistance;
        }
        else
        {
            shadow.effectDistance = /*Vector3.MoveTowards(lastPos, */new Vector2(7,-7)/*,Time.deltaTime*4)*/;
        }
    }

    public void entered()
    {
        isEnter = true;

    }

    public void closed()
    {
        isEnter = false;

    }
}
