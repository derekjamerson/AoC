namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string _input;

    public Day_01()
    {
        List<string> _input = new List<string>(File.ReadAllLines(InputFilePath));
    }

    public override ValueTask<string> Solve_1()
    {
        return new("asdf");
    }

    public override ValueTask<string> Solve_2() => new($"asdfa");
}
