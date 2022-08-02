[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class DependsOnAttribute : Attribute
{
    public DependsOnAttribute(params Type[] dependencies)
    {
        Types = dependencies;
    }

    public Type[] Types { get; }
}