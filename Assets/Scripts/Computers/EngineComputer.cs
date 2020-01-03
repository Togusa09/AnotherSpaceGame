using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineComputer : MonoBehaviour
{
    [SerializeField] private Wire Input1;

    [SerializeField]
    public IndicatorLight Light;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Light.Colour = Input1.Value == 1 ? LightColour.Green : LightColour.Red;
    }
}
