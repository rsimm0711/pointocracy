namespace Pointocracy.Infra.DataCommands;

public interface ISaveContext
{
    ValueTask SaveAsync();
}

internal sealed class SaveContext(PointocracyDb database) : ISaveContext
{
    public async ValueTask SaveAsync() => await database.SaveChangesAsync();
}