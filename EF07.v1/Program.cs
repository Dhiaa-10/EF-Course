using EF07.v1.Data;

using (var context = new ApplicationDbContext())
{
    Console.WriteLine("---------- Users ---------");
    Console.WriteLine();
    foreach (var item in context.Users)
    {
        Console.WriteLine($"[{item.UserId}] {item.UserName}");
    }
    Console.WriteLine();
    Console.WriteLine("---------- Tweets ---------");
    Console.WriteLine();
    foreach (var item in context.Tweets)
    {
         Console.WriteLine(item.TweetText);
    }
    Console.WriteLine();
    Console.WriteLine("---------- Comments ---------");
    Console.WriteLine();
    foreach (var item in context.Comments)
    {
        Console.WriteLine(item.CommentText);
    }
}