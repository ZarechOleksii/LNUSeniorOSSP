namespace ASMEngine
{
    public class AddressTable
    {
        private Dictionary<string, int> data;

        public Dictionary<string, int> Data
        {
            get { return data; }
        }
        public AddressTable()
        {
            data = new();
        }

        public void Add(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.ToUpper();

                data.TryAdd(name, -1);
            }
        }
        public void Set(string name, int offset)
        {
            if (!data.ContainsKey(name.ToUpper()))
            {
                throw CompileError.VariableNotDefined(name.ToUpper(), -1);
            }

            data[name] = offset;
        }
        public string GetOffset(string name, int offset, int bytes)
        {
            if(data.TryGetValue(name.ToUpper(), out int q))
            {
                return Convertors.DecimalToBase(Convertors.TryNegative(q + offset, bytes), 2);
            }
            else
            {
                throw CompileError.VariableNotDefined(name.ToUpper(), -1);
            }
        }
    }
     
}
