# Net Standard Logger
[![Build Status](https://dev.azure.com/kbrashears5/github/_apis/build/status/kbrashears5.net-standard-logger?branchName=master)](https://dev.azure.com/kbrashears5/github/_build/latest?definitionId=5&branchName=master)

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