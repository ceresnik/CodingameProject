using System;

namespace CodingameProject.Source.LogicalOperations
{
    public class LogicalOperation
    {
        private readonly string basicOperand;
        public string Result => basicOperand;


        public LogicalOperation(string basicOperand)
        {
            if (string.IsNullOrEmpty(basicOperand))
            {
                throw new ArgumentNullException();
            }
            this.basicOperand = basicOperand;
        }

        public LogicalOperation Or(string operand)
        {
            DoSanityCheck(operand);
            string result = "";
            for (int i = 0; i < basicOperand.Length; i++)
            {
                result += basicOperand[i] - '0' + operand[i] - '0' > 0 ? "1" : "0";
            }
            return new LogicalOperation(result);
        }

        public LogicalOperation And(string operand)
        {
            DoSanityCheck(operand);
            string result = "";
            for (int i = 0; i < basicOperand.Length; i++)
            {
                result += basicOperand[i] - '0' + operand[i] - '0' > 1 ? "1" : "0";
            }
            return new LogicalOperation(result);
        }

        private void DoSanityCheck(string operand)
        {
            if (string.IsNullOrEmpty(operand))
            {
                throw new ArgumentNullException();
            }
            if (basicOperand.Length != operand.Length)
            {
                throw new ArgumentException();
            }
        }
    }
}