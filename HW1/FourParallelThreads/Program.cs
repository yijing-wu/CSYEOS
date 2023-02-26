// 1. Write code in any language which will create 4 threads and run them in parallel.

internal class Program {

    public static Object objLock = new Object();

    public static int totalValue = 0;
    
    private static void Main(string[] args) {

        Thread thOne = new Thread(addValue);
        thOne.Name = "ThreadOne";
        thOne.Start(1);

        Thread thTwo = new Thread(addValue);
        thTwo.Name = "ThreadTwo";
        thTwo.Start(1);

        Thread thThree = new Thread(addValue);
        thThree.Name = "ThreadThree";
        thThree.Start(1);

        Thread thFour = new Thread(addValue);
        thFour.Name = "ThreadFour";
        thFour.Start(1);

    }

    static void addValue(Object obj) {
        int value = (int) obj;
        while(true) {
            lock(objLock) {
                Console.WriteLine(Thread.CurrentThread.Name + " add value: " + value);
                Thread.Sleep(200);
                totalValue += value;
                Console.WriteLine("Total Value = " + totalValue);
            }
        } 

    }
}