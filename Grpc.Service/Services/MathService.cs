using Grpc.Core;
using Grpc.Shared;

namespace Grpc.Service.Services;

public class MathService(MathAlgorithms math) : Shared.Math.MathBase
{
    private readonly MathAlgorithms math = math;

    public override async  Task GetFibonacci(FromTo request, IServerStreamWriter<NumericResult> responseStream, ServerCallContext context)
    {
        if (request.From > request.To)
        {
            context.Status = new Status(StatusCode.InvalidArgument, "'From' must be greatet than 'To'");
            return;
        }

        foreach (var current in math.GetFibonacci())
        {
            if (current < request.From)
            {
                continue;
            }
            else if (current <= request.To)
            {
                await responseStream.WriteAsync(new NumericResult { Result = current });

                await Task.Delay(500);
            }
            else
            {
                break;
            }
        }
    }
}
