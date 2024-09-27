using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VEA.Core.Domain.Common.Bases;

namespace VEA.Infrastructure.EfcDmPersistence.Converters;

public class EnumerationConverter<T> : ValueConverter<Enumeration, string> where T : Enumeration
{ 
    public EnumerationConverter()
        : base(
            vo => vo.Name,
            dbValue => Enumeration.FromName<T>(dbValue)
        ) { }  
}