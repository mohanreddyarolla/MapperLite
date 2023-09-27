using System;
using MapperLite;
using MiniMapperTester.Models;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var mappingConfig = new MappingConfiguration();
            mappingConfig.CreateMap<Profile, ProfileDto>();

            var mappingService = new MappingService(mappingConfig);

            var profile = new Profile();
            profile.Id = 1;
            profile.Name = "Test";

            var profileDto = mappingService.Map<Profile, ProfileDto>(profile);

            Console.WriteLine($"Id: {profileDto.Id}");
            Console.WriteLine($"Name : {profileDto.Name}");

            var newProfile = mappingService.ReverseMap<ProfileDto, Profile>(profileDto);

            Console.WriteLine($"Id: {newProfile.Id}");
            Console.WriteLine($"Name : {newProfile.Name}");

            var mappingConfiguration = new MappingConfiguration();
            mappingConfiguration.CreateMap<CustomProfile, ProfileDto>(
                new Dictionary<string, string>
                {
          { "Full_Name", "Name" }
                });

            var customMappingService = new MappingService(mappingConfiguration);

            var sourcePerson = new CustomProfile { Full_Name = "John", Id = 1 };
            var destinationPerson = customMappingService.Map<CustomProfile, ProfileDto>(sourcePerson);

            var newcustomProfile = customMappingService.ReverseMap<ProfileDto, CustomProfile>(destinationPerson);


        }
    }
}