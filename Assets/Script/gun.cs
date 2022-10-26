using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject Gun;
    public float launchForce;
    public Transform ShotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoint;
    public Vector2 direction;

    private void Start()
    {
        points = new GameObject[numberOfPoints];
        for(int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, ShotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 gunPotision = transform.position;
        Vector2 mousePotision = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePotision - gunPotision;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoint);
        }
        void Shoot()
        {
            GameObject newGun = Instantiate(Gun, ShotPoint.position, ShotPoint.rotation);
            newGun.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

        }
        Vector2 PointPosition(float t)
        {
            Vector2 position = (Vector2)ShotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
            return position;
        }
    }
}
