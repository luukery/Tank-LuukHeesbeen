using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject tankTower;
    int rotateSpeed = 75;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            tankTower.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetAxis("Mouse X") > 0)
        {
            tankTower.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
