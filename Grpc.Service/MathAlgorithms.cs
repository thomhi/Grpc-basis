namespace Grpc.Service;

public class MathAlgorithms
{
    public IEnumerable<int> GetFibonacci()
    {
        var prev = 0;
        var curr = 1;
        while (true)
        {
            (prev, curr) = (curr, prev + curr);
            yield return curr;
        }
    }
}
