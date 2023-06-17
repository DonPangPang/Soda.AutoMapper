using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Soda.AutoMapper;

/// <summary>
/// 对象映射扩展
/// </summary>
public static class SodaMapperExtension
{
    /// <summary>
    /// </summary>
    public static IMapper Mapper { get; set; } = null!;

    /// <summary>
    /// 配置AutoMapper中间件
    /// </summary>
    /// <param name="mapper"> </param>
    public static void Configure(IMapper mapper)
    {
        Mapper = mapper;
    }

    /// <summary>
    /// 映射到对象
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj"> </param>
    /// <returns> </returns>
    public static T MapTo<T>(this object obj)
    {
        return Mapper.Map<T>(obj);
    }

    /// <summary>
    /// 映射到对象
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj"> </param>
    /// <returns> </returns>
    public static IEnumerable<T> MapTo<T>(this IEnumerable<object> obj)
    {
        return Mapper.Map<IEnumerable<T>>(obj);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj">  </param>
    /// <param name="dest"> </param>
    public static void Map<T>(this object obj, T dest)
    {
        Mapper.Map(obj, dest);
    }

    public static IQueryable<TOut> Map<TIn, TOut>(this IQueryable<TIn> source)
    {
        return Mapper.ProjectTo<TOut>(source);
    }

    /// <summary>
    /// 配置AutoMapper
    /// </summary>
    /// <param name="app"> </param>
    /// <returns> </returns>
    public static IApplicationBuilder InitSodaMapper(this IApplicationBuilder app)
    {
        var mapper = app.ApplicationServices.GetRequiredService<IMapper>();

        Configure(mapper);

        return app;
    }
}