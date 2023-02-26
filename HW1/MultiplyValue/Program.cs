// 2. Write code in any language which will write code to 
// Multiply every value in a array with Random value 
// between 0.1 to 0.9 Calculate the sum of the array 
// in parallel and serial and compute the time difference. 
using System.Diagnostics;

internal class Program {

    static double[] values = new double[5000000];
    
    static double[] portionResult = new double[4];
    
    static int portionSize = values.Length/4;

    private static void Main(string[] args) {
        genereateValues();

        Stopwatch watch = new Stopwatch();
        watch.Start();
        double result = 0;
        for (int i = 0; i < values.Length; i++) {
            result += values[i];
        }
        watch.Stop();
        Console.WriteLine("Total Sum = " + result);
        Console.WriteLine("Time elapsed = " + watch.Elapsed);

        watch.Reset();

        watch.Start();
        Thread[] threads = new Thread[4];
        for(int i = 0; i < threads.Length; i++) {
            threads[i] = new Thread(calculateSum);
            threads[i].Start(i);
        }

        for(int i = 0; i < threads.Length; i++) {
            threads[i].Join();
        }

        double sumParallel = 0;
        for(int i = 0; i < portionResult.Length; i++) {
            sumParallel += portionResult[i];
        }
        watch.Stop();
        Console.WriteLine("Total Sum = " + sumParallel);
        Console.WriteLine("Time elapsed = " + watch.Elapsed);

    }

    static void genereateValues() {
        Random rand = new Random();
        for(int i = 0; i < values.Length; i++) {
            // generate values and multuply
            values[i] = rand.NextDouble() * (0.9 - 0.1) + 0.1;
        }
    }

    static void calculateSum(object obj) {
        int portion = (int) obj;
        double sum = 0;
        for(int i = portion * portionSize; i < portion * portionSize + portionSize; i++) {
            sum += values[i];
        }
        portionResult[portion] = sum;
    }

}