#pragma checksum "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\LoginPages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7d7e4d869144287e327569d099dc308d8d0b459"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazingChat.Client.Pages.LoginPages
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
#line 3 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\LoginPages\Login.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\LoginPages\Login.razor"
using BlazingChat.Shared.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\LoginPages\Login.razor"
using BlazingChat.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\LoginPages\Login.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(LoginLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 36 "C:\Data\CuriousDrive\Repos\BlazingChat\BlazingChat\Client\Pages\LoginPages\Login.razor"
      
    [CascadingParameter]
    public Task<AuthenticationState> authenticationStateTask { get; set; }
    private LoginViewModel _loginViewModel { get; set; } = new LoginViewModel();

    protected async override Task OnInitializedAsync()
    {
        var user = (await authenticationStateTask).User;

        if (user.Identity.IsAuthenticated)
            NavigationManager.NavigateTo("/profile/" + 0);
    }

    private async Task LoginClick()
    {
        User user = _loginViewModel;

        string serializedUser = JsonConvert.SerializeObject(user);

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "user/login");
        requestMessage.Content = new StringContent(serializedUser);

        requestMessage.Content.Headers.ContentType
            = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        var response = await HttpClient.SendAsync(requestMessage);

        var responseStatusCode = response.StatusCode;
        var responseBody = await response.Content.ReadAsStringAsync();

        user = JsonConvert.DeserializeObject<User>(responseBody);
        
        await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsLoggedIn(user);
        NavigationManager.NavigateTo("/profile");

    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient HttpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
