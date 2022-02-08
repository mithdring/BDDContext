namespace BDDContext;

public static partial class BDDContext
{
    public static TContext Then<TSubject, TContext>(
            this TContext context,
            Action<TContext> action)
        where TContext : Context<TSubject, TContext>
        => context.With(action);

    public static Task<TContext> Then<TSubject, TContext>(
            this TContext context,
            Func<TContext, Task> action)
        where TContext : Context<TSubject, TContext>
        => context.With(action);

    public static async Task<TContext> Then<TSubject, TContext>(
            this Task<TContext> context,
            Action<TContext> action)
        where TContext : Context<TSubject, TContext>
        => (await context).With(action);

    public static async Task<TContext> Then<TSubject, TContext>(
            this Task<TContext> context,
            Func<TContext, Task> action)
        where TContext : Context<TSubject, TContext>
        => await (await context).With(action);
}
