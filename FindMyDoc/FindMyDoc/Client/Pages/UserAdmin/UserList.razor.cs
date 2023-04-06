using FindMyDoc.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FindMyDoc.Client.Pages.UserAdmin;

    public partial class UserList
{
    [Inject]
    HttpClient Http { get; set; } = new();
    private List<UserAuthDto> users = new();

    protected override async Task OnInitializedAsync()
    {
        users = await Http.GetFromJsonAsync<List<UserAuthDto>>("api/admin");
    }
}
    

