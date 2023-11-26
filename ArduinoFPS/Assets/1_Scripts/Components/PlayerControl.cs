using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region [Value]
    #region [��]
    public Transform bulletPoint;

    public int bulletCountMax;
    public int bulletCountCur;
    #endregion
    #region [�̵�]
    public float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�

    private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )

    private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    public Vector3 quaternion;
    #endregion
    #endregion

    void Start()
    {
        StartCoroutine(InitializeGyro());

        bulletCountMax = 5;
        OnReload();
    }

    void Update()
    {
        //�̵�
#if UNITY_EDITOR
        MouseRotation();
#else
        transform.localRotation = Quaternion.Euler(quaternion) * (GyroManager.Instance.GetGyroRotation() * baseRotation);
#endif

        //����
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Home))
        {
            //Debug.Log("Fire");
            OnFire();
        }
        else if (Input.touchCount >= 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //Debug.Log("Fire");
                OnFire();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
            OnReload();
    }

    public void OnFire()
    {
        if (bulletCountCur > 0)
        {
            bulletCountCur--;
            GameObject bullet = InGameManager.ObjectPooling.Spawn("Bullet");
            bullet.transform.SetPositionAndRotation(bulletPoint.position, bulletPoint.rotation);
            UIManager.Instance.RefreshUserInfo();
        }
    }

    public void OnReload()
    {
        if (bulletCountCur < bulletCountMax)
        {
            bulletCountCur = bulletCountMax;
            UIManager.Instance.RefreshUserInfo();
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

    #region [Coroutine]
    IEnumerator InitializeGyro()
    {
        yield return new WaitForSeconds(1f);
        GyroManager.Instance.EnableGyro();
    }
    #endregion
}
