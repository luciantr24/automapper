using System;
using System.Collections.Generic;
using System.Linq;
using automapper.Models;
using Newtonsoft.Json;

namespace automapper
{
    public class AutoMapper
    {
        private readonly List<MapperSetting> _allowedMappings = new List<MapperSetting>();

        public AutoMapper(Action<MapperSetting> action)
        {
            var mapperSetting = new MapperSetting();

            action.Invoke(mapperSetting);
            
            mapperSetting.CheckMapperSettings();
            
            _allowedMappings.Add(mapperSetting);
        }

        public T Map<T, TD>(TD input)
        {
            var isMappingAllowed = CheckIfMappingIsAllowed(typeof(T).Name, typeof(TD).Name);

            if (!isMappingAllowed) throw new Exception("Mapping between objects was not defined");
            
            var serializedInput = JsonConvert.SerializeObject(input);

            return JsonConvert.DeserializeObject<T>(serializedInput);
        }
        
        public T Map<T>(object input)
        {
            var isMappingAllowed = CheckIfMappingIsAllowed(typeof(T).Name, input.GetType().Name);

            if (!isMappingAllowed) throw new Exception("Mapping between objects was not defined");
            
            var serializedInput = JsonConvert.SerializeObject(input);

            return JsonConvert.DeserializeObject<T>(serializedInput);
        }

        private bool CheckIfMappingIsAllowed(string from, string to)
        {
            var map = _allowedMappings.Where(_ =>
                _.From == from && _.To == to).Select(_ => _).FirstOrDefault();

            return map != null;
        }
    }
}