[Authorize] // Only logged in and approved users can access
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "Admin")] // Only admins can access
    public IActionResult AdminPanel()
    {
        return View();
    }
}
