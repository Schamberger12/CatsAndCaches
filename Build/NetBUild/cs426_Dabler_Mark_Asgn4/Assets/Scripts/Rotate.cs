using UnityEngine;

public class Rotate : MonoBehaviour
{

    private Vector3 rotate = new Vector3(5, 0, 0);

    void Update()
    {

        transform.Rotate(rotate * Time.deltaTime);


        transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }
}