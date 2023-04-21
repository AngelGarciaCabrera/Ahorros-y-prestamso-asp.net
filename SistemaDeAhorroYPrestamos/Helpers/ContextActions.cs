using Microsoft.EntityFrameworkCore;

namespace SistemaDeAhorroYPrestamos.Helpers;

public class ContextActions
{
    private static ContextActions actions;

    private ContextActions()
    {
        
    }

    public static ContextActions getInstance()
    {
        if (actions == null)
        {
            actions = new ContextActions();
        }

        return actions;
    }

    public void doAction(DbContext context, IContextActions actions)
    {
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT CuotaPrestamos ON");
        
        actions.doAction(context);
        
        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT CuotaPrestamos OFF");
    }


    public interface IContextActions
    {
        public abstract void doAction(DbContext context);
    }
}