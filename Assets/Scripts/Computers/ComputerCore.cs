using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Computers
{
    public enum NodeType
    {
        Value, Register, Command
    }

    public enum RegisterType
    {
        Input, Output
    }

    public enum Commands
    {
        Unknown,
        Add,
        Multiply,
        //Input,
        //Output,
        Copy,
        JumpIfTrue,
        JumpIfFalse,
        Jump,
        LessThan,
        Equals,
        Terminate = 99
    }


    class CodeValue
    {
        public CodeValue(int value, NodeType type)
        {
            Value = value;
            Type = type;
        }

        public CodeValue(int value, NodeType type, RegisterType registerType)
        {
            Value = value;
            Type = type;
            RegisterType = registerType;
        }

        public int Value { get; }
        public NodeType Type { get; }
        public RegisterType RegisterType { get; }

        public static CodeValue Parse(string s)
        {
            // Reference, not register
            //if (s.StartsWith("*"))
            //{
            //    return new CodeValue(int.Parse(s.Substring(1)), NodeType.Register);
            //}

            switch (s)
            {
                case "ADD": return new CodeValue((int)Commands.Add, NodeType.Command);
                case "MUL": return new CodeValue((int)Commands.Multiply, NodeType.Command);
                //case "INP": return new CodeValue((int)Commands.Input, NodeType.Command);
                //case "OUT": return new CodeValue((int)Commands.Output, NodeType.Command);
                case "CPY": return new CodeValue((int)Commands.Copy, NodeType.Command);
                case "JIT": return new CodeValue((int)Commands.JumpIfTrue, NodeType.Command);
                case "JIF": return new CodeValue((int)Commands.JumpIfFalse, NodeType.Command);
                case "JMP": return new CodeValue((int)Commands.Jump, NodeType.Command);
                case "LTN": return new CodeValue((int)Commands.LessThan, NodeType.Command);
                case "EQL": return new CodeValue((int)Commands.Equals, NodeType.Command);
                case "TER": return new CodeValue((int)Commands.Terminate, NodeType.Command);
            }

            if (int.TryParse(s, out var intval))
            {
                return new CodeValue(intval, NodeType.Value);
            }

            if (s.StartsWith("INP") || s.StartsWith("OUT"))
            {
                var regNum = int.Parse(s.Substring(3));
                switch (s.Substring(0, 3))
                {
                    case "INP": return new CodeValue(regNum, NodeType.Register, RegisterType.Input);
                    case "OUT": return new CodeValue(regNum, NodeType.Register, RegisterType.Output);
                }
            }
            
            throw new Exception("Unknown value");
        }
    }

    class ComputerCore
    {
        public int Output1 => _outputRegisters[0];
        public int Output2 => _outputRegisters[1];
        public int Output3 => _outputRegisters[2];
        public int Output4 => _outputRegisters[3];
        public int Output5 => _outputRegisters[4];

        public int Input1
        {
            set => _inputRegisters[0] = value;
        }

        [SerializeField]
        private int[] _memory = new int[8];


        //[SerializeField] private Dictionary<string, int> _registers = new Dictionary<string, int>();
        [SerializeField] private int[] _inputRegisters = new int[8];
        [SerializeField] private int[] _outputRegisters = new int[8];

        [SerializeField]
        private CodeValue[] _program = new CodeValue[128];
        [SerializeField]
        private int _instructionPointer = 0;

        public ComputerCore(string program)
        {
            var prog = program.Split(new[] {'\n', ' '})
                .Select(x => CodeValue.Parse(x))
                .ToArray();
            _program = prog;
        }

        //public int GetCommandCode(string s)
        //{
        //    int val;
        //    if (int.TryParse(s, out val)) return val;

        //    switch (s)
        //    {
        //        case "ADD": return (int)Commands.Add;
        //        case "MUL": return (int)Commands.Multiply;
        //        case "INP": return (int)Commands.Input;
        //        case "OUT": return (int)Commands.Output;
        //        case "JIT": return (int)Commands.JumpIfTrue;
        //        case "JIF": return (int)Commands.JumpIfFalse;
        //        case "JMP": return (int)Commands.Jump;
        //        case "LTN": return (int)Commands.LessThan;
        //        case "EQL": return (int)Commands.Equals;
        //        case "TER": return (int)Commands.Terminate;
        //    }

        //    throw new Exception("Invalid command");
        //}

        public void Step()
        {
            if (_instructionPointer >= _program.Length) return;

            if (Enum.IsDefined(typeof(Commands), _program[_instructionPointer].Value))
            {
                var command = (Commands) _program[_instructionPointer].Value;
                switch (command)
                {
                    case Commands.Unknown:
                        throw new Exception("Invalid Command");
                    case Commands.Add:
                        break;
                    case Commands.Multiply:
                        break;
                    //case Commands.Input:
                    //    break;
                    //case Commands.Output:
                    //{
                    //    var dest = _program[_instructionPointer + 1];
                    //    var valParam = _program[_instructionPointer + 2];
                    //    var val = GetValue(valParam);
                    //    SetValue(dest, val);
                    //    _instructionPointer += 3;
                    //}
                    //break;
                    case Commands.Copy:
                        {
                            var dest = _program[_instructionPointer + 2];
                            var valParam = _program[_instructionPointer + 1];
                            var val = GetValue(valParam);
                            SetValue(dest, val);
                            _instructionPointer += 3;
                        }
                        break;
                    case Commands.JumpIfTrue:
                        break;
                    case Commands.JumpIfFalse:
                        break;
                    case Commands.Jump:
                    {
                        var valParam = _program[_instructionPointer + 1];
                        var val = GetValue(valParam);
                        _instructionPointer = val;
                    }
                        break;
                    case Commands.LessThan:
                        break;
                    case Commands.Equals:
                        break;
                    case Commands.Terminate:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void SetValue(CodeValue dest, int val)
        {
            if (dest.Type == NodeType.Command) throw new Exception("Cannot set value to command");

            if (dest.Type == NodeType.Register)
            {
                switch (dest.RegisterType)
                {
                    case RegisterType.Input:
                        _inputRegisters[dest.Value] = val;
                        break;
                    case RegisterType.Output:
                        _outputRegisters[dest.Value] = val;
                        break;
                }
            }
        }

        private int GetValue(CodeValue source)
        { 
            if (source.Type == NodeType.Command) throw new Exception("Cannot get value from command");
            if (source.Type == NodeType.Value) return source.Value;

            if (source.Type == NodeType.Register)
            {
                switch (source.RegisterType)
                {
                    case RegisterType.Input:
                        return _inputRegisters[source.Value];
                    case RegisterType.Output:
                        return _outputRegisters[source.Value];
                }
            }

            return 0;
        }
    }
}
