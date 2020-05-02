#pragma checksum "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\Chat.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ad7e5e1fa70acccda2a579e567f0cb1a9f9fc22"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazingChat.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using BlazingChat.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using BlazingChat.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using BlazorPro.Spinkit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\Chat.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\Chat.razor"
using BlazingChat.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\Chat.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\Chat.razor"
using BlazingChat.Shared.ViewModels;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chat")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/chat/{id}")]
    public partial class Chat : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 65 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\Chat.razor"
       
    
    [Parameter]
    public string id { get; set; }
    private HubConnection _hubConnection;
    private List<string> _messages = new List<string>();
    private List<MessagePack> messagePacks = new List<MessagePack>();
    public bool IsConnected;
    public bool IsEnterPressed;
    [CascadingParameter]
    public Task<AuthenticationState> authenticationStateTask { get; set; }
    public System.Security.Claims.ClaimsPrincipal user { get; set; }
    private ChatViewModel _chatViewModel = new ChatViewModel();

    protected override async Task OnInitializedAsync()
    {       
        
        user = (await authenticationStateTask).User;

        if(!user.Identity.IsAuthenticated)
            NavigationManager.NavigateTo("/");

        _hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/chatHub"))
            .Build();

        _hubConnection.On<MessagePack>("ReceiveMessage", (messagePack) =>
        {
            messagePacks.Add(messagePack);

            StateHasChanged();
        });


        await _hubConnection.StartAsync();

        if(_hubConnection.State == HubConnectionState.Connected)
            IsConnected = true;
    
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync("setScroll");
    }

    public async Task OnKeyDownEvent(KeyboardEventArgs eventArgs)
    {        
        if(eventArgs.Key == "Enter")
        {
            string messsageToBeSent = await JSRuntime.InvokeAsync<string>("getMessageInput");
            await Send(messsageToBeSent);     
        }
    }

    public async Task Send(string message)
    {
        if(message != null && message.Length > 0)
        {
            MessagePack messagePack = new MessagePack();
            messagePack.UserName = id;
            messagePack.Message = message;

            await _hubConnection.SendAsync("SendMessage", messagePack);
        }            
    }

    public async Task OnKeyDownEventChat(KeyboardEventArgs eventArgs)
    {        
        if(eventArgs.Key == "Enter")
        {
            string messsageToBeSent = await JSRuntime.InvokeAsync<string>("getMessageInput");
            await Send(messsageToBeSent);                     
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
