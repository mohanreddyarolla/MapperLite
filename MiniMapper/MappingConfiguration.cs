using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperLite
{
    public class MappingConfiguration
    {
        public   readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public readonly Dictionary<Type, Dictionary<string, string>> _customMappings =
    new Dictionary<Type, Dictionary<string, string>>();

        public void CreateMap<TSource, TDestination>(Dictionary<string, string> propertyMap)
        {
            _customMappings[typeof(TSource)] = propertyMap;
        }

        public void CreateMap<TSource, TDestination>()
        {
            _mappings[typeof(TSource)] = typeof(TDestination);
        }

        public Type GetDestinationType(Type sourceType)
        {
            return _mappings.TryGetValue(sourceType, out var destinationType) ? destinationType : null;
        }

        public Type GetSourceType(Type destinationType)
        {
            return _mappings.TryGetValue(destinationType, out var sourceType) ? sourceType : null;
        }

        public bool HasMapping<TSource, TDestination>(string sourcePropertyName, out string destinationPropertyName)
        {
            destinationPropertyName = null;

            if (_customMappings.TryGetValue(typeof(TSource), out var propertyMap))
            {
                if (propertyMap.TryGetValue(sourcePropertyName, out destinationPropertyName))
                {
                    return true; // Mapping exists
                }
            }

            return false; // No mapping exists
        }

        public bool HasReverseMapping<TSource, TDestination>(string sourcePropertyName, out string destinationPropertyName)
        {
            destinationPropertyName = null;


            if (_customMappings.TryGetValue(typeof(TDestination), out var propertyMap))
            {

                foreach (var pair in propertyMap)
                {
                    if (pair.Value == sourcePropertyName)
                    {
                        destinationPropertyName = pair.Key;
                        return true; // Mapping exists
                    }
                }
            }

            return false; // No mapping exists
        }
    }

}
