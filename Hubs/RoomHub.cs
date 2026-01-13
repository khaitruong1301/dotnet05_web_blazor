
using Microsoft.AspNetCore.SignalR;

public class RoomHub : Hub
{
    
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"[SignalR] Connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
        //Gọi hàm phát tín hiệu đưa list room cho toan client
        await getAllRoom();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[SignalR] Disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }

    public async Task getAllRoom ()
    {
        List<string>rooms = new List<string>()
        {
            "Phòng 1",
            "Phòng 2",
            "Phòng 3",
            "Phòng 4",
            "Phòng 5",
        };
        //Phát cho toàn client đã kết nối
        await Clients.All.SendAsync("load_lst_room",rooms);
    }



}



