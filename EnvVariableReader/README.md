How to use

```csharp
var env1 = new env("env1").Get();
```

or

```csharp
var passwd = new env("PASSWD");
Console.WriteLine(passwd.Display());
if(passwd.IsAvailable)
	Login(user, passwd.Get());
```

For docker, you can use files if you add `_FILE` at the end of env variable

PASSWORD_FILE = /run/secrets/passwordfile

```csharp
var password = new env("PASSWORD").Get();
```


The `Display` function hides by default the value for safety. You need to pass `FullDisplay` is true in parameter. 