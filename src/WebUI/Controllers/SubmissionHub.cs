using Microsoft.AspNetCore.SignalR;
using OpenExam.Infrastructure.Persistence;

namespace OpenExam.WebUI.Controllers;

// [Authorize]
public class SubmissionHub: Hub
{
    private ApplicationDbContext _context;
    
    private ILogger _logger;
    private IHubContext<SubmissionHub> _hub;
    
    public SubmissionHub(ApplicationDbContext dbContext,
        ILogger<SubmissionHub> logger,
        IHubContext<SubmissionHub> hubContext)
    {
        _context = dbContext;
        _hub = hubContext;
        _logger = logger;
    }
    
    public async Task SendMessage(string submission)
    {
        await Clients.All.SendAsync("ReceiveSubmission", submission);
    }
    
    public override async Task OnConnectedAsync()
    {
        // await _usersService.AddUserAsync(Context.ConnectionId, Context.User.UserName());
        // _logger.LogInformation("User logged in " + Context.UserIdentifier);
        // _logger.LogInformation(Context.User.ToString());

        // var user = await _usersService.GetUserBySubjectAsync(Context.User.Su)
            
            

        //var user = await _userManager.Users.FirstOrDefaultAsync(x =>
        //    x.Id == Context.UserIdentifier
        //);
        _logger.LogInformation("SIGNALR");
        _logger.LogInformation("User connected: " + Context.UserIdentifier);
        
        await _hub.Groups.AddToGroupAsync(Context.ConnectionId,"submissions");
            
            
        await base.OnConnectedAsync();
    }
        
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        try
        {
            _logger.LogInformation("User disconnected: " + Context.UserIdentifier);
            // var subId = Context.UserIdentifier;
            /*var user = await _userManager.Users.FirstOrDefaultAsync(x =>
                x.Id == Context.UserIdentifier
            );*/

            await _hub.Groups.RemoveFromGroupAsync(Context.ConnectionId, "submissions");
            // await _usersService.RemoveUserAsync(subId);
            // var user = await _context.MonitorUsers.FirstOrDefaultAsync(x => x.Id == subId);
            // _context.MonitorUsers.Remove(user);
            // await _context.SaveChangesAsync();
                
            await base.OnDisconnectedAsync(exception);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Delete user failed. Error: {e.Message}");
        }
    }
        

    /* public async Task PlayRound(int data)
    {
        
        
        Console.WriteLine(
            $"PlayRound: User {Context.User.UserName()}; ConnectionId: {Context.ConnectionId} Wert {data}");
        await _manager.PlayRoundAsync(Context.ConnectionId, data);
    }*/
}