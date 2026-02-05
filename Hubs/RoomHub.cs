
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;


public class RoomHub : Hub
{
    static List<string> rooms = new List<string>()
    {
            "Phòng 1",
            "Phòng 2",
            "Phòng 3",
            "Phòng 4",
            "Phòng 5",
    };
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"[SignalR] Connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[SignalR] Disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }

    public async Task getAllRoom()
    {

        //Phát cho toàn client đã kết nối
        await Clients.All.SendAsync("load_lst_room", rooms);
    }
    public async Task add_room(string roomName)
    {
        rooms.Add(roomName);
        await Clients.All.SendAsync("load_lst_room", rooms);

        
    }


}



