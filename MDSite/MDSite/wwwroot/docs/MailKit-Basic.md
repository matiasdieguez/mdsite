# Registro de cuenta de envio de correo en servidor de correo Zoho

Registrarte en https://www.zoho.com/es-xl/mail/?zsrc=fromproduct
Habilitar SMTP en el puerto 587 con TLS

# Agregado de secrets para manejar la cuenta y contraseña del servidor de email

- Ejecutar:

```
dotnet user-secrets init
```

- Agregar al archivo del proyecto .csproj

```
<UserSecretsId>(valor que devuelve el comando anterior)</UserSecretsId>
```

- Agregar valores al archivo de secrets

```
dotnet user-secrets set "Email:Account" "test@zohomail.net"
```

```
dotnet user-secrets set "Email:Password" "your-password"
```

# Instalación de libreria MailKit

Abrir la consola de comandos dentro del directorio de la API

Ejecutar:

```
dotnet add package mailkit --version 3.1.1
```

```
dotnet add package Microsoft.Extensions.Configuration
```

```
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```

# Implementar el envío de emails

Usings necesarios:

```
using System.Security;
using System.Net;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
```

Codigo de referencia para implementar el envío de mail:

```
    var smtpServer = "smtp.zoho.com";
    var mailAddress = _config["Email:Account"];
    var mailPassword = _config["Email:Password"];
    int smtpPort = 587;
    var securityOptions = SecureSocketOptions.StartTls;

    var message = new MimeMessage();
    message.From.Add(new MailboxAddress(mailAddress, mailAddress));
    message.To.Add(MailboxAddress.Parse(Email));
    message.Subject = $"Texto del asunto";
    var body = $"<h1>Titulo</h1><p>{text}</p><p><strong></strong></p>";

    var builder = new BodyBuilder
    {
        HtmlBody = body
    };
    message.Body = builder.ToMessageBody();

    using var client = new SmtpClient();
    client.Connect(smtpServer, smtpPort, securityOptions);

    var securePassword = new SecureString();
    foreach (char item in mailPassword.ToCharArray())
        securePassword.AppendChar(item);

    client.Authenticate(new NetworkCredential(mailAddress, securePassword));
    client.Send(message);
    client.Disconnect(true);

```

