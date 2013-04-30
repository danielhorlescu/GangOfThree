using System.Collections.Generic;

namespace MVCSkeleton.Infrastracture.Utils.Mapper
{
    /// <summary>
    /// IMapper interface.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TResult Map<TSource, TResult>(TSource source);

        /// <summary>
        /// Maps the specified source to the specified destination.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        List<TDestination> Map<TSource, TDestination>(List<TSource> source, List<TDestination> destination) where TDestination : new();

        /// <summary>
        /// Asserts the configuration is valid.
        /// </summary>
        void AssertConfigurationIsValid();

        /// <summary>
        /// Maps the specified source to the specified destination dynamically.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TDestination DynamicMap<TSource, TDestination>(TSource source);
    }
}