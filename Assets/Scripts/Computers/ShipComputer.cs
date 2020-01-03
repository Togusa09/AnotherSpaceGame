using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Computers;
using UnityEngine;

public class ShipComputer : MonoBehaviour
{
    [SerializeField] private Wire Output1;
    [SerializeField] private Wire Input1;
    [SerializeField] private Wire Input2;
    [SerializeField] private Wire Input3;
    [SerializeField] private Wire Input4;

    private ComputerCore ComputerCore;
    [Multiline]
    [SerializeField] private string Program;



    void Start()
    {
        ComputerCore = new ComputerCore(Program);
    }

    // Update is called once per frame
    void Update()
    {
        if (ComputerCore == null) ComputerCore = new ComputerCore(Program);

        ComputerCore.Input1 = Input1.Value;

        ComputerCore.Step();
        Output1.Value = ComputerCore.Output1;
    }
}
