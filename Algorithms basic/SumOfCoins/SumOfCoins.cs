using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        coins = coins
            .OrderByDescending(c => c)
            .ToList();

        Dictionary<int, int> result = new Dictionary<int, int>();

        int index = 0;

        while (targetSum > 0 && index < coins.Count)
        {
            int pieceOfCoin = targetSum / coins[index];
            targetSum -= pieceOfCoin * coins[index];
            if (pieceOfCoin > 0)
            {
                result.Add(coins[index], pieceOfCoin);

            }
            coins.RemoveAt(0);
        }

        return result;
    }
}