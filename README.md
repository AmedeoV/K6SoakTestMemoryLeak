# Soak Testing with K6

## What is Soak Testing
A soak test it's like a load test that runs for an extended period.

## Why is useful
Typically with a normal load test, we send a bunch of requests for a short period and monitor how the platform performs. While this may be useful for most scenarios, the typical load test might miss some issues that would come up only when the system is stressed for a _long_ period. For example, during a major event, we might have a big amount of clients using our platform for hours and this might surface any problems related to memory leaks, logs filling up the disk space and so on...

## Example of Web API with a memory leak
<!-- This API with a memory leak is taken from Microsoft Diagnostic examples... -->
- Run load test for a short period returns 200 and we think that it's all good
![LoadTest](https://github.com/AmedeoV/K6SoakTestMemoryLeak/blob/main/Resources/LoadTestGif.gif)
- Show that by hitting the endpoint the GC Heap Size (MB) increases
- Runs Soak Test

### Observations
Show the results, some are returning 200, but most are failing

## Conclusion
We just show how soak testing an application is useful
