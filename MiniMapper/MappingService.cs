using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MapperLite
{
    public class MappingService
    {
        private readonly MappingConfiguration _configuration;

        public MappingService(MappingConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var destinationType = typeof(TDestination);
            var sourceType = typeof(TSource);
            var destination = Activator.CreateInstance(destinationType);

            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                // Check if there is an explicit mapping for this property
                if (_configuration.HasMapping<TSource, TDestination>(sourceProperty.Name, out var destinationPropertyName))
                {
                    var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                        dp.Name == destinationPropertyName &&
                        dp.PropertyType == sourceProperty.PropertyType);

                    if (destinationProperty != null)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
                else
                {
                    // If no explicit mapping, try to find a property with a similar name
                    var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                        dp.Name.Equals(sourceProperty.Name, StringComparison.OrdinalIgnoreCase) &&
                        dp.PropertyType == sourceProperty.PropertyType);

                    if (destinationProperty != null)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
            }

            return (TDestination)destination;
           /* var sourceType = typeof(TSource);
            var destinationType = _configuration.GetDestinationType(typeof(TSource));

            if (destinationType == null)
                throw new InvalidOperationException($"No mapping defined for {typeof(TSource)}");

            var destination = Activator.CreateInstance(destinationType);

            // Retrieve the properties of the source and destination types
            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                // Find a matching property in the destination type based on name and type
                var destinationProperty = destinationProperties.FirstOrDefault(
                    dp => dp.Name == sourceProperty.Name && dp.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null)
                {
                    // Copy the value from the source property to the destination property
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }

            return (TDestination)destination;*/
        }

        public TDestination ReverseMap<TSource, TDestination>(TSource source)
        {
            var destinationType = typeof(TDestination);
            var sourceType = typeof(TSource);
            var destination = Activator.CreateInstance(destinationType);

            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                // Check if there is an explicit mapping for this property
                if (_configuration.HasReverseMapping<TSource, TDestination>(sourceProperty.Name, out var destinationPropertyName))
                {
                    var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                        dp.Name == destinationPropertyName &&
                        dp.PropertyType == sourceProperty.PropertyType);

                    if (destinationProperty != null)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
                else
                {
                    // If no explicit mapping, try to find a property with a similar name
                    var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                        dp.Name.Equals(sourceProperty.Name, StringComparison.OrdinalIgnoreCase) &&
                        dp.PropertyType == sourceProperty.PropertyType);

                    if (destinationProperty != null)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
            }

            return (TDestination)destination;
            /*var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var source = Activator.CreateInstance(sourceType);

            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            foreach (var destinationProperty in destinationProperties)
            {
                var sourceProperty = sourceProperties.FirstOrDefault(sp =>
                    sp.Name.Equals(destinationProperty.Name, StringComparison.OrdinalIgnoreCase) &&
                    sp.PropertyType == destinationProperty.PropertyType);

                if (sourceProperty != null)
                {
                    var value = destinationProperty.GetValue(destination);
                    sourceProperty.SetValue(source, value);
                }
            }

            return (TSource)source;*/
        }


        public TDestination CustomMap<TSource, TDestination>(TSource source)
        {
            var destinationType = typeof(TDestination);
            var sourceType = typeof(TSource);
            var destination = Activator.CreateInstance(destinationType);

            var sourceProperties = sourceType.GetProperties();
            var destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                // Check if there is an explicit mapping for this property
                if (_configuration.HasMapping<TSource, TDestination>(sourceProperty.Name, out var destinationPropertyName))
                {
                    var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                        dp.Name == destinationPropertyName &&
                        dp.PropertyType == sourceProperty.PropertyType);

                    if (destinationProperty != null)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
                else
                {
                    // If no explicit mapping, try to find a property with a similar name
                    var destinationProperty = destinationProperties.FirstOrDefault(dp =>
                        dp.Name.Equals(sourceProperty.Name, StringComparison.OrdinalIgnoreCase) &&
                        dp.PropertyType == sourceProperty.PropertyType);

                    if (destinationProperty != null)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
            }

            return (TDestination)destination;

        }


    }

}
