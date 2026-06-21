void arrayPrinter(int[] arr) => Console.WriteLine($"[{String.Join(",", arr)}]");

void Solution(int[] inputArr, int coins)
{
    arrayPrinter(inputArr);
    var freqArr = new int[inputArr.Max() + 1];

    foreach (var inputVal in inputArr)
    {
        freqArr[inputVal] += 1;
    }

    arrayPrinter(freqArr);
    var result = new List<int>();

    for (int idx = 0; idx < freqArr.Length; idx++)
    {
        for (int count = 0; count < freqArr[idx]; count++)
        {
            result.Add(idx);
        }
    }

    arrayPrinter(result.ToArray());
}

// [1,3,2,4,1]
// 7
int coins = 7;
int[] inputArr = [3, 1, 2, 1, 3];
Solution(inputArr, coins);
