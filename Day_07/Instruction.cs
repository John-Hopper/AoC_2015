using Utility_Library;

namespace Day_07
{
    public class Instruction
    {
        public string Input1 { get; set; }

        public string Input2 { get; set; }

        public string Output { get; set; }

        public string Operator { get; set; }

        public bool IsComplete { get; set; }


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
