# Experimentation around serilog

The idea behind this repo is to check out serilog handles multiple kind of logger.  
Being able to push log to several ElasticSearch index.  
Defined Logger has their own "mapper" to extract of fillin specific value like `StatusCode` / `Delay` / `CorrelationId`

## Classic log for Technical log
Frequent call on `ILogger<T>` will use this pre-made appender
### Setup a specific eventMapper for Serilog to ElasticSearch

## User log
The idea is to log Attempt of log in a specific Elastic index with the `Ok` / `Ko` and username that attempted to login

### Incomming traffic
This will probably use a `middleware`

## Log in / out
Article used a reference for detailed Auth Step :  
https://digitalmccullough.com/posts/aspnetcore-auth-system-demystified.html  
https://andrewlock.net/introduction-to-authentication-with-asp-net-core/  

Beeing able to log `StatusCode` `Timeout` `Delay` `headers ....`

### Outgoing traffic
This will probably use `HttpClientHandler`

### Incomming traffic
This will probably use a `middleware`