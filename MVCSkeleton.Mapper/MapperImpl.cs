using MVCSkeleton.Infrastracture.Utils.Mapper;

namespace MVCSkeleton.Mapper
{
    /// <summary>
    /// MapperImpl class.
    /// </summary>
    public class MapperImpl : IMapper
    {
        /// <summary>
        /// Maps the specified source to the specified destination dynamically.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public TDestination DynamicMap<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Mapper.DynamicMap<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps the specified source to the specified destination.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps the specified source to the specified destination.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return AutoMapper.Mapper.Map(source, destination);
        }

        /// <summary>
        /// Asserts the configuration is valid.
        /// </summary>
        public void AssertConfigurationIsValid()
        {
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}