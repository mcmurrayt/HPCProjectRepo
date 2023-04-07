using FindMyDoc.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FindMyDoc.Client.Pages.UserAdmin;

    public partial class UserList
{
    [Inject]
    NavigationManager navigationManager { get; set; }
    [Inject]
    HttpClient Http { get; set; } = new();
    private List<UserAuthDto> users = new();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var response = await Http.GetFromJsonAsync<List<UserAuthDto>>("api/admin-get/");
            if(response != null)
            {
                users = response;
            }
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    private async Task DeleteUser(string userId)
    {
        try
        {
            await Http.DeleteAsync($"api/delete-user/{userId}");
            users = await Http.GetFromJsonAsync<List<UserAuthDto>>("api/admin-get/");
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private async Task UpdateUser(string userId)
    {
        try
        {
            navigationManager.NavigateTo($"/EditUser/{userId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
    

