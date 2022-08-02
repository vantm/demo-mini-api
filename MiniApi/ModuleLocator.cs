namespace MiniApi;

internal class ModuleLocator
{
    public ModuleLocator(Module[] items)
    {
        Items = items;
    }

    public Module[] Items { get; }
}