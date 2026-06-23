using EF07.v2.Data;

using (var context = new ApplicationDbContext())
{
    Console.WriteLine("---------- Users ---------");
    foreach (var item in context.Users)
    {
        Console.WriteLine($"[{item.UserId}] {item.UserName}");
    }
    Console.WriteLine("---------- Tweets ---------");
    foreach (var item in context.Tweets)
    {
         Console.WriteLine(item.TweetText);
    }
    Console.WriteLine("---------- Comments ---------");
    foreach (var item in context.Comments)
    {
        Console.WriteLine(item.CommentText);
    }
}