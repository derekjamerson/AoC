namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly List<string> _input;

    public Day_02()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int horizontal = 0;
        int depth = 0;
        foreach(string instruction in _input){
            string[] split = instruction.Split(" ");
            string direction = split[0];
            int value = Int32.Parse(split[1]);
            if(direction == "forward"){
                horizontal += value;
                continue;
            }
            if(direction == "up"){
                value *= -1;
            }
            depth += value;
        }
        int result = depth * horizontal;

        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int horizontal = 0;
        int depth = 0;
        int aim = 0;
        foreach(string instruction in _input){
            string[] split = instruction.Split(" ");
            string direction = split[0];
            int value = Int32.Parse(split[1]);
            if(direction == "forward"){
                horizontal += value;
                depth += value * aim;
                continue;
            }
            if(direction == "up"){
                value *= -1;
            }
            aim += value;
        }
        int result = depth * horizontal;

        return new(result.ToString());
    }
    
}
