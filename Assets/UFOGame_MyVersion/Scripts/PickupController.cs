using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{

    //Update is called every frame
    void Update()
    {
        // Pulsates the scale of the pickup over time.
        float scale = 1.0f + Mathf.PingPong(Time.time, 0.5f);
        transform.localScale = new Vector3(scale, scale, 1.0f);

        // Rotate the pickup.
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }
}
