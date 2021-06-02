using Utility_Library;

namespace Day_07
{
    public class Instruction
    {
        private static int _count;

        public int Index { get; set; }

        public string Input1 { get; set; }

        public string Input2 { get; set; }

        public string Output { get; set; }

        public string Operator { get; set; }

        public bool IsComplete { get; set; }

        private int _numberOfInputs;
        public int NumberOfInputs
        {
            get { return _numberOfInputs; }
            set { _numberOfInputs = (Input1.Length+Input2.Length>Input1.Length) ? 2:1; }
        }

        //private bool _input1IsNumeric;
        //public bool Input1Type
        //{
        //    get { return _input1IsNumeric; }
        //    set { _input1IsNumeric = Input1.IsNumeric(); }
        //}

        //private bool _input2Type;
        //public bool Input2Type
        //{
        //    get { return _input2Type; }
        //    set { _input2Type = Input2.IsNumeric(); }
        //}

        public Instruction()
        {
            Index = ++_count;
        }

        public Instruction BuildInstruction(string rawData)
        {
            Instruction instructionToReturn = new Instruction();

            string[] splitRawData = rawData.Split(' ');
            int splitLength = splitRawData.Length;

            switch (splitLength)
            {
                case 5:
                    instructionToReturn.Input1 = splitRawData[0];
                    instructionToReturn.Operator = splitRawData[1];
                    instructionToReturn.Input2 = splitRawData[2];
                    instructionToReturn.Output = splitRawData[4];
                    break;
                case 4:
                    instructionToReturn.Operator = splitRawData[0];
                    instructionToReturn.Input2 = splitRawData[1];
                    instructionToReturn.Output = splitRawData[3];
                    break;
                case 3:
                    instructionToReturn.Input1 = splitRawData[0];
                    instructionToReturn.Output = splitRawData[2];
                    instructionToReturn.Operator = "EQUALS";
                    break;
            }
            return instructionToReturn;
        }
    }


}
