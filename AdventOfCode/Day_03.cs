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
            for(int i = 0; i < num.Length; i++){
                int place_value = Convert.ToInt32(num[i].ToString());
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
        int[] o2Gen = StringToIntArray(CalcO2GenRating());
        int[] cO2Scrub = StringToIntArray(CalcCO2ScrubRating());
        int resultOxygen = BinaryArrayToInt(o2Gen);
        int resultCO2 = BinaryArrayToInt(cO2Scrub);
        int result = resultOxygen * resultCO2;
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
    
    private string CalcO2GenRating(){
        List<string> remaining = _input.ToList();
        for(int place = 0; place < _input[0].Length; place++){
            if(remaining.Count() == 1){
                break;
            }
            int frequency = 0;
            foreach(string option in remaining){
                if(option[place] == '0'){
                    frequency--;
                    continue;
                }
                frequency++;
            }
            if(frequency >= 0){
                remaining = remaining.Where(x => x[place] == '0').ToList();
                continue;
            }
            remaining = remaining.Where(x => x[place] == '1').ToList();
        }
        return remaining[0];
    }

    private string CalcCO2ScrubRating(){
        List<string> remaining = _input.ToList();
        for(int place = 0; place < _input[0].Length; place++){
            if(remaining.Count() == 1){
                break;
            }
            int frequency = 0;
            foreach(string option in remaining){
                if(option[place] == '0'){
                    frequency--;
                    continue;
                }
                frequency++;
            }
            if(frequency >= 0){
                remaining = remaining.Where(x => x[place] == '1').ToList();
                continue;
            }
            remaining = remaining.Where(x => x[place] == '0').ToList();
        }
        return remaining[0];
    }
    private int[] StringToIntArray(string inputString){
        int[] intArray = inputString.Select(n => Int32.Parse(n.ToString())).ToArray();
        return intArray;
    }
}
