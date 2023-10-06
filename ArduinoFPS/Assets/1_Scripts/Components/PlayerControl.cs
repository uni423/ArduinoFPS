using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform bulletPoint;

    public float turnSpeed = 4.0f; // 마우스 회전 속도

    private float xRotate = 0.0f; // 내부 사용할 X축 회전량은 별도 정의 ( 카메라 위 아래 방향 )

    private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    public Vector3 quaternion;
    void Start()
    {
        StartCoroutine(InitializeGyro());
    }

    IEnumerator InitializeGyro()
    {
        yield return new WaitForSeconds(1f);
        GyroManager.Instance.EnableGyro();
    }

    void Update()
    {
        //이동
#if UNITY_EDITOR
        MouseRotation();
#else
        transform.localRotation = Quaternion.Euler(quaternion) * (GyroManager.Instance.GetGyroRotation() * baseRotation);
#endif

        //공격
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire");
            GameObject bullet = GameManager.ObjectPooling.Spawn("Bullet");
            bullet.transform.SetPositionAndRotation(bulletPoint.position, bulletPoint.rotation);
        }
    }

    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        //transform.Rotate(Input.gyro.rotationRateUnbiased.x, Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);
        //Debug.Log(Input.gyro.attitude); // attitude has data now
    }
}
