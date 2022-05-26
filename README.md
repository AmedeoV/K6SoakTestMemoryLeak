# Soak Testing with K6

## What is Soak Testing
A soak test it's like a load test that runs for an extended period.

## Why is useful
Typically with a normal load test, we send a bunch of requests for a short period and monitor how the platform performs. While this may be useful for most scenarios, the typical load test might miss some issues that would come up only when the system is stressed for a _long_ period. For example, during a major event, we might have a big amount of clients using our platform for hours and this might surface any problems related to memory leaks, logs filling up the disk space and so on...

## Example of Web API with a memory leak
<!-- This API with a memory leak is taken from Microsoft Diagnostic examples... -->
- Run load test for a short period returns 200 and we think that it's all good
![LoadTest](/Resources/LoadTestGif.gif)
- Show that by hitting the endpoint the GC Heap Size (MB) increases
![GCHeapSize](/Resources/GCHeapSize.gif)
- Runs Soak Test
![GCHeapSize](/Resources/SoakTestVideo.gif)
- Show errors

```C#
{
  fail: Microsoft.AspNetCore.Server.Kestrel[13]

      Connection id "0HMHUTUB1JJR6", Request id "0HMHUTUB1JJR6:00000003": An unhandled exception was thrown by the application.

      System.OutOfMemoryException: Exception of type 'System.OutOfMemoryException' was thrown.

         at System.Collections.Generic.List`1.set_Capacity(Int32 value)

         at System.Collections.Generic.List`1.AddWithResize(T item)

         at MemoryLeakApi.Controllers.MemoryLeakController.memleak(Int32 kb) in /src/Controllers/MemoryLeakController.cs:line 18

         at lambda_method1(Closure , Object , Object[] )

         at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.SyncObjectResultExecutor.Execute(IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)

         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()

         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)

         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeNextActionFilterAsync()

      --- End of stack trace from previous location ---

         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)

         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)

         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()

      --- End of stack trace from previous location ---

         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)

         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)

         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)

         at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)

         at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)

         at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
}
```

### Observations
Show the results, some are returning 200, but most are failing

## Conclusion
We just show how soak testing an application is useful
