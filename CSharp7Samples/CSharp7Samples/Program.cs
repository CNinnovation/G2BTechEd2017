using CSharp7Samples;
using System;

class Program
{
    static void Main(string[] args)
    {
        // BinaryLiteralsAndDigitSeparators();
        // RefLocalAndRefReturn();
        // OutVars();
        // LocalFunctions();
        // LambdaExpressionsEverywhere();
        // PatternMatching();
        TuplesAndDeconstruction();
    }

    private static void BinaryLiteralsAndDigitSeparators()
    {
        Console.WriteLine(nameof(BinaryLiteralsAndDigitSeparators));
        int b1 = 0b0101010101111;
        Console.WriteLine($"{b1:X}");
        int b2 = 0b1111_0000_1111_0101;

        Console.WriteLine($"{b2:X}");

        int i1 = 987_132_45;
        Console.WriteLine(i1);
        Console.WriteLine();
    }

    private static void RefLocalAndRefReturn()
    {
        Console.WriteLine(nameof(RefLocalAndRefReturn));

        int[] arr1 = { 1, 2, 3, 4, 5 };
        ref int x = ref GetElement(arr1, 2);
        Console.WriteLine(x);
        x = 42;
        Console.WriteLine(arr1[2]);

        Console.WriteLine();
    }

    public static ref int GetElement(int[] arr, int ix)
    {
        ref int a = ref arr[ix];
        return ref a;
    }


    private static void OutVars()
    {
        Console.WriteLine(nameof(OutVars));
        Console.WriteLine("enter a number:");
        string input = Console.ReadLine();

        bool success = int.TryParse(input, out int result);
        if (success)
        {
            Console.WriteLine($"this number: {result}");
        }
        else
        {
            Console.WriteLine("NaN");
        }
        Console.WriteLine();
    }

    private static void LocalFunctions()
    {
        Console.WriteLine(nameof(LocalFunctions));
        int z = 3;

        int Foo(int x, int y) => x + y + z;
        //{
        //    return x + y + z;
        //}

        int result = Foo(1, 2);
        Console.WriteLine(result);

        Console.WriteLine();
    }

    private static void LambdaExpressionsEverywhere()
    {
        Console.WriteLine(nameof(LambdaExpressionsEverywhere));
        var p1 = new Person("Katharina Nagel");
        Console.WriteLine($"{p1.FirstName} {p1.LastName}");

        Console.WriteLine();
    }

    private static void TuplesAndDeconstruction()
    {
        Console.WriteLine(nameof(TuplesAndDeconstruction));
        (var s, var i) = ("magic", 42);
        Console.WriteLine(s);
        Console.WriteLine(i);

        var t = Divide(7, 2);
        Console.WriteLine($"{t.Result} {t.Reminder}");

        var oldtuple = t.ToTuple();
      

        (var res, var rem) = Divide(7, 2);
        Console.WriteLine(res);

        Person p1 = new Person("Katharina Nagel");
        p1.Age = 0;
        (string first, string last, int age) = p1;
        Console.WriteLine($"{first} {last}");


        Console.WriteLine();
    }

    public static (int Result, int Reminder) Divide(int x, int y)
    {
        int res = x / y;
        int rem = x % y;
        return (res, rem);
    }



    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));
        object[] data = { null, 5, 42, "astring", new Person("Stephanie Nagel") };
        foreach (var d in data)
        {
            IsPattern(d);
        }
        Console.WriteLine();
        foreach (var d in data)
        {
            SwitchPattern(d);
        }

        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {
        if (o is null) Console.WriteLine("it's null");  // constant pattern
        if (o is int i1) Console.WriteLine($"it'S an int with the value {i1}");  // type pattern
        if (o is Person p) Console.WriteLine($"it's a person {p.FirstName} {p.LastName}");
        if (o is var x) Console.WriteLine($"it's a var of type {x?.GetType().Name}");  // var pattern
    }

    public static void SwitchPattern(object o)
    {
        switch (o)
        {
            case null:
                Console.WriteLine("it's null");
                break;
            case int i1 when (i1 < 20):
                Console.WriteLine($"it's an int {i1} with a smaller value");
                break;
            case int i2:
                Console.WriteLine($"it's an int {i2}");
                break;
            case Person p when p.FirstName.StartsWith("Steph"):
                Console.WriteLine("person p starting with Steph");
                break;
            case var v1:
                Console.WriteLine("var pattern");
                break;
            default:
                break;
        }
    }
}