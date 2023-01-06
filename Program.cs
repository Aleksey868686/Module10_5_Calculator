namespace Module10_5_Calculator;

internal class Program
{
    static ILogger Logger { get; set; }

    static void Main(string[] args)
    {
        Logger = new Logger();
        float number1 = GetNumber("Введите первое число: ");
        float number2 = GetNumber("Введите второе число: ");
        var calc = new Calculator();
        var sum = GetSum(calc, number1, number2);
        Console.WriteLine($"{number1} + {number2} = {sum}");
        Console.Write("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    public static float GetNumber(string message)
    {

        Console.WriteLine(message);
        Logger.Event("Событие перед вводом числа.");
        bool isValid = false;
        while (!isValid)
        {
            try
            {
                string input = Console.ReadLine();
                isValid = float.TryParse(input, out float number);
                if (isValid)
                    return number;
                throw new FormatException("Введите валидное число");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Error("Ошибка ввода.");
            }
        }
        return -1;
    }

    public static float GetSum(ISum calculator, float num1, float num2)
    {
        Logger.Event("Событие перед суммироваем двух чисел.");
        return calculator.Add(num1, num2);
    }
}