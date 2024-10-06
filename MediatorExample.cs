using System;

// Посередник
public interface IMediator
{
    void Notify(object sender, string ev);
}

// Конкретний посередник
public class ChatRoom : IMediator
{
    public void Notify(object sender, string ev)
    {
        if (sender is User user)
        {
            Console.WriteLine($"[{user.Name}] повідомлення: {ev}");
        }
    }
}

// Колега
public class User
{
    public string Name { get; }
    private readonly IMediator _mediator;

    public User(string name, IMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void SendMessage(string message)
    {
        _mediator.Notify(this, message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ChatRoom chatRoom = new ChatRoom();

        User user1 = new User("Олексій", chatRoom);
        User user2 = new User("Ірина", chatRoom);

        user1.SendMessage("Привіт, Ірино!");
        user2.SendMessage("Привіт, Олексію!");
    }
}
