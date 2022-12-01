using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace automapper
{
    public sealed class AutoMapper
    {
        private readonly List<Mapping> _allowedMappings = new List<Mapping>();

        public AutoMapper(Action<Mapping> action)
        {
            var mapperSetting = new Mapping();

            action.Invoke(mapperSetting);
            
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