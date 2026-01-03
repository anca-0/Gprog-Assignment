using UnityEngine;

public class Scanning : MonoBehaviour
{
    private Transform sweepTranf;
    private float rotationspeed;
    private float Distance;

    private void Awake()
    {
        sweepTranf = transform.Find("Sweep_pivot");
        rotationspeed = 100f; // degrees per second
        Distance = 6f;
    }
    private static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private void Update()
    {
        sweepTranf.eulerAngles -= new Vector3(0, 0, rotationspeed * Time.deltaTime);
        //RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, GetVectorFromAngle(sweepTranf.eulerAngle.z), Distance);
        /*if(raycastHit2D.collider != null)
        {
            //hit something

        }*/
    }

}
