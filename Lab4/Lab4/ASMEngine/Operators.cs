using ASMEngine.OperatorsLib;

namespace ASMEngine
{
    public class Operators
    {
        public static List<Operator> DataBase = InitDataBase();
        private static List<Operator> InitDataBase()
        {
            List<Operator> res = new()
            {
                new ADDOperator(),
                new SUBOperator(),
                new INCOperator(),
                new DECOperator(),
                new CMPOperator(),
                new NEGOperator(),
                new MULOperator(),
                new IMULOperator(),
                new DIVOperator(),
                new IDIVOperator(),
                new CBWOperator(),
                new INTOperator(),
                new MOVOperator(),
                new LEAOperator(),
                new PUSHOperator(),
                new POPOperator(),
                new XCHGOperator(),
                new LOOPOperator(),
                new JMPOperator(),
                new RETOperator(),
                new JxxOperator(),
                new ANDOperator(),
                new SHLOperator(),
                new SAROperator(),
                new XOROperator(),
                new OROperator(),
                new CLDOperator(),
                new STOSBOperator()
            };
            return res;
        }

        internal static bool IsOperator(string line)
        {
            line = line.ToUpper();
            bool res = false;

            foreach (Operator x in DataBase)
            {
                if (x.TryToCreate(line))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        internal static Operator ParseOperator(string line, AddressTable table, int LineNumber)
        {
            string[] parts = line.Split(new char[2] { ' ', ',' }, 3);
            List<Operand> RegistredOperands = new List<Operand>();
            RegistredOperands.Add(new Register());
            RegistredOperands.Add(new Constant());
            RegistredOperands.Add(new SegmentRegister());
            RegistredOperands.Add(new Address());

            
            foreach (Operator x in DataBase)
            {
                if (x.TryToCreate(parts[0].ToUpper()))
                {
                    if (parts.Length == 1)
                    {
                        return (Operator)Activator.CreateInstance(x.GetType(), new NullOperand(""), new NullOperand(""), LineNumber);
                    }
                    if (parts.Length == 2)
                    {
                        Operand first = null;

                        foreach(Operand y in RegistredOperands)
                        {
                            if (y.TryToCreate(parts[1]))
                            {
                                if (y is Constant)
                                {
                                    first = (Operand)Activator.CreateInstance(y.GetType(), parts[1], 1);
                                }
                                else
                                {
                                    first = (Operand)Activator.CreateInstance(y.GetType(), parts[1]);
                                }
                                break;
                            }
                        }

                        if (first == null)
                        {
                            throw CompileError.WrongOperatorFormat("First operand of one-operand operator is invalid", LineNumber);
                        }
                        return (Operator)Activator.CreateInstance(x.GetType(), first, new NullOperand(""), LineNumber);
                    }
                    if (parts.Length == 3)
                    {
                        Operand first = null;
                        Operand second = null;

                        foreach (Operand y in RegistredOperands)
                        {
                            if (y.TryToCreate(parts[1]))
                            {
                                if (y is Constant)
                                {
                                    first = (Operand)Activator.CreateInstance(y.GetType(), parts[1].ToUpper(), 1);
                                }
                                else
                                {
                                    first = (Operand)Activator.CreateInstance(y.GetType(), parts[1]);
                                }
                                break;
                            }
                        }

                        foreach (Operand y in RegistredOperands)
                        {
                            if (y.TryToCreate(parts[2]))
                            {
                                if (y is Constant)
                                {
                                    if (first.w == "w")
                                    {
                                        first.w = "1";
                                    }
                                    second = (Operand)Activator.CreateInstance(y.GetType(), parts[2], 1 + int.Parse(first.w));
                                }
                                else
                                {
                                    if (y is Register)
                                    {
                                        second = new Register(parts[2], !(first is Register || first is SegmentRegister));
                                    }
                                    else
                                    {
                                        second = (Operand)Activator.CreateInstance(y.GetType(), parts[2]);
                                    }
                                }
                                break;
                            }
                        }

                        if (first == null)
                        {
                            throw CompileError.WrongOperatorFormat("First operand of two-operand operator is invalid", LineNumber);
                        }

                        if (second == null)
                        {
                            throw CompileError.WrongOperatorFormat("Second operand of two-operand operator is invalid", LineNumber);
                        }

                        if (first is Address)
                        {
                            table.Add((first as Address).var);
                        }

                        if (second is Address)
                        {
                            table.Add((second as Address).var);
                        }

                        return (Operator)Activator.CreateInstance(x.GetType(), first, second, LineNumber);
                    }
                }
            }
            throw new CompileError(LineNumber, "No acceptable operator for this line");
        }
    }
}
