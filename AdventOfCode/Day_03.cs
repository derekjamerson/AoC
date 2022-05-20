namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly List<string> _input;

    public Day_03()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int[] frequency = new int[_input[0].Length];
        int[] gammaArray = new int[_input[0].Length];
        int[] epsilonArray = new int[_input[0].Length];

        foreach(string num in _input){
            char[] places = num.ToCharArray();
            for(int i = 0; i < places.Length; i++){
                int place_value = Convert.ToInt32(places[i].ToString());
                if(place_value == 0){
                    frequency[i]--;
                    continue;
                }
                frequency[i]++;
            }
        }
        for(int i = 0; i < frequency.Length; i++){
            int res_val = frequency[i];
            if(res_val > 0){
                gammaArray[i] = 1;
            }
            else{
                epsilonArray[i] = 1;
            }
        }
        int gamma = BinaryArrayToInt(gammaArray);
        int epsilon = BinaryArrayToInt(epsilonArray);
        int result = gamma * epsilon;
        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int result = 0;

        return new(result.ToString());
    }

    public int BinaryArrayToInt(int[] inputArray){
        double result = 0;
        Array.Reverse(inputArray, 0, inputArray.Length);
        for(int i = 0; i < inputArray.Length; i++){
            int value = inputArray[i];
            result += Convert.ToDouble(value) * Math.Pow(2, Convert.ToDouble(i));
        }
        return Convert.ToInt32(result);
    }
    
}
