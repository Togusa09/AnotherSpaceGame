using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightColour
{
    Green, Red
}

public class IndicatorLight : MonoBehaviour
{
    [SerializeField] 
    public LightColour Colour;

    public Material Green;
    public Material Red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mat = Colour == LightColour.Green ? Green : Red;
        GetComponent<Renderer>().material = mat;
    }
}
