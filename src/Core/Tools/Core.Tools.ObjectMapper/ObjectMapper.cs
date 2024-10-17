using System.Text.Json;

namespace VEA.Core.Tools.ObjectMapper;

public class ObjectMapper(IServiceProvider serviceProvider) : IMapper
{
    public TOutput Map<TOutput>(object input) where TOutput : class
    {
        var type = typeof(IMappingConfig<,>).MakeGenericType(input.GetType(), typeof(TOutput));
        
        dynamic mappingConfig = serviceProvider.GetService(type)!;

        if (mappingConfig != null)
        {
            return mappingConfig.Map((dynamic) input);
        }
        
        string toJson = JsonSerializer.Serialize(input);
        return JsonSerializer.Deserialize<TOutput>(toJson)!;
    }
}