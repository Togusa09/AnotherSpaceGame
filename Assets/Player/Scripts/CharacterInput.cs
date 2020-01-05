using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    private Camera _camera;
    //private GameObject _current;
    private Button _current;

    void Start()
    {
        _camera = transform.GetComponentInChildren<Camera>();
        _current = null;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = null;
        var lookDirection = _camera.transform.forward;
        var mask = LayerMask.GetMask("Interactable");

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out var hitinfo, 100, layerMask: mask))
        {
            target = hitinfo.collider.gameObject;

            if (_current != target)
            {
                //_current?.Release();
            }

            _current = target.GetComponent<Button>();

        }
        else
        {
            if (_current != null)
            {
                //_current.Release();
            }
        }
        
        if (Input.anyKeyDown)
        {
            ProcessKeyDown(target);
        }
        else
        {
            ProcessKeyUp(target);
        }
    }

    void ProcessKeyDown(GameObject target)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (target?.GetComponent<Button>())
            {
                var button = target.GetComponent<Button>();
                if (button.Pressed)
                {
                    button.Release();
                }
                else
                {
                    button.Press();
                }
                    
            }
        }
    }

    void ProcessKeyUp(GameObject target)
    {

    }
}
