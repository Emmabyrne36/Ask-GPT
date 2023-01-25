# AskGPT

Simple console application which utilises the OpenAPI GPT-3 API based on the simple console application found [here](https://www.youtube.com/watch?v=25i-Dh6U6Cw).

An introduction to the OpenApi API can be found [here](https://beta.openai.com/docs/api-reference/introduction).

## Usage Guide

This appliation is run via the console and takes in a question via the command line arguments. This question is then passed to the OpenAPI GPT-3 API.

Eample input:

```txt
dotnet run "How to list running docker containers"
```

Example output:

```txt
--->

To list all running docker containers you can use the docker ps command.
docker ps
```

The command `docker ps` will be copied to the clipboard using the `TextCopy` [package](https://www.nuget.org/packages/TextCopy).
