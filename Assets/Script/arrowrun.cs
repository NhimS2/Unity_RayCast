using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowrun : MonoBehaviour
{   
    public gun script;
    float t = 0;
    public GameObject ShotPoint;
    public Vector2 huong;
    private void Start()
    {
        script = GameObject.Find("Gun").GetComponent<gun>();
        huong = script.direction.normalized;
    }
    private void Update()
    {
        t += Time.deltaTime;

        transform.position = PointPosition(t);
        RaycastHit2D hit = Physics2D.Raycast(script.ShotPoint.position, script.direction, 20);

        Debug.DrawLine(script.ShotPoint.position, script.direction, Color.green);
        
        if(hit.collider != null)
        {
            if(hit.collider.tag == "Player")
            {
                Debug.Log(hit.collider.tag+ " Đụng r nha");
                Destroy(gameObject);
            }
        }


    }
        
    Vector2 PointPosition(float t)
    {
        
        Vector2 position = (Vector2)script.ShotPoint.position + (huong * script.launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }




}
