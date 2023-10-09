# En este Taller Les dare lo básico para lograr la creación de una aplicación de chat funcional en tiempo real con SignalR, rapido efectivo y desde 0.

1. Bien teniendo en cuenta que ya tienen instalado todo lo que nesecitan, como se muestra en las guias del profesor.
vamos a añadir a un proyecto existente o a iniciar un proyecto, nuevo abriendo la carpeta del proyecto con vs code..

2. En la terminal introducir el siguiente comando:

`dotnet new webapp -o SignalRChat code -r SignalRChat`

Seleccione Sí, en todas las ventanas que aparescan con esa opcion (dentro de vs code claro!)


3. Ahora vamos a intstalar la siguiente libreria ( LibMan ), primero desinstala si existen verciones anteriores y luego instala su ultima vercion. En la terminal introducir el siguiente comando:

`dotnet tool uninstall -g Microsoft.Web.LibraryManager.Cli dotnet tool install -g Microsoft.Web.LibraryManager.Cli`


4. Vayan a la carpeta de proyecto, que contiene el archivo SignalRChat.csproj. (recuerden es con cd ./tap..tap..tap)
Ejecuten el siguiente comando para obtener la biblioteca cliente de SignalR con LibMan (se demora un poco, reemplazar el 💫 por una arroba).

`libman install 💫microsoft/signalr@latest -p unpkg -d wwwroot/js/signalr --files dist/browser/signalr.js`


5. En la carpeta del proyecto SignalRChat, cree una carpeta Hubs, en la nueva carpeta Hubs, cree la clase ChatHub con el código siguiente:

```dotnet
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
```

6. El servidor de SignalR debe estar configurado para pasar solicitudes de SignalR a SignalR. Agreguen el siguiente código al archivo Program.cs, el código agrega SignalR a los sistemas de inserción de dependencias y enrutamiento de ASP.NET Core.

```dotnet
using SignalRChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.Run();

7. Reemplace el contenido de Pages/Index.cshtml por el código siguiente:

@page
<div class="container">
    <div class="row p-1">
        <div class="col-1">User</div>
        <div class="col-5"><input type="text" id="userInput" /></div>
    </div>
    <div class="row p-1">
        <div class="col-1">Message</div>
        <div class="col-5"><input type="text" class="w-100" id="messageInput" /></div>
    </div>
    <div class="row p-1">
        <div class="col-6 text-end">
            <input type="button" id="sendButton" value="Send Message" />
        </div>
    </div>
    <div class="row p-1">
        <div class="col-6">
            <hr />
        </div>
    </div>
    <div class="row p-1">
        <div class="col-6">
            <ul id="messagesList"></ul>
        </div>
    </div>
</div>
<script src="~/js/signalr/dist/browser/signalr.js"></script>
<script src="~/js/chat.js"></script>
```

Dentro de la capeta "Pages" estan los archivos .cshtml que pueden ser modificados como cualquier front usar boostrap etc.. en wwwroot/css esta el archivo de estilos.


8. En la carpeta wwwroot/js, cree un archivo chat.js con el código siguiente:

```dotnet
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
```

Esto agrega la logica basica de nuestros input y boton de chat


9. 🎈🎉 Terminamos!🎉🎈 hora de probarlo. Pulsa CTRL+F5 para ejecutar la aplicación sin depurar, copia la url y abre mas paginas no importa si es en otro navegador y al enviar mensajes los veran en tiempo real como en una conversacion


10. Bien en caso de ya tener un proyecto creado con ( dotnet new sln ) les doy una posible solucion, escribe en la terminal el siguiente comando:

`dotnet sln add Ruta/Al/Proyecto/SignalRChat.csproj`

Ajusta la ruta segun sea tu caso. Esto se hace por que signalR solo funciona si esta en un ( dotnet new webapp )

Dentro de sus "MiProyectoSignalR," utilicen el comando dotnet add reference para agregar una referencia al proyecto principal:

`dotnet add reference ../MiProyectoPrincipal/MiProyectoPrincipal.csproj`

Esta referencia es para poder importar y usar clases entre proyectos de ser requerido y utilizarlos como uno solo dejo ejemplo:

```dotnet
// En "MiProyectoSignalR"
using MiProyectoPrincipal.DTOs; // Importa el espacio de nombres del proyecto principal

public class ChatHub : Hub
{
    public async Task EnviarMensaje(MensajeDto mensaje)
    {
        // Tu lógica para enviar el mensaje a los clientes
        await Clients.All.SendAsync("RecibirMensaje", mensaje);
    }
}
```

Me disculpo por la posible mala ortografia estoy muerto de sueño al escribir esto ❤
