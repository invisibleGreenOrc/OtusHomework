namespace ExceptionHandling
{
    internal class Program
    {
        static void Main()
        {
            Calculate();
        }

        private static void Calculate()
        {
            const string StopWord = "стоп";
            var allowedOperators = new char[] { '+', '-', '*', '/' };
            const char Separator = ' ';

            string userInput;

            do
            {
                userInput = Console.ReadLine();

                try
                {
                    var parts = userInput.Split(Separator);

                    var firstOperand = int.Parse(parts[0]);
                    var secondOperand = int.Parse(parts[2]);
                    var operatorSign = parts[1][0];

                    switch (operatorSign)
                    {
                        case '+':
                            Sum(firstOperand, secondOperand);
                            break;
                        case '-':
                            Sub(firstOperand, secondOperand);
                            break;
                        case '*':
                            Mul(firstOperand, secondOperand);
                            break;
                        case '/':
                            Div(firstOperand, secondOperand);
                            break;
                        default:
                            break;
                    }



                }
                catch (Exception)
                {

                    throw;
                }


            } while (!string.Equals(userInput, StopWord));
        }

        private static void Sum(int a, int b)
        {
            Console.WriteLine($"Ответ: {a + b}");
        }

        private static void Sub(int a, int b)
        {
            Console.WriteLine($"Ответ: {a - b}");
        }

        private static void Mul(int a, int b)
        {
            Console.WriteLine($"Ответ: {a * b}");
        }

        private static void Div(int a, int b)
        {
            Console.WriteLine($"Ответ: {a / b}");
        }
    }
}