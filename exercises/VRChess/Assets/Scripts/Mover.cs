using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Mover : MonoBehaviour
{
    private InputDevice _device;
    private CharacterController _charater;
    private Vector2 _inputAxis;
    // Start is called before the first frame update
    void Start()
    {
        _device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        _charater = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputAxis);
        _charater.Move(new Vector3(_inputAxis.x, 0, _inputAxis.y) * Time.deltaTime * 1f);
    }
}
