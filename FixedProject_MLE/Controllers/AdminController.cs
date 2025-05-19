[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> PendingApprovals()
    {
        var pendingUsers = await _userManager.Users
            .Where(u => !u.IsApproved)
            .ToListAsync();

        return View(pendingUsers);
    }

    [HttpPost]
    public async Task<IActionResult> ApproveUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            user.IsApproved = true;
            await _userManager.UpdateAsync(user);

            // Send approval email (implement this)
            // await _emailService.SendApprovalNotification(user);
        }

        return RedirectToAction("PendingApprovals");
    }

    [HttpPost]
    public async Task<IActionResult> RejectUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            // Send rejection email (implement this)
            // await _emailService.SendRejectionNotification(user);

            await _userManager.DeleteAsync(user);
        }

        return RedirectToAction("PendingApprovals");
    }
}
