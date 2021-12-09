# The project for use [Dbrain.io](https://dbrain.io/) Api and [Handl.ai](https://handl.ai/).

For install use the [nuget package](https://www.nuget.org/packages/DbrainApi) .
```
dotnet add package DbrainApi
```
Basic methods
- classify
- recognize
- result

For example:
```
void Execute()
{
    Console.WriteLine("Write token:");
    var token = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(token)) 
        return;

    Console.WriteLine("Write path to file:");
    var path = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(path)) 
        return;
    if (!File.Exists(path)) 
        return;

    var content = File.ReadAllBytes(path);
    var json = new DbrainApi.DbrainApi(token).Classify(content);

    Console.WriteLine(json);
}
```
