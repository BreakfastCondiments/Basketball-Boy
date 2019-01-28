using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public LayerMask whatIsBall;

    Camera cam;
    Vector3 explosionPosition;
    

    public float bounceForce;
    public float bounceRadius;
    public float upliftModifier;
    public bool usingUplift;

    void Start()
    {
        cam = Camera.main;
        

    }

    private void Update()
    {
        if (!GameManager.instance.gameOngoing)
            return;

//#if UNITY_ANDROID

//#endif

//#if UNITY

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = cam.ScreenPointToRay(Input.mousePosition).origin;
            point.z = 0;
            RaycastHit2D ray = IsBall(point);

            if (ray)
            {
                ray.collider.GetComponent<Ball>().Clicked();

            }else
            {
                CreateExplosionAtPoint(point);
               // Debug.Log("Bouncing at the following position : "+ point);
            }
        }
    }


    RaycastHit2D IsBall(Vector3 point)
    {
     

        RaycastHit2D result = Physics2D.Raycast(point, Vector3.forward, 15f, whatIsBall);

        return result;
    }

    void CreateExplosionAtPoint(Vector3 point)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(point, bounceRadius, whatIsBall);

        //Debug.Log("Number of Hits: " + hits.Length);

        foreach(Collider2D collider in hits)
        {
            //Debug.Log("Bounced " + collider.gameObject.name + ".");
            Bounce(collider.GetComponent<Rigidbody2D>(), point);
        }
    }




    //void Bounce(Rigidbody2D body,  vector3 explosionposition, float explosionradius)
    //{
    //    var dir = (body.transform.position - explosionposition);
    //    float wearoff = 1 - (dir.magnitude / explosionradius);
    //    body.addforce(dir.normalized * explosionforce * wearoff);
    //}

    void Bounce(Rigidbody2D body, Vector3 explosionPosition)
    {
        

        var dir = (body.transform.position - explosionPosition);
        float wearoff = 1 - (dir.magnitude / bounceRadius);
        Vector3 baseForce = dir.normalized * bounceForce * wearoff;
        //Debug.Log("Bouncing " + body.gameObject.name + " with the following force : " + baseForce);

        body.AddForce(baseForce);

        if (!usingUplift)
            return;

        float upliftWearoff = 1 - upliftModifier / bounceRadius;
        Vector3 upliftForce = Vector2.up * bounceForce * upliftWearoff;
        body.AddForce(upliftForce);
    }


}
