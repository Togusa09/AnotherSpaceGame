using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Wire _wire;
    [SerializeField] private GameObject _presser;

    [SerializeField] private bool _pressed;

    public bool Pressed => _pressed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _presser.transform.localPosition = _pressed ? new Vector3(0, -0.1f, 0) : new Vector3(0, 0, 0);
        _wire.Value = _pressed ? 1 : 0;
    }

    public void Press()
    {
        _pressed = true;
    }

    public void Release()
    {
        _pressed = false;
    }
}
