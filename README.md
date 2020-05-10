# Net Standard Logger
Logger implementation for Net Standard libraries

### Console Logger
Use the `ConsoleLogger` to log to the console

### Event Viewer Logger
Use the `EventViewerLogger` to log to the Windows Event Viewer

### File Logger
Use the `FileLogger` to log to a file

## Log Levels
### LogLevel.Debug
Most verbose logging 
```
Includes all Trace, Information, Warning, Error logs
```
### LogLevel.Trace
Mildly verbose logging
```
Includes all Information, Warning, Error logs
```
### LogLevel.Information
Information logging
```
Includes all Warning, Error logs
```
### LogLevel.Warning
Warning logs
```
Includes all Error logs
```
### LogLevel.Error
Errors only