using UnityEngine;

public class MouseLook : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        _currentMouseLook = new Vector2(Input.GetAxis(MouseAxis.MouseY), Input.GetAxis(MouseAxis.MouseX));
        _lookAngles.x += _currentMouseLook.x * _sensivity * (_invert ? 1f : -1f);
        _lookAngles.y += _currentMouseLook.y * _sensivity;
        _lookAngles.x = Mathf.Clamp(_lookAngles.x, _defaultLookLimits.x, _defaultLookLimits.y);

        _lookRoot.localRotation = Quaternion.Euler(_lookAngles.x, 0f, 0f);
        _playerRoot.localRotation = Quaternion.Euler(0f, _lookAngles.y, 0f);
    }

    [SerializeField] private Transform _playerRoot, _lookRoot;
    [SerializeField] private readonly bool _invert = true;
    [SerializeField] private readonly float _sensivity = 5f;
    [SerializeField] private readonly Vector2 _defaultLookLimits = new Vector2(-70f, 80f);
    private Vector2 _lookAngles, _currentMouseLook;
}
