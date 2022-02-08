namespace BDDContext;

public abstract class Context<TSubject, TContext>
    where TContext : Context<TSubject, TContext>
{
    protected Context(TSubject subject)
    {
        Subject = subject;
    }

    public TSubject Subject { get; }

    public TContext With(Action<TContext> action)
    {
       var context = (TContext)this;

       action(context);
       return context;
    }

    public async Task<TContext> With(Func<TContext, Task> action)
    {
        var context = (TContext)this;
       
        await action(context); 
        return context;
    }
}
