namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly List<string> _input;

    public Day_01()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int result = 0;
        int prev_d = -1;
        foreach(string depth in _input){
            int current = Int32.Parse(depth);
            if(prev_d == -1){
                prev_d = current;
                continue;
            }
            if(current > prev_d){
                result++;
            }
            prev_d = current;
        }

        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int result = 0;
        int prev = -1;
        for(int i = 0; i < _input.Count; i++){
            int current = ConvertToInt(i);
            int plusOne = ConvertToInt(i+1);
            int plusTwo = ConvertToInt(i+2);
            int cTotal = current + plusOne + plusTwo;
            if(prev == -1){
                prev = cTotal;
                continue;
            }
            if(cTotal > prev){
                result++;
            }
            prev = cTotal;
        }
        return new(result.ToString());
    }
    
    private int ConvertToInt(int num){
        try{
            return Int32.Parse(_input[num]);
        }
        catch(Exception){
            return 0;
        }
    }
}
