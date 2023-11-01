using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject tankBody;
    [SerializeField] GameObject[] wheels;
    float maxSpeed = 600;
    float currentSpeed;
    float acceleration = 1;
    float rotateSpeed = 20;

    enum TankSpeed
    {
        SLOW = 300,
        MID = 600,
        FAST = 900
    }
    [SerializeField]TankSpeed tankSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tankSpeed = TankSpeed.SLOW;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = tankBody.transform.forward * currentSpeed * Time.smoothDeltaTime;

        #region inputs
        if (Input.GetKey(KeyCode.W))
        {
            SpeedUp(true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SpeedUp(false);
        }
        else if(currentSpeed != 0)
        {
            SpeedDown();
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotatePlayer(false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatePlayer(true);
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if(tankSpeed != TankSpeed.SLOW)
                tankSpeed -= 300;

            maxSpeed = (int)tankSpeed;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if(tankSpeed != TankSpeed.FAST)
                 tankSpeed += 300 ;

            maxSpeed = (int)tankSpeed;

        }

        #endregion
    }

    void SpeedUp(bool speedUp)      
    {
        RotateWheels();

        if (speedUp)    //forward
        {
            if(maxSpeed > currentSpeed)
            {
                currentSpeed += acceleration;
            }
            else
            {
                currentSpeed = maxSpeed;
            }
        }
        else    //backwards
        {
            if(-maxSpeed < currentSpeed)
            {
                currentSpeed -= acceleration;
            }
            else
            {
                currentSpeed = -maxSpeed;
            }
        }
    }

    void SpeedDown()
    {
        RotateWheels();

        if (currentSpeed < 0)
        {
            currentSpeed += acceleration;

            if (currentSpeed > 0.2f)
            {
                currentSpeed = 0;
            }
        }
        else if (currentSpeed > 0)
        {
            currentSpeed -= acceleration;

            if (currentSpeed < 0.2f)
            {
                currentSpeed = 0;
            }
        }
    }

    void RotatePlayer(bool right)
    {
        if (right)
        {
            tankBody.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else
        {
            tankBody.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
    }

    void RotateWheels()
    {
        float wheelSpeed = currentSpeed * 0.5f;

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].transform.Rotate(new Vector3(wheelSpeed, 0, 0) * Time.deltaTime);
        }
    }
}
