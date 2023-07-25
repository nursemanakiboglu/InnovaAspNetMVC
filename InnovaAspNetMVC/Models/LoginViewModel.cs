using Microsoft.AspNetCore.Mvc.Rendering;

namespace InnovaAspNetMVC.Models;

public class LoginViewModel
{
	public LoginViewModelFormData FormData { get; set; }

	public LoginViewModelData Data { get; set; } = new();

}

public class LoginViewModelFormData
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
	public int Country { get; set; }
	public bool RememberMe { get; set; }
	public int Gender { get; set; }
}

public class LoginViewModelData
{

	public SelectList CountryMenu { get; set; } = null!;

	public List<GenderViewModel> GenderMenu { get; set; } = new();





}