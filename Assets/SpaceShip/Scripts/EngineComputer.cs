using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineComputer : MonoBehaviour
{
    [SerializeField] private GameObject Ship;
    [SerializeField] private Wire Input1;
    [SerializeField] private int EnginePower;

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
        if (Input1.Value > 0)
        {
            var shipBody = Ship.GetComponent<Rigidbody>();
            shipBody.AddForce(new Vector3(1, 0, 0) * EnginePower * Time.deltaTime);
            //shipBody.velocity = new Vector3(1, 0, 0);
        }
    }
}
