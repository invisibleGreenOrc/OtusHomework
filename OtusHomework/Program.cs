using OtusHomework;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Calculate();
            }
            catch (Exception e)
            {
                var message = $"В калькуляторе произошла ошибка: {e.Message}";

                Console.WriteLine(message);
            }
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
                    userInput = Console.ReadLine().TrimEnd();

                    if (string.Equals(userInput, StopWord))
                    {
                        break;
                    }

                    var parts = userInput.Split(Separator);

                    if (!IsExpressionInCorrectFormat(parts, allowedOperators))
                    {
                        throw new UnexpectedExpressionFormatException();
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
                    var message = "Укажите в выражении оператор: +, -, *, /";

                    PrintWithColoredBackground(message, ConsoleColor.DarkRed);
                }
                catch (UnsupportedOperatorException e)
                {
                    var message = $"Я пока не умею работать с оператором {e.Message}";

                    PrintWithColoredBackground(message, ConsoleColor.DarkGreen);
                }
                catch (UnexpectedExpressionFormatException)
                {
                    var message = "Выражение некорректное, попробуйте написать в формате\n" +
                                        $"a + b\n" +
                                        $"a * b\n" +
                                        $"a - b\n" +
                                        $"a / b";

                    PrintWithColoredBackground(message, ConsoleColor.DarkRed);
                }
                catch (OperandNotIntegerException e)
                {
                    var message = $"Операнд {e.Data["IncorrectOperand"]} не является числом";

                    PrintWithColoredBackground(message, ConsoleColor.DarkRed);
                }
                catch (DivideByZeroException)
                {
                    var message = "Деление на ноль";

                    PrintWithColoredBackground(message, ConsoleColor.DarkMagenta);
                }
                catch (SpecialResultException e)
                {
                    var message = $"Вы получили ответ {e.Data["SpecialResult"]}!";

                    PrintWithColoredBackground(message, ConsoleColor.DarkGreen);
                }
                catch (OverflowException)
                {
                    var message = "Результат выражения вышел за границы int";

                    PrintWithColoredBackground(message, ConsoleColor.DarkBlue);
                }
                catch (Exception)
                {
                    //var message = "Я не смог обработать ошибку";

                    //Console.WriteLine(message);
                    //break;

                    throw;
                }
            }
        }

        private static void Sum(int a, int b)
        {
            var result = a + b;
            Console.WriteLine($"Ответ: {result}");

            ThrowExceptionForSpeciaResult(13, result);
        }

        private static void Sub(int a, int b)
        {
            var result = a - b;
            Console.WriteLine($"Ответ: {result}");

            ThrowExceptionForSpeciaResult(13, result);
        }

        private static void Mul(int a, int b)
        {
            var result = a * b;
            Console.WriteLine($"Ответ: {result}");

            ThrowExceptionForSpeciaResult(13, result);
        }

        private static void Div(int a, int b)
        {
            if (b != 0)
            {
                var result = a / b;
                Console.WriteLine($"Ответ: {result}");

                ThrowExceptionForSpeciaResult(13, result);
            }
            else
            {
                throw new DivideByZeroException();
            }
        }

        private static int ParseToInt(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                var e = new OperandNotIntegerException();
                e.Data.Add("IncorrectOperand", input);
                throw e;
            }
        }

        private static void PrintWithColoredBackground(string text, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void ThrowExceptionForSpeciaResult(int expectedResult, int result)
        {
            if (expectedResult == result)
            {
                var e = new SpecialResultException();
                e.Data.Add("SpecialResult", expectedResult);
                throw e;
            }
        }

        private static bool IsExpressionInCorrectFormat(string[] expressionParts, char[] allowedOperators)
        {
            var isLengthCorrect = expressionParts.Length == 3;

            var hasCorrectOperator = false;

            if (isLengthCorrect)
            {
                hasCorrectOperator = !allowedOperators.Contains(expressionParts[0][0]) && !allowedOperators.Contains(expressionParts[2][0]);
            }

            return isLengthCorrect && hasCorrectOperator;
        }
    }
}