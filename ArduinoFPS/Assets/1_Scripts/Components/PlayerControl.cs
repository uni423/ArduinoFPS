using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도

    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

    private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    void Start()
    {
        StartCoroutine(InitializeGyro());
    }

    IEnumerator InitializeGyro()
    {
        yield return new WaitForSeconds(1f);
        GyroManager.Instance.EnableGyro();
        //Input.gyro.enabled = true;
        //yield return null;
        //Debug.Log(Input.gyro.attitude); // attitude has data now
    }

    void Update()
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
        //MouseRotation();
    }

    void MouseRotation()
    {
        //float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        //float yRotate = transform.eulerAngles.y + yRotateSize;

        //float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        //xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        //transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        //transform.Rotate(Input.gyro.rotationRateUnbiased.x, Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
        //Debug.Log(Input.gyro.attitude); // attitude has data now

    }
}
