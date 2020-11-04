using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float forwardForce = 6000f;
    float sidewaysForce = 100f;
    float input = default;

    void Update()
    {
        input = Input.GetAxis(RectTransform.Axis.Horizontal.ToString());
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, forwardForce * Time.deltaTime);
        GetComponent<Rigidbody>().AddForce(input * sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void StopMovement()
    {
        forwardForce = 0f;
        sidewaysForce = 0f;
    }
}
