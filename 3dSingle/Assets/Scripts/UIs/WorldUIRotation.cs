using UnityEngine;

public class WorldUIRotation : MonoBehaviour
{
    public Camera MainCamera;

    void Start()
    {
        if (MainCamera == null)
        {
            // ���� mainCamera�� �������� �ʾҴٸ�, �±װ� "MainCamera"�� ī�޶� ã�� ����
            MainCamera = Camera.main;
        }
    }

    void Update()
    {
        // UI�� �׻� ī�޶� ���ϵ��� ����
        transform.LookAt(transform.position + MainCamera.transform.rotation * Vector3.forward,
                         MainCamera.transform.rotation * Vector3.up);
    }
}