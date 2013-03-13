namespace MVCSkeleton.Mapper
{
    /// <summary>
    /// MapperConfigurator class.
    /// </summary>
    public class MapperConfigurator
    {
        /// <summary>
        /// Loads the specified modules.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public void Load(params IMapperModule[] modules)
        {
            foreach (var mapperModule in modules)
            {
                mapperModule.Load();
            }
        }

        /// <summary>
        /// Asserts that the mapper configuration is valid.
        /// </summary>
        public void AssertConfigurationIsValid()
        {
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}