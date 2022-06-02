using OtusHomework;

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

            while (true)
            {
                try
                {
                    userInput = Console.ReadLine();

                    if (string.Equals(userInput, StopWord))
                    {
                        break;
                    }

                    var parts = userInput.Split(Separator);

                    if (parts.Length != 3 || allowedOperators.Contains(parts[0][0]) || allowedOperators.Contains(parts[2][0]))
                    {
                        throw new FormatException();
                    }

                    var firstOperand = ParseToInt(parts[0]);
                    var secondOperand = ParseToInt(parts[2]);
                    var operatorSign = parts[1][0];

                    if (char.IsLetterOrDigit(operatorSign))
                    {
                        throw new MissedOperatorException();
                    }

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
                            throw new UnsupportedOperatorException(operatorSign.ToString());
                    }
                }
                catch (MissedOperatorException)
                {
                    Console.WriteLine("Укажите в выражении оператор: +, -, *, /");
                }
                catch (UnsupportedOperatorException e)
                {
                    Console.WriteLine($"Я пока не умею работать с оператором {e.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Выражение некорректное, попробуйте написать в формате\n" +
                                        $"a + b\n" +
                                        $"a * b\n" +
                                        $"a - b\n" +
                                        $"a / b");
                }
                catch (OperandNotIntNumberException e)
                {
                    Console.WriteLine($"Операнд {e.Message} не является числом");
                }
                catch (Exception)
                {

                    throw;
                }


            }
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

        private static int ParseToInt(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                throw new OperandNotIntNumberException(input);
            }
        }
    }
}