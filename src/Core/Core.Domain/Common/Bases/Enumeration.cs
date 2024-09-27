using System.Reflection;

namespace VEA.Core.Domain.Common.Bases;

public abstract class Enumeration(int id, string name) : IComparable
{
  public int Id { get; private set; } = id;
  public string Name { get; private set; } = name;

  public override string ToString() => Name;

  public static T FromId<T>(int id) where T : Enumeration
  {
    var matchingItem = Parse<T, int>(id, "id", item => item.Id == id);
    return matchingItem;
  }
  
  public static T FromName<T>(string name) where T : Enumeration
  {
    var matchingItem = Parse<T, string>(name, "name", item => item.Name == name);
    return matchingItem;
  }

  private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : Enumeration
  {
    var matchingItem = GetAll<T>().FirstOrDefault(predicate);
    if (matchingItem == null)
    {
      throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
    }
    return matchingItem;
  }
  
  public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
    typeof(T).GetFields(BindingFlags.Public |
                        BindingFlags.Static |
                        BindingFlags.DeclaredOnly)
             .Select(f => f.GetValue(null))
             .Cast<T>();

  public int CompareTo(object? other)
  {
    return other == null ? 1 : Id.CompareTo(((Enumeration)other).Id);
  }

  public override bool Equals(object? obj)
  {
    if (obj == null || obj.GetType() != GetType()) return false;
    return Id.Equals(((Enumeration)obj).Id);
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }
  
  public static bool operator ==(Enumeration? a, Enumeration? b)
  {
    if (a is null && b is null) return true;
    if (a is null || b is null) return false;
    return a.Equals(b);
  }
  
  public static bool operator !=(Enumeration a, Enumeration b) => !(a == b);
}
